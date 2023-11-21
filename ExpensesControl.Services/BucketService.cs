using AutoMapper;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb;
using ExpensesControl.Rdb.Entities;
using ExpensesControl.Rdb.Repositories;
using ExpensesControl.Services.IServices;

namespace ExpensesControl.Services;

public class BucketService : IBucketService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public BucketService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public IEnumerable<BucketModel> Get()
    {
        var entities = _unitOfWork.BucketsRepository.Get(b => b.Active);
        return _mapper.Map<IEnumerable<BucketEntity>, IEnumerable<BucketModel>>(entities);
    }

    public BucketModel Get(object id)
    {
        return _mapper.Map<BucketEntity, BucketModel>(_unitOfWork.BucketsRepository.GetById(id));
    }

    public BucketModel Create(BucketModel model)
    {
        throw new NotImplementedException();
    }

    public BucketModel Update(BucketModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(object id)
    {
        throw new NotImplementedException();
    }

    public void Delete(BucketModel model)
    {
        throw new NotImplementedException();
    }

    public void Pay(MovementModel payment, BucketModel bucket)
    {
        throw new NotImplementedException();
    }

    public void Charge(MovementModel charge, BucketModel bucket)
    {
        throw new NotImplementedException();
    }
}