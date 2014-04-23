namespace TicketSystem.Web.Controllers
{
    using System.Web.Mvc;
    using TicketSystem.Data;

    public class BaseController : Controller
    {
        protected ITSData Data;

        public BaseController(ITSData data)
        {
            this.Data = data;
        }
	}
}