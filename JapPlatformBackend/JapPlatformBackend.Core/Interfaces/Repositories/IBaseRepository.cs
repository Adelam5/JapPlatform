using JapPlatformBackend.Common;
using JapPlatformBackend.Common.Response;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TInsert, TUpdate, TDto>
        where TEntity : class
    {
        Task<TDto> GetById(int id, string includes = "");
        Task<PagedResponse<List<TDto>>> List(BaseSearch search);
        Task<List<TDto>> GetAll(string includes = "");
        Task<TDto> Create(TInsert entity);
        Task<TDto> Update(int id, TUpdate entity);
        Task<List<TDto>> Delete(int id, string includes = "");
    }
}
