using System.Data.Entity;
using ShotEzlizavetaNetTz.DataModels;

namespace ShotEzlizavetaNetTz.DataStorage
{
    public class ShotLizaDataContext : DbContext
    {
        public ShotLizaDataContext() :
            base("DBConnection")
        {
        } 

        public DbSet<ShotLizaBook> Books { get; set; }

        public DbSet<ShotLizaAuthor> Authors { get; set; }
    }
}

