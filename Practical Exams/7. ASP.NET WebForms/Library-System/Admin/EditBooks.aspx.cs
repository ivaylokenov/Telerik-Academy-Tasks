using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string CutLongString(string text)
        {
            return text.Length > 20 ? text.Substring(0, 20) + "..." : text;
        }

        public IQueryable<WebFormsTemplate.Models.BookViewModel> BooksGrid_GetData()
        {
            LibrarySystemDbContext data = new LibrarySystemDbContext();

            var books = data.Books.OrderBy(b => b.Id).Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Authors = x.Authors,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    WebSite = x.WebSite,
                    CategoryName = x.Category.Name,
                });

            return books;
        }

        public IQueryable<Category> BooksCategoris_GetData()
        {
            LibrarySystemDbContext data = new LibrarySystemDbContext();

            var categories = data.Categories.OrderBy(cat => cat.Id);

            return categories;
        }

        protected void CreateBook_Click(object sender, EventArgs e)
        {
            BookCreate.DataSource = new List<Book> { new Book { Title = string.Empty } };
            BookCreate.DataBind();
        }

        protected void SaveCreate_Click(object sender, EventArgs e)
        {
            var title = (BookCreate.FindControl("BookTitle") as TextBox).Text;
            var authors = (BookCreate.FindControl("BookAuthors") as TextBox).Text;
            var ISBN = (BookCreate.FindControl("BookIsbn") as TextBox).Text;
            var site = (BookCreate.FindControl("BookSite") as TextBox).Text;
            var description = (BookCreate.FindControl("BookDescription") as TextBox).Text;
            var categoryId = int.Parse((BookCreate.FindControl("BookCategory") as DropDownList).SelectedValue);

            if (string.IsNullOrEmpty(title))
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title cannot be empty");
                return;
            }
            else if (title.Length < 5 || title.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title must be between 5 and 50 symbols");
                return;
            }
            else if (string.IsNullOrEmpty(authors))
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Authors cannot be empty");
                return;
            }
            else if (authors.Length < 5 || authors.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Authors must be between 5 and 50 symbols");
                return;
            }
            else if (ISBN.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("ISBN must be less than 50 symbols");
                return;
            }
            else if (site.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("ISBN must be less than 50 symbols");
                return;
            }
            else if (description.Length > 2000)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Description must be less than 2000 symbols");
                return;
            }
            else if (categoryId == -1)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Authors cannot be empty");
                return;
            }

            LibrarySystemDbContext context = new LibrarySystemDbContext();

            context.Books.Add(new Book
            {
                Title = title,
                Authors = authors,
                ISBN = ISBN,
                WebSite = site,
                Description = description,
                CategoryId = categoryId
            });

            context.SaveChanges();

            BookCreate.DataSource = null;
            BookCreate.DataBind();
            BooksGrid.DataBind();
        }

        protected void CancelCreate_Click(object sender, EventArgs e)
        {
            BookCreate.DataSource = null;
            BookCreate.DataBind();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
            var bookId = int.Parse(BooksGrid.DataKeys[row.RowIndex].Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var book = data.Books.FirstOrDefault(x => x.Id == bookId);

            BookEdit.DataSource = new List<Book> { book };
            BookEdit.DataBind();

            (BookEdit.FindControl("BookCategory") as DropDownList).SelectedValue = book.CategoryId.ToString();
        }

        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            var title = (BookEdit.FindControl("BookTitle") as TextBox).Text;
            var authors = (BookEdit.FindControl("BookAuthors") as TextBox).Text;
            var ISBN = (BookEdit.FindControl("BookIsbn") as TextBox).Text;
            var site = (BookEdit.FindControl("BookSite") as TextBox).Text;
            var description = (BookEdit.FindControl("BookDescription") as TextBox).Text;
            var categoryId = int.Parse((BookEdit.FindControl("BookCategory") as DropDownList).SelectedValue);

            if (string.IsNullOrEmpty(title))
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title cannot be empty");
                return;
            }
            else if (title.Length < 5 || title.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Title must be between 5 and 50 symbols");
                return;
            }
            else if (string.IsNullOrEmpty(authors))
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Authors cannot be empty");
                return;
            }
            else if (authors.Length < 5 || authors.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Authors must be between 5 and 50 symbols");
                return;
            }
            else if (ISBN.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("ISBN must be less than 50 symbols");
                return;
            }
            else if (site.Length > 50)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("ISBN must be less than 50 symbols");
                return;
            }
            else if (description.Length > 2000)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Description must be less than 2000 symbols");
                return;
            }
            else if (categoryId == -1 || categoryId == null)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Authors cannot be empty");
                return;
            }

            var id = int.Parse(BookEdit.DataKey.Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            book.Title = title;
            book.Authors = authors;
            book.ISBN = ISBN;
            book.WebSite = site;
            book.Description = description;
            book.CategoryId = categoryId;

            data.SaveChanges();

            BookEdit.DataSource = null;
            BookEdit.DataBind();
            BooksGrid.DataBind();
        }

        protected void CancelEdit_Click(object sender, EventArgs e)
        {
            BookEdit.DataSource = null;
            BookEdit.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
            var bookId = int.Parse(BooksGrid.DataKeys[row.RowIndex].Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var book = data.Books.FirstOrDefault(x => x.Id == bookId);

            BookDelete.DataSource = new List<Book> { book };
            BookDelete.DataBind();
        }

        protected void SaveDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(BookDelete.DataKey.Value.ToString());

            LibrarySystemDbContext data = new LibrarySystemDbContext();
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            data.Books.Remove(book);

            data.SaveChanges();

            BookDelete.DataSource = null;
            BookDelete.DataBind();
            BooksGrid.DataBind();
        }

        protected void CancelDelete_Click(object sender, EventArgs e)
        {
            BookDelete.DataSource = null;
            BookDelete.DataBind();
        }
    }
}