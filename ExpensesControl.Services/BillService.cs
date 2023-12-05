using AutoMapper;
using ExpensesControl.DataModelManager.ExtensionModelMethods;
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
        model.Status = "OPEN";
        model.CreatedDate = DateTime.Now.ToUniversalTime();
        model.LastUpdatedDate = DateTime.Now.ToUniversalTime();
        model.Active = true;
        model.DueDate = model.DueDate.ToUniversalTime();
        var entity = _mapper.Map<BillModel, BillEntity>(model);
        var result = _unitOfWork.BillsRepository.Insert(entity);
        _unitOfWork.Save();
        return _mapper.Map<BillEntity, BillModel>(result);
    }

    public BillModel Update(BillModel model)
    {
        // Find the bill
        var billEntity = _unitOfWork.BillsRepository.GetById(model.Id);
        if (billEntity == null)
        {
            throw new Exception("Not found");
        }
        
        billEntity.LastUpdatedDate = DateTime.Now.ToUniversalTime();
        billEntity.Name = model.Name;
        billEntity.DashedName = model.DashedName;
        billEntity.Amount = model.Amount;
        billEntity.DueDate = model.DueDate.ToUniversalTime();
        
        billEntity = _unitOfWork.BillsRepository.Update(billEntity);
        _unitOfWork.Save();
        return _mapper.Map<BillEntity, BillModel>(billEntity);
    }

    public void Delete(object id)
    {
        throw new NotImplementedException();
    }

    public void Delete(BillModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BillModel> GetBetweenDates(DateTime startDate, DateTime? endDate)
    {
        if (endDate == null)
        {
            endDate = DateTime.Now;
        }

        var result = _unitOfWork.BillsRepository.Get(b => b.Active && b.DueDate >= startDate && b.DueDate <= endDate);
        return _mapper.Map<IEnumerable<BillEntity>, IEnumerable<BillModel>>(result);

    }

    public void ChangeName(int billId, string newName)
    {
        // Find the bill
        var billEntity = _unitOfWork.BillsRepository.GetById(billId);
        if (billEntity == null)
        {
            throw new NullReferenceException("Bill not found");
        }
        billEntity.Name = newName;
        var billModel = new BillModel()
        {
            Name = newName
        };
        billEntity.DashedName = billModel.GetDashedName();
        billEntity.LastUpdatedDate = DateTime.Now.ToUniversalTime();
        _unitOfWork.BillsRepository.Update(billEntity);
        _unitOfWork.Save();
    }

    public void ChangeAmount(int billId, decimal newAmount)
    {
        throw new NotImplementedException();
    }

    public void Pay(int billId, MovementModel payment)
    {
        throw new NotImplementedException();
    }
}