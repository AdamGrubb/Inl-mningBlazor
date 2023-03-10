

namespace HorrorFlux.Membership.Database.Services;

public class DbService : IDbService
{
    private readonly IMapper _mapper;
    private readonly HorrorFluxContext _db;

    public DbService(HorrorFluxContext db, IMapper mapper)
    {
        _mapper = mapper;
        _db = db;
    }
    public async Task<List<TDto>> GetAsync<TEntity, TDto>() where TEntity : class, IEntity where TDto : class
    {

        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }
    public async Task<List<TDto>> GetRefAsync<TEntity, TDto>() where TEntity:class where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity =>
    await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

    public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity //Behöver den här en IEntity???
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }
    public async Task<bool> AnyAsyncReferenceTable<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class, IEntity where TDto : class

    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }

    public string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity
        => $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";

    public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity
    {
        try
        {
            var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch
        {
            throw;
        }
        return true;

    }
    public void Include<TEntity>() where TEntity : class
    {
        var propertyNames = _db.Model.FindEntityType(typeof(TEntity))?.GetNavigations().Select(e => e.Name);

        if (propertyNames is null) return;

        foreach (var name in propertyNames)
            _db.Set<TEntity>().Include(name).Load();
    }
    public async Task<TReferenceEntity> AddRefAsync<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class where TDto : class

    {
        var refentity = _mapper.Map<TReferenceEntity>(dto);
        await _db.Set<TReferenceEntity>().AddAsync(refentity);
        return refentity;
    }
    public bool DeleteRef<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class where TDto : class
    {
        try
        {
            var refentity = _mapper.Map<TReferenceEntity>(dto);
            if (refentity is null) return false;
            _db.Remove(refentity);
        }
        catch
        {
            throw;
        }
        return true;
    }
}

