using MovieApp.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> GetEntities();
    }
}
