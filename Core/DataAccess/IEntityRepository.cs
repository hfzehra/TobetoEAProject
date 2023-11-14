using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic Constraint
    //class  :referans tip olur demek 
    //new() işlemi  yapabilir
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        

        List<T> GetAll(Expression<Func<T,bool>> filter=null); //select
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); //insert
        void Update(T entity);
        void Delete(T entity);

        //Tekrarlayan işlemleri tek bir yerden çekiyoruz 
        //Yukarıdaki expression yapısıı ile aşağıdaki kodu sağlayabiliriz.
        //List<T> GetAllByCategory(int categoryId);
    }
}
