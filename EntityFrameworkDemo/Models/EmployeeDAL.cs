


using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class EmployeeDAL
    {
        private ApplicationDbContext db;
        public EmployeeDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Employee> GetEmployees()
        {
            //lambda exp
            //return db.Employees.ToList();
            var model = (from emp in db.Employees
                      select emp).ToList();
            return model;

        }

        public Employee GetEmployeeById(int id)
        {

            var model = db.Employees.Where(x => x.Id == id).SingleOrDefault();
            return model;
        }

        public int AddEmployee(Employee emp)
        {
            int res = 0;
            db.Employees.Add(emp);
            res = db.SaveChanges();
            return res;
        }
        public int EditEmployees(Employee emp)
        {
            int res = 0;
            var model = db.Employees.Where(x => x.Id == emp.Id).SingleOrDefault();
            if (model != null)
            {
                model.Name = emp.Name;
                model.City = emp.City;
                model.Salary = emp.Salary;
                res = db.SaveChanges();
            }
            return res;
        }
        public int DeleteEmployee(int id)
        {
            int res = 0;
            var model = db.Employees.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                db.Employees.Remove(model);
                res = db.SaveChanges();
            }
            return res;
        }

    }

}
