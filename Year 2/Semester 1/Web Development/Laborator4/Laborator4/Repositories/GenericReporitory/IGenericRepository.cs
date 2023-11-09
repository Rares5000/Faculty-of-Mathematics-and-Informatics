using Laborator4.Models.Base;

namespace Laborator4.Repositories.GenericReporitory
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Get all data
        Task<List<TEntity>> GetAllAsync();

        //Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        
        //Delete
        void Delete(TEntity entity);
        void DeleteRange(TEntity entity);
        
        //Find
        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);

        //Save
        bool Save();
        Task SaveAsync();
    }
}
