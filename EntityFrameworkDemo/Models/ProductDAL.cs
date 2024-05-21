using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class ProductDAL
    {
        private ApplicationDbContext db;

        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Product> GetProducts()
        {
         
            var model = (from emp in db.pdt
                         select emp).ToList();
            return model;

        }

        public Product GetProductById(int id)
        {

            var model = db.pdt.Where(x => x.Pid == id).SingleOrDefault();
            return model;
        }

        public int AddProduct(Product p)
        {
            int res = 0;
            db.pdt.Add(p);
            res = db.SaveChanges();
            return res;
        }
        public int EditProduct(Product p)
        {
            int res = 0;
            var model = db.pdt.Where(x => x.Pid == p.Pid).SingleOrDefault();
            if (model != null)
            {
                model.Pname = p.Pname;
                model.Pprice = p.Pprice;
              
                res = db.SaveChanges();
            }
            return res;
        }
        public int DeleteProduct(int id)
        {
            int res = 0;
            var model = db.pdt.Where(x => x.Pid == id).SingleOrDefault();
            if (model != null)
            {
                db.pdt.Remove(model);
                res = db.SaveChanges();
            }
            return res;
        }

    }
}
