using REPR_API.Models;

namespace REPR_API.Services
{
    public interface IDataService<TEntity, in TPk> where TEntity : EntityBase
    {
        Task<ResponseObject<TEntity>> GetAsync();
        Task<ResponseObject<TEntity>> GetByIdAsync(TPk id);
        Task<ResponseObject<TEntity>> CreateAsync(TEntity entity);
        Task<ResponseObject<TEntity>> UpdateAsync(TPk id, TEntity entity);
        Task<ResponseObject<TEntity>> DeleteAsync(TPk id);
    }
}
