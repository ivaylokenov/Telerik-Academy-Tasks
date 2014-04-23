using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;
using Microsoft.AspNet.FriendlyUrls;

namespace WebFormsTemplate
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var segments = Request.GetFriendlyUrlSegments();
            var id = int.Parse(segments[0]);

            LibrarySystemDbContext data = new LibrarySystemDbContext();

            var book = data.Books.FirstOrDefault(x => x.Id == id);

            BookDetail.DataSource = new List<Book> { book };
            BookDetail.DataBind();
        }
    }
}