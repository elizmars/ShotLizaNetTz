using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShotEzlizavetaNetTz.DataModels
{
    public class ShotLizaBook
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public string Yearh { get; set; }

        public List<ShotLizaAuthor> Authors { get; set; }

        public ShotLizaBook()
        {
            Authors = new List<ShotLizaAuthor>();
        }
    }
}