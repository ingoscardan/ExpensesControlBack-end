using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Services.IServices;

public interface IGenericReadService<TModel> where TModel : class
{
    IEnumerable<TModel> Get();
    Task<BillModel> Get(object? id);
}