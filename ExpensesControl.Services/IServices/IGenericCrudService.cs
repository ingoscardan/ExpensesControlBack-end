namespace ExpensesControl.Services.IServices;

public interface IGenericCrudService<TModel> : IGenericReadService<TModel>, IGenericWriteService<TModel> where TModel: class
{
    
}