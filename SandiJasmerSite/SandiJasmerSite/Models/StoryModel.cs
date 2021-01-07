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

        public string Title { get; set; }
       
        //public string Topic { get; set; }

        public string StoryText { get; set; }

        //my stroies has a user (HAS A relationship)
        //Let EF manage the foriegn keys for setup. 
        public User Submitter { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}

