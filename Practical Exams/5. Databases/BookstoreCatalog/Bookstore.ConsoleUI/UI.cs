namespace Bookstore.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using Bookstore.Data;
    using Bookstore.Tools.XMLTools;

    public class UI
    {
        public static void PrintResult(List<Book> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Nothing found");
                return;
            }

            foreach (var book in list)
            {
                if (book.Reviews.Count != 0)
                {
                    Console.WriteLine(book.Title + " --> " + book.Reviews.Count + " reviews");
                }
                else
                {
                    Console.WriteLine(book.Title + " --> no reviews");
                }
            }
        }

        public static void Main()
        {
            BooksParser bookParser = new BooksParser();

            bookParser.ProcessBooksByAuthorAndTitle("../../XML Files/simple-books.xml");
            bookParser.ProcessBooksByAuthorAndReviews("../../XML Files/complex-books.xml");
            var list = bookParser.SearchBooksByAuthorTitleOrIsbn("../../XML Files/simple-query.xml");
            PrintResult(list);
            bookParser.SearchReviews("../../XML Files/reviews-queries.xml");
        }
    }
}
