using CorePackages.Entities;
using System.Linq.Expressions;


namespace CorePackages.DataAccess;

//generic constraint
//class: referans tip
public interface IEntityRepository<T> where T : class, IEntity, new()
{
    //Expression p=>p.id gibi filtrelerin yazildigi yapi.
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);

}
