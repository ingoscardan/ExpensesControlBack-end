using AutoMapper;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb.Entities;

namespace ExpensesControl.Rdb;

public class ModelToEntityMappers : Profile
{
    public ModelToEntityMappers()
    {
        CreateMap<BucketEntity, BucketModel>();
    }
}