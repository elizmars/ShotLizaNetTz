using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShotEzlizavetaNetTz.DataModels;

namespace ShotEzlizavetaNetTz.DataStorage
{
    public class ShotLizaBookRepository
    {
        public List<ShotLizaBook> GetAll()
        {
            using (var db = new ShotLizaDataContext())
            {
                return db.Books.Include(x => x.Authors).ToList();
            }
        }

        public void AddBook(ShotLizaBook book)
        {
            using (var db = new ShotLizaDataContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }

        }

        public void RemoveBook(ShotLizaBook book)
        {
            using (var db = new ShotLizaDataContext())
            {
                db.Entry(book).State = EntityState.Deleted;
               
                db.SaveChanges();
            }
        }
    }
}
