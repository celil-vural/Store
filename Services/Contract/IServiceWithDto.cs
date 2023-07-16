using Entities.Contracts;

namespace Services.Contract
{
    public interface IServiceWithDto<out TEntity, TUpdateItem> where TEntity : class, IEntity, new() where TUpdateItem : IDtoUpdateItem, new()
    {
        public TEntity? AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false);
        public TUpdateItem? UpdateWithDtoForUpdate(TUpdateItem dtoUpdateItem, bool trackChanges = false);
        public TUpdateItem? GetWithDtoForUpdate(int id, bool trackChanges = false);
    }
}
