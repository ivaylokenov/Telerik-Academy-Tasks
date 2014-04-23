namespace TicketSystem.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using TicketSystem.Model;

    public class AdminCategoryViewModel
    {
        public static Expression<Func<Category, AdminCategoryViewModel>> FromCategory
        {
            get
            {
                return cat => new AdminCategoryViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name
                };
            }
        }

        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
    }
}