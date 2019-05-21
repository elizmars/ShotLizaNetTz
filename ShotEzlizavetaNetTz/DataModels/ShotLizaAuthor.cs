using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShotEzlizavetaNetTz.DataModels
{
    public class ShotLizaAuthor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public List<ShotLizaBook> Books { get; set; }

        public ShotLizaAuthor()
        {
            Books = new List<ShotLizaBook>();
        }
    }
}