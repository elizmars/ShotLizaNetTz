using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShotEzlizavetaNetTz.DataModels;

namespace ShotEzlizavetaNetTz.DataStorage
{
    public class ShotLizaAuthorRepository
    {
        public List<ShotLizaAuthor> GetAll()
        {
            using (var db = new ShotLizaDataContext())
            {
                return db.Authors.Include(x => x.Books).ToList();
            }
        }
    }
}
