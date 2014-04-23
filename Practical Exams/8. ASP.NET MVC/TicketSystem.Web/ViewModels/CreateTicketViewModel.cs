namespace TicketSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using TicketSystem.Model;

    public class CreateTicketViewModel
    {
        [DisplayName("Category")]
        [Required]
        public int Category { get; set; }

        public IEnumerable<SelectListItem> AllCategories { get; set; }

        [Required]
        [ShouldNotContainBug(ErrorMessage="Title should not contain the word \"bug\".")]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public IEnumerable<SelectListItem> AllPriorities { get; set; }

        [DisplayName("Screenshot URL")]
        public string ScreenshotUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}