using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic Constraint
    //class  :referans tip olur demek 
    //new() işlemi  yapabilir
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //Tekrarlayan işlemleri tek bir yerden çekiyoruz 

        List<T> GetAll(Expression<Func<T,bool>> filter=null); //select
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); //insert
        void Update(T entity);
        void Delete(T entity);

        //Yukarıdaki expression yapısıı ile aşağıdaki kodu sağlayabiliriz.
        //List<T> GetAllByCategory(int categoryId);
    }
}
