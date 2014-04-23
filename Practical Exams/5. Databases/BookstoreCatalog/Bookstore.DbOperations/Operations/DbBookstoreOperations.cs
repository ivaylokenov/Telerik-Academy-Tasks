namespace Bookstore.DbOperations.Operations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Transactions;
    using Bookstore.Data;
    using Bookstore.DbOperations.Base;

    public class DbBookstoreOperations : DbBaseOperations
    {
        public void InsertBookWithAuthorAndTitle(string title, string authorName, decimal? price, string isbn, string website)
        {
            Book currentBook = new Book()
            {
                Title = title,
                Price = price,
                ISBN = isbn,
                Website = website
            };

            currentBook.Authors = new List<Author>();
            currentBook.Authors.Add(AddAuthor(authorName));

            DBContext.Books.Add(currentBook);
            DBContext.SaveChanges();
        }

        public void InsertBookWithAuthorsAndReviews(string title, string ISBN, decimal? price, string website,
            List<string> authors, List<string> reviewAuthors, List<string> reviewContents, List<string> reviewDates)
        {
            TransactionScope tran = new TransactionScope(
            TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });

            using (tran)
            {
                Book currentBook = new Book()
                {
                    Title = title,
                    ISBN = ISBN,
                    Price = price,
                    Website = website
                };

                if (authors == null || authors.Count == 0)
                {
                    currentBook.Authors = null;
                }
                else
                {
                    currentBook.Authors = new List<Author>();
                    foreach (var authorName in authors)
                    {
                        currentBook.Authors.Add(AddAuthor(authorName));
                    }
                }

                if (reviewContents == null || reviewContents.Count == 0)
                {
                    currentBook.Reviews = null;
                }
                else
                {
                    currentBook.Reviews = new List<Review>();

                    var allReviews = GenerateReviews(reviewAuthors, reviewContents, reviewDates);

                    foreach (var review in allReviews)
                    {
                        DBContext.Reviews.Add(review);

                        currentBook.Reviews.Add(review);
                    }
                }

                DBContext.Books.Add(currentBook);

                DBContext.SaveChanges();

                tran.Complete();
            }
        }

        public List<Book> SearchBooksWithAuthorTitleOrIsbn(string title, string authorName, string ISBN)
        {
            IQueryable<Book> result = DBContext.Books;

            if (title != null)
            {
                result = result.Where(x => x.Title == title);
            }

            if (authorName != null)
            {
                result = result.Where(x => x.Authors.Any(a => a.Name == authorName));
            }

            if (ISBN != null)
            {
                result = result.Where(x => x.ISBN == ISBN);
            }

            result.OrderBy(x => x.Title).Select(x => new
            {
                title = x.Title,
                count = x.Reviews.Count
            });

            return result.ToList();
        }

        private ICollection<Review> GenerateReviews(List<string> reviewAuthors, List<string> reviewContents, List<string> reviewDates)
        {
            var result = new List<Review>();

            for (int i = 0; i < reviewAuthors.Count; i++)
            {
                DateTime? date = null;

                if (reviewDates[i] != null)
                {
                    date = DateTime.Parse(reviewDates[i]);
                }

                int? authorId = null;

                if (reviewAuthors[i] != null)
                {
                    authorId = AddAuthor(reviewAuthors[i]).AuthorId;
                }

                var review = new Review()
                {
                    DateCreatedOn = date,
                    ReviewContent = reviewContents[i],
                    AuthorId = authorId
                };

                result.Add(review);
            }

            return result;
        }

        private Author AddAuthor(string name)
        {
            var existingAuthor = DBContext.Authors.Where(x => x.Name == name).FirstOrDefault();

            if (existingAuthor != null)
            {
                return existingAuthor;
            }
            else
            {
                Author author = new Author()
                {
                    Name = name
                };

                DBContext.Authors.Add(author);
                DBContext.SaveChanges();
                return author;
            }
        }

        public List<Review> SearchReviewsByPeriod(DateTime startDate, DateTime endDate)
        {
            var result = DBContext.Reviews
                .Where(x => startDate <= x.DateCreatedOn && x.DateCreatedOn <= endDate)
                .OrderBy(x => x.DateCreatedOn)
                .ThenBy(x => x.ReviewContent)
                .ToList();

            return result;
        }

        public List<Review> SearchReviewsByAuthor(string authorName)
        {
            var result = DBContext.Reviews
                .Where(x => x.Author.Name == authorName)
                .OrderBy(x => x.DateCreatedOn)
                .ThenBy(x => x.ReviewContent)
                .ToList();

            return result;
        }
    }
}
