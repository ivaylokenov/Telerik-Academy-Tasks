namespace TicketSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using TicketSystem.Data;
    using TicketSystem.Model;
    using TicketSystem.Web.ViewModels;

    [Authorize(Roles = "Admin")]
    public class AdministrationCommentsController : BaseController
    {
        public AdministrationCommentsController(ITSData data)
            : base(data)
        {
        }

        // GET: /LaptopsAdministration/
        public ActionResult Index()
        {
            var comments = this.Data.Comments.All().Select(AdminCommentViewModel.FromComment);
            return View(comments.ToList());
        }

        // GET: /LaptopsAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.Data.Comments.All()
                .Where(com => com.Id == id)
                .Select(AdminCommentViewModel.FromComment)
                .FirstOrDefault();

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /LaptopsAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = this.Data.Comments.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /LaptopsAdministration/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.Data.Comments.Update(comment);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: /LaptopsAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.Data.Comments.All()
                .Where(com => com.Id == id)
                .Select(AdminCommentViewModel.FromComment)
                .FirstOrDefault();

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /LaptopsAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = this.Data.Comments.GetById(id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
