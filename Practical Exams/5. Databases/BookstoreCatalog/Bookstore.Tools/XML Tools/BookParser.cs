namespace Bookstore.Tools.XMLTools
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Bookstore.Data;
    using Bookstore.DbOperations.Operations;
    using Bookstore.Logs;

    public class BooksParser : XMLFileParser
    {
        public BooksParser()
        {
            this.DBOperation = new DbBookstoreOperations();
        }

        public DbBookstoreOperations DBOperation { get; private set; }

        public XmlNode Root { get; private set; }

        public void ProcessBooksByAuthorAndTitle(string file)
        {
            this.Document.Load(file);
            this.Root = this.Document.DocumentElement;

            foreach (XmlNode book in this.Root.ChildNodes)
            {
                string authorName;
                string title;
                string ISBN;
                decimal? price;
                string website;

                try { authorName = book["author"].InnerText; }
                catch { throw new ArgumentException("Author is missing."); }

                try { title = book["title"].InnerText; }
                catch { throw new ArgumentException("Title is missing."); }

                try { ISBN = book["isbn"].InnerText.Trim(); }
                catch { ISBN = null; }

                try { price = decimal.Parse(book["price"].InnerText); }
                catch { price = null; }

                try { website = book["web-site"].InnerText; }
                catch { website = null; }

                DBOperation.InsertBookWithAuthorAndTitle(title, authorName, price, ISBN, website);
            }
        }

        public void ProcessBooksByAuthorAndReviews(string file)
        {
            this.Document.Load(file);
            this.Root = this.Document.DocumentElement;

            foreach (XmlNode book in this.Root.ChildNodes)
            {
                string title;
                string ISBN;
                decimal? price;
                string website;

                try { title = book["title"].InnerText; }
                catch { throw new ArgumentException("Title is missing."); }

                try { ISBN = book["isbn"].InnerText.Trim(); }
                catch { ISBN = null; }

                try { price = decimal.Parse(book["price"].InnerText); }
                catch { price = null; }

                try { website = book["web-site"].InnerText; }
                catch { website = null; }

                var authors = new List<string>();

                try
                {
                    foreach (XmlNode author in book["authors"].ChildNodes)
                    {
                        authors.Add(author.InnerText);
                    }
                }
                catch
                {
                    authors = null;
                }

                var reviewAuthors = new List<string>();
                var reviewDates = new List<string>();
                var reviewContents = new List<string>();

                try
                {
                    foreach (XmlNode review in book["reviews"].ChildNodes)
                    {
                        try { reviewAuthors.Add(review.Attributes["author"].Value); }
                        catch { reviewAuthors.Add(null); }

                        try { reviewDates.Add(review.Attributes["date"].Value); }
                        catch { reviewDates.Add(null); }

                        reviewContents.Add(review.InnerText);
                    }
                }
                catch
                {
                    reviewAuthors = null;
                    reviewDates = null;
                    reviewContents = null;
                }

                DBOperation.InsertBookWithAuthorsAndReviews(title, ISBN, price, website, authors, reviewAuthors, reviewContents, reviewDates);
            }
        }

        public List<Book> SearchBooksByAuthorTitleOrIsbn(string file)
        {
            this.Document.Load(file);
            this.Root = this.Document.DocumentElement;

            string authorName;
            string title;
            string ISBN;

            try { authorName = this.Root["author"].InnerText; }
            catch { authorName = null; }

            try { title = this.Root["title"].InnerText; }
            catch { title = null; }

            try { ISBN = this.Root["isbn"].InnerText.Trim(); }
            catch { ISBN = null; }

            return DBOperation.SearchBooksWithAuthorTitleOrIsbn(title, authorName, ISBN);
        }

        public void SearchReviews(string file)
        {
            this.Document.Load(file);
            this.Root = this.Document.DocumentElement;

            string fileName = "../../XML Files/reviews-search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                foreach (XmlNode query in this.Root.ChildNodes)
                {
                    var typeOfQuery = query.Attributes["type"].Value;
                    List<Review> result = new List<Review>(); ;

                    if (typeOfQuery == "by-period")
                    {
                        DateTime startDate = DateTime.Parse(query["start-date"].InnerText);
                        DateTime endDate = DateTime.Parse(query["end-date"].InnerText);

                        result = DBOperation.SearchReviewsByPeriod(startDate, endDate);
                    }
                    else if (typeOfQuery == "by-author")
                    {
                        string authorName = query["author-name"].InnerText;

                        result = DBOperation.SearchReviewsByAuthor(authorName);
                    }

                    if (result.Count != 0)
                    {
                        WriteResult(result, writer);
                    }

                    SaveLog(query);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void SaveLog(XmlNode query)
        {
            Log currentLog = new Log()
            {
                DateCreatedOn = DateTime.Now,
                LogContent = query.OuterXml
            };

            DBOperation.LogContext.Logs.Add(currentLog);
            DBOperation.LogContext.SaveChanges();
        }

        private string ConvertNumberToMonth(int month)
        {
            switch (month)
            {
                case 1: return "Jan";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Apr";
                case 5: return "Mai";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Aug";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dec";
                default:
                    throw new ArgumentException("Month is not valid.");
            }
        }

        private void WriteResult(List<Review> result, XmlTextWriter writer)
        {
            writer.WriteStartElement("result-set");

            foreach (var review in result)
            {
                writer.WriteStartElement("review");

                if (review.DateCreatedOn != null)
                {
                    writer.WriteStartElement("date");

                    writer.WriteString(review.DateCreatedOn.Value.Day + "-" + ConvertNumberToMonth(review.DateCreatedOn.Value.Month) + "-" + review.DateCreatedOn.Value.Year);

                    writer.WriteEndElement();
                }

                if (review.ReviewContent != null)
                {
                    writer.WriteStartElement("content");

                    writer.WriteString(review.ReviewContent);

                    writer.WriteEndElement();
                }

                if (review.Book != null)
                {
                    writer.WriteStartElement("book");

                    if (review.Book.Title != null)
                    {
                        writer.WriteStartElement("title");

                        writer.WriteString(review.Book.Title);

                        writer.WriteEndElement();
                    }

                    if (review.Book.Authors != null && review.Book.Authors.Count != 0)
                    {
                        writer.WriteStartElement("authors");

                        var resultAuthors = review.Book.Authors.OrderBy(x => x.Name).Select(x => x.Name).ToList();

                        writer.WriteString(string.Join(", ", resultAuthors));

                        writer.WriteEndElement();
                    }

                    if (review.Book.ISBN != null)
                    {
                        writer.WriteStartElement("isbn");

                        writer.WriteString(review.Book.ISBN);

                        writer.WriteEndElement();
                    }

                    if (review.Book.Website != null)
                    {
                        writer.WriteStartElement("url");

                        writer.WriteString(review.Book.Website);

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
