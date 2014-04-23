using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;

namespace WebFormsTemplate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<WebFormsTemplate.Models.Category> AllCategoriesList_GetData()
        {
            LibrarySystemDbContext data = new LibrarySystemDbContext();

            var categories = data.Categories.OrderBy(x => x.Name);

            return categories;
        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search/" + SearchText.Text);
        }
    }
}