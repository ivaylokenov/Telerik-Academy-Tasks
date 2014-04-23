namespace TicketSystem.Model
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel;

    public class Author : User
    {
        [DefaultValue(10)]
        public int Points { get; set; }
    }
}
