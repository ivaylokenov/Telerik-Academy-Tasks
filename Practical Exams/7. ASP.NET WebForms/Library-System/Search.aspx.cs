using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using WebFormsTemplate.Models;
using Error_Handler_Control;

namespace WebFormsTemplate
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var segments = Request.GetFriendlyUrlSegments();

            LibrarySystemDbContext data = new LibrarySystemDbContext();

            if (segments.Count == 0)
            {
                var results = data.Books.ToList();

                ResultsRepeater.DataSource = results;
                ResultsRepeater.DataBind();
            }
            else
            {
                var query = segments[0];

                if (query.Length > 100)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Search query cannot be more than 100 characters");
                    Response.Redirect("~/");
                }

                var results = data.Books
                    .Where(x => x.Title.Contains(query) || x.Authors.Contains(query))
                    .OrderBy(x => x.Title)
                    .ThenBy(x => x.Authors)
                    .ToList();

                ResultsRepeater.DataSource = results;
                ResultsRepeater.DataBind();
            }
        }
    }
}