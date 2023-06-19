using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Common;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Entities.Base;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace JapPlatformBackend.Repositories
{
    public class BaseRepository<TEntity, TInsert, TUpdate, TDto> : IBaseRepository<TEntity,
        TInsert, TUpdate, TDto>
        where TEntity : class
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public virtual int DefaultPageSize { get; set; } = 5;

        public BaseRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public virtual async Task<TDto> GetById(int id, string includes = "")
        {
            var entity = await GetByIdWithIncludes(id, includes);

            return mapper.Map<TDto>(entity);
        }

        public async Task<PagedResponse<List<TDto>>> List(BaseSearch search)
        {
            var query = context.Set<TEntity>().AsQueryable();

            AddFilter(search, ref query);

            AddOrder(search, ref query);

            var pages = (int)Math.Ceiling((double)query.Count() / search.PageSize);

            AddPaging(search, ref query);

            if (!string.IsNullOrEmpty(search.Includes))
            {
                AddIncludes(search.Includes, ref query);
            }

            return new PagedResponse<List<TDto>>
            {
                Data = await query.Select(q => mapper.Map<TDto>(q)).ToListAsync(),
                Pages = pages,
            };
        }

        public async Task<List<TDto>> GetAll(string includes = "")
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(includes))
            {
                AddIncludes(includes, ref query);
            }

            return await query.Select(q => mapper.Map<TDto>(q)).ToListAsync();

        }

        public virtual async Task<TDto> Create(TInsert entity)
        {
            var insert = mapper.Map<TEntity>(entity);

            context.Set<TEntity>().Add(insert);

            await context.SaveChangesAsync();

            return mapper.Map<TDto>(insert);
        }

        public virtual async Task<TDto> Update(int id, TUpdate entity)
        {
            var dbEntity = await context.Set<TEntity>().FindAsync(id) as AuditableEntity
               ?? throw new ResourceNotFound(typeof(TEntity).Name);

            dbEntity = mapper.Map(entity, dbEntity);

            dbEntity.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();

            return mapper.Map<TDto>(dbEntity);
        }

        public virtual async Task<List<TDto>> Delete(int id, string includes = "")
        {
            var entity = await GetByIdWithIncludes(id, includes);

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return await context.Set<TEntity>().Select(e => mapper.Map<TDto>(e)).ToListAsync();
        }

        protected virtual void AddIncludes(string includes, ref IQueryable<TEntity> query)
        {

            var includesArray = includes.Split(", ");

            query = includesArray.Aggregate(query, (current, include) => current.Include(include));

        }

        protected virtual void AddFilter(BaseSearch search, ref IQueryable<TEntity> query)
        {
            var nonStringFields = "birthDate, workHours";

            if (!string.IsNullOrWhiteSpace(search.Filter) && !string.IsNullOrWhiteSpace(search.Value))
            {
                if (search.Filter == "status")
                {
                    query = query.Where(search.Filter + $"= \"{search.Value}\"");
                }
                else if (nonStringFields.Contains(search.Filter))
                {
                    query = query.Where(String.Format("{0}.ToString().Contains(@0)", search.Filter), search.Value);
                }
                else
                {
                    query = query.Where(search.Filter + ".Contains(@0)", search.Value);
                };
            };
        }

        protected virtual void AddOrder(BaseSearch search, ref IQueryable<TEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(search.Sort))
            {
                query = query.OrderBy(search.Sort);
            }
        }

        protected virtual void AddPaging(BaseSearch search, ref IQueryable<TEntity> query)
        {
            var pages = (int)Math.Ceiling((double)query.Count() / search.PageSize);
            query = query.Page(search.Page, search.PageSize);
        }

        private async Task<TEntity> GetByIdWithIncludes(int id, string includes)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(includes))
            {
                AddIncludes(includes, ref query);
            }

            query = query.Where($"Id == \"{id}\"");

            var entity = await query.FirstOrDefaultAsync()
                ?? throw new ResourceNotFound(typeof(TEntity).Name);

            return entity;
        }

    }
}
