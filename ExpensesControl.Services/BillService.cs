using AutoMapper;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb;
using ExpensesControl.Rdb.Entities;
using ExpensesControl.Services.IServices;

namespace ExpensesControl.Services;

public class BillService : IBillService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public BillService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public IEnumerable<BillModel> Get()
    {
        return _mapper.Map<IEnumerable<BillEntity>, IEnumerable<BillModel>>(_unitOfWork.BillsRepository.Get());
    }

    public BillModel Get(object id)
    {
        return _mapper.Map<BillEntity, BillModel>(_unitOfWork.BillsRepository.GetById(id));
    }

    public BillModel Create(BillModel model)
    {
        var entity = _mapper.Map<BillModel, BillEntity>(model);
        return _mapper.Map<BillEntity, BillModel>(_unitOfWork.BillsRepository.Insert(entity));
    }

    public BillModel Update(BillModel model)
    {
        var entity = _mapper.Map<BillModel, BillEntity>(model);
        entity = _unitOfWork.BillsRepository.Update(entity);
        return _mapper.Map<BillEntity, BillModel>(entity);
    }

    public void Delete(object id)
    {
        throw new NotImplementedException();
    }

    public void Delete(BillModel model)
    {
        throw new NotImplementedException();
    }

    public void Pay(int billId, MovementModel payment)
    {
        throw new NotImplementedException();
    }
}