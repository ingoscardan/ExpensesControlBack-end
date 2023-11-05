using AutoMapper;
using ExpensesControl.API.Models;
using ExpensesControl.Rdb.Entities;

namespace ExpensesControl.API.Mappers;

public class BucketEntityToCreditBucketModelMapper  : Profile
{
    public BucketEntityToCreditBucketModelMapper() => CreateMap<BucketEntity, CreditBucketModel>();
}