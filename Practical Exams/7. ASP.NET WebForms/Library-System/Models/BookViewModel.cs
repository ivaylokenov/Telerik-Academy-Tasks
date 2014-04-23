namespace WebFormsTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}