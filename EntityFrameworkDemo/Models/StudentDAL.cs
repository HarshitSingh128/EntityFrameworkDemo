using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class StudentDAL
    {
        ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Student> GetStudents()
        {
            //lambda exp
            //return db.Employees.ToList();
            var model = (from std in db.Stud
                         select std).ToList();
            return model;

        }

        public Student GetStudentById(int id)
        {

            var model = db.Stud.Where(x => x.Sid == id).SingleOrDefault();
            return model;
        }

        public int AddStudent(Student st)
        {
            int res = 0;
            db.Stud.Add(st);
            res = db.SaveChanges();
            return res;
        }
        public int EditStudents(Student st)
        {
            int res = 0;
            var model = db.Stud.Where(x => x.Sid == st.Sid).SingleOrDefault();
            if (model != null)
            {
                model.Sname = st.Sname;
                model.Sage= st.Sage;
                model.Semail=st.Semail;
                res = db.SaveChanges();
            }
            return res;
        }
        public int DeleteStudent(int id)
        {
            int res = 0;
            var model = db.Stud.Where(x => x.Sid == id).SingleOrDefault();
            if (model != null)
            {
                db.Stud.Remove(model);
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
