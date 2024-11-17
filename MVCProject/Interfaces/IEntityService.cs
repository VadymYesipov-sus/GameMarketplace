namespace MVCProject.Interfaces
{
    public interface IEntityService<TEntity>
    {
        Task<TEntity?> GetByIdAsync(int id);
    }
}
