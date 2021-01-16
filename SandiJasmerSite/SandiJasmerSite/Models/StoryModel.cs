using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheRockFanPage.Models
{
    public class StoryModel
    {
        [Key]
        public int StoryID { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        //public string Topic { get; set; }


        [Required]
        public string StoryText { get; set; }

        //my stroies has a user (HAS A relationship)
        //Let EF manage the foriegn keys for setup. 
        public User Submitter { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}

