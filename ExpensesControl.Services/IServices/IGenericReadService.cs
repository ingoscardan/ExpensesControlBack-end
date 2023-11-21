namespace ExpensesControl.Services.IServices;

public interface IGenericReadService<TModel> where TModel : class
{
    IEnumerable<TModel> Get();
    TModel Get(object id);
}