using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal
    {
        //CRUD
        List<Category> List();

        void Insert(Category ct);

        void Update(Category ct);

        void Delete(Category ct);


    }
}
