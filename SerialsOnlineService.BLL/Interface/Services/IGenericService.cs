namespace SerialsOnlineService.BLL.Interface.Services
{
    public interface IGenericService<TModel>
    {
        Task<IReadOnlyList<TModel>> GetAll(CancellationToken cancellationToken);
        Task<TModel> Insert(TModel model, CancellationToken cancellationToken);
        Task<TModel> Update(TModel model, CancellationToken cancellationToken);
        Task<TModel> Delete(int id, CancellationToken cancellationToken);
        Task<TModel> GetById(int id, CancellationToken cancellationToken);
    }
}
