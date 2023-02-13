using HorrorFlux.Common.DTOs;
using HorrorFlux.Membership.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Membership.Database.Services
{
    public interface IDbService
    {
        Task<List<TDto>> GetAsync<TEntity, TDto>() where TEntity : class, IEntity where TDto : class;
        Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class;

        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;

        Task<bool> SaveChangesAsync();

        Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class, IEntity where TDto : class;

        void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto : class;

        Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
        void Include<TEntity>() where TEntity : class;

        string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
        Task<SingleFilmDTO> GetSingleFilm(int id);

    }
}
