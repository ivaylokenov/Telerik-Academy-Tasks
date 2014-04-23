namespace TicketSystem.Web.Controllers
{
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TicketSystem.Data;
    using TicketSystem.Web.ViewModels;
    using TicketSystem.Model;

    [Authorize(Roles="Admin")]
    public class AdministrationCategoriesController : BaseController
    {
        public AdministrationCategoriesController(ITSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, AdminCategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.Data.Categories.Add(new Category
                {
                    Name = category.Name,
                });

                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = this.Data.Categories.All().Select(AdminCategoryViewModel.FromCategory);

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, AdminCategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var commentDb = this.Data.Categories.GetById(category.Id);

                commentDb.Name = category.Name;
                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, AdminCategoryViewModel category)
        {
            var selectedCategory = this.Data.Categories.GetById(category.Id);

            foreach (var ticket in selectedCategory.Tickets.ToList())
            {
                foreach (var comment in ticket.Comments.ToList())
                {
                    this.Data.Comments.Delete(comment.Id);
                }

                this.Data.Tickets.Delete(ticket.Id);
            }

            this.Data.Categories.Delete(selectedCategory.Id);

            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}