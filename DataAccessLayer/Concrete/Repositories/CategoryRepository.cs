using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

        Context c = new Context();
        DbSet<Category> _object;
        public void Delete(Category ct)
        {
            _object.Remove(ct);
            c.SaveChanges();
        }

        public void Insert(Category ct)
        {
            _object.Add(ct);
            c.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public void Update(Category ct)
        {
            c.SaveChanges();
        }
    }
}
