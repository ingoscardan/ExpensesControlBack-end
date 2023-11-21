namespace ExpensesControl.Services.IServices;

public interface IGenericWriteService<TModel> where TModel : class
{
    TModel Create(TModel model);
    TModel Update(TModel model);
    void Delete(object id);
    void Delete(TModel model);
}