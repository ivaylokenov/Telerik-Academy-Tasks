namespace TicketSystem.Web.Controllers
{
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TicketSystem.Data;
    using TicketSystem.Model;
    using TicketSystem.Web.ViewModels;

    public class TicketsController : BaseController
    {
        public TicketsController(ITSData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var selectedTicket = this.Data.Tickets.All()
                .Where(ticket => ticket.Id == id)
                .Select(TicketDetailsViewModel.FromTicket)
                .FirstOrDefault();

            return View(selectedTicket);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateTicketViewModel
            {
                AllCategories = GetCategoriesSelectList(),
                AllPriorities = GetPrioritieSelectList()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketViewModel ticket)
        {
            if (ticket != null && ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newTicket = new Ticket
                {
                    AuthorId = userId,
                    CategoryId = ticket.Category,
                    Title = ticket.Title,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Priority = ticket.Priority,
                    Description = ticket.Description,
                };

                this.Data.Tickets.Add(newTicket);
                this.Data.Authors.All().First(user => user.Id == userId).Points++;
                this.Data.SaveChanges();

                TempData["SuccessMessage"] = "Ticket added successfully!";
                return RedirectToAction("All");
            }

            ticket.AllCategories = GetCategoriesSelectList();
            ticket.AllPriorities = GetPrioritieSelectList();

            return View(ticket);
        }

        [Authorize]
        public ActionResult All()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetCategories()
        {
            var categories = this.Data.Categories.All().Select(cat => new { Id = cat.Id, Name = cat.Name });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request, string category)
        {
            var tickets = this.Data.Tickets.All();

            if (!string.IsNullOrEmpty(category))
            {
                int categoryId = int.Parse(category);

                tickets = tickets.Where(ticket => ticket.CategoryId == categoryId);
            }

            var result = tickets.Select(ListTicketViewModel.FromTicket);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var userName = User.Identity.GetUserName();

                this.Data.Comments.Add(new Comment
                {
                    AuthorId = userId,
                    TicketId = comment.TicketId,
                    Content = comment.Content
                });

                this.Data.SaveChanges();

                var commentModel = new CommentViewModel
                {
                    Content = comment.Content,
                    AuthorUsername = userName
                };

                return PartialView("_CommentPartial", commentModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        private IEnumerable<SelectListItem> GetCategoriesSelectList()
        {
            var categories = this.Data.Categories.All()
                .ToList()
                .Select(cat => new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString()
                });

            return categories;
        }

        private IEnumerable<SelectListItem> GetPrioritieSelectList()
        {
            var priorites = Enum.GetValues(typeof(Priority))
                .Cast<Priority>()
                .ToList()
                .Select(pr => new SelectListItem
                {
                    Text = pr.ToString(),
                    Value = pr.ToString()
                });

            return priorites;
        }
    }
}