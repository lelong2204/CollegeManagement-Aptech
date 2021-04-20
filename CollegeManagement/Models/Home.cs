using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Home: BaseModel
    {
        public enum HomeType
        {
            HomeScreen,
            AboutUs,
            History,
            Event
        }

        [MaxLength(200, ErrorMessage = "Title max length is 200")]
        public string? Title { get; set; }

        [MaxLength(2000, ErrorMessage = "Description max length is 2000")]
        public string? Description { get; set; }
        public int? Type { get; set; }
        public DateTime? ExpiredDate { get; set; }

    }
}
