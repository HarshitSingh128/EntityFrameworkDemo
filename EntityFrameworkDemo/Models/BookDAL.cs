
using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class BookDAL
    {
        private ApplicationDbContext db;
        public BookDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Book> GetBooks()
        {
            
            var model = (from b in db.Bk
                         select b).ToList();
            return model;

        }

        public Book GetBookById(int id)
        {

            var model = db.Bk.Where(x => x.Id == id).SingleOrDefault();
            return model;
        }

        public int AddBooks(Book b)
        {
            int res = 0;
            db.Bk.Add(b);
            res = db.SaveChanges();
            return res;
        }
        public int EditBooks(Book b)
        {
            int res = 0;
            var model = db.Bk.Where(x => x.Id == b.Id).SingleOrDefault();
            if (model != null)
            {
                model.Name = b.Name;
                model.Price = b.Price;
                model.Aname= b.Aname;
                res = db.SaveChanges();
            }
            return res;
        }
        public int DeleteBook(int id)
        {
            int res = 0;
            var model = db.Bk.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                db.Bk.Remove(model);
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
