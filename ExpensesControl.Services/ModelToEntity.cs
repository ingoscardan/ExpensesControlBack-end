using AutoMapper;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb.Entities;

namespace ExpensesControl.Services;

public class ModelToEntity : Profile
{
    public ModelToEntity()
    {
        CreateMap<BillModel, BillEntity>();
        CreateMap<BillEntity,BillModel>();
    }
}