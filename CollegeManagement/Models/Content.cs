using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CollegeManagement.Models
{
    public class Content: BaseModel
    {
        public enum HomeType
        {
            AboutUs,
            History,
            Event
        }

        [Required()]
        [MaxLength(200, ErrorMessage = "Title max length is 200")]
        public string? Title { get; set; }
        public int? Type { get; set; }
        [Range(1900, int.MaxValue, ErrorMessage = "Year must be larger than 1900")]
        public int? Year { get; set; }
        [Required()]
        [AllowHtml]
        public string Description { get; set; }
    }
}
