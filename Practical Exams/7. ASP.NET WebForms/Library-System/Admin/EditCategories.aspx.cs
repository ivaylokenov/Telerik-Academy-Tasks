using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> CategoriesGrid_GetData()
        {
            LibrarySystemDbContext data = new LibrarySystemDbContext();

            var categories = data.Categories.OrderBy(cat => cat.Id);

            return categories;
        }

        public string CutLongString(string text)
        {
            return text.Length > 20 ? text.Substring(0, 20) + "..." : text;
        }

        protected void CreateCategory_Click(object sender, EventArgs e)
        {
            CategoryCreate.DataSource = new List<Category> { new Category { Name = string.Empty } };
            CategoryCreate.DataBind();
        }

        protected void SaveCreate_Click(object sender, EventArgs e)
        {
            var name = (CategoryCreate.FindControl("CreateCategory") as TextBox).Text;

            if (string.IsNullOrEmpty(name))
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title cannot be empty");
                return;
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title must be between 5 and 50 symbols");
                return;
            }

            LibrarySystemDbContext context = new LibrarySystemDbContext();

            context.Categories.Add(new Category
            {
                Name = name,
            });

            context.SaveChanges();

            CategoryCreate.DataSource = null;
            CategoryCreate.DataBind();
            CategoriesGrid.DataBind();
        }

        protected void CancelCreate_Click(object sender, EventArgs e)
        {
            CategoryCreate.DataSource = null;
            CategoryCreate.DataBind();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
            var categoryId = int.Parse(CategoriesGrid.DataKeys[row.RowIndex].Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var category = data.Categories.FirstOrDefault(x => x.Id == categoryId);

            CategoryDetails.DataSource = new List<Category> { category };
            CategoryDetails.DataBind();
        }

        protected void CancelEdit_Click(object sender, EventArgs e)
        {
            CategoryDetails.DataSource = null;
            CategoryDetails.DataBind();
        }

        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            var newName = (CategoryDetails.FindControl("EditCategory") as TextBox).Text;

            if (string.IsNullOrEmpty(newName))
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title cannot be empty");
                return;
            }
            else if (newName.Length < 5 || newName.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title must be between 5 and 50 symbols");
                return;
            }

            var id = int.Parse(CategoryDetails.DataKey.Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var category = data.Categories.FirstOrDefault(x => x.Id == id);
            category.Name = newName;

            data.SaveChanges();

            CategoryDetails.DataSource = null;
            CategoryDetails.DataBind();
            CategoriesGrid.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
            var categoryId = int.Parse(CategoriesGrid.DataKeys[row.RowIndex].Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var category = data.Categories.FirstOrDefault(x => x.Id == categoryId);

            CategoryDelete.DataSource = new List<Category> { category };
            CategoryDelete.DataBind();
        }

        protected void CancelDelete_Click(object sender, EventArgs e)
        {
            CategoryDelete.DataSource = null;
            CategoryDelete.DataBind();
        }

        protected void SaveDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(CategoryDelete.DataKey.Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var category = data.Categories.FirstOrDefault(x => x.Id == id);
            data.Books.RemoveRange(category.Books);
            data.Categories.Remove(category);

            data.SaveChanges();

            CategoryDelete.DataSource = null;
            CategoryDelete.DataBind();
            CategoriesGrid.DataBind();
        }
    }
}