namespace TicketSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TicketSystem.Data;
    using TicketSystem.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ITSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var mostCommentedTickets = this.Data.Tickets
                    .All()
                    .OrderByDescending(ticket => ticket.Comments.Count)
                    .Take(6)
                    .Select(TicketViewModel.FromTicket);

                this.HttpContext.Cache.Add("HomePageTickets", mostCommentedTickets, null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]);
        }
    }
}