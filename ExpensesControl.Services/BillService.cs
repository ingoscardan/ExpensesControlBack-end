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
        if (result != null) return _mapper.Map<BillEntity, BillModel>(result);
        return model;
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
        if (billEntity != null) return _mapper.Map<BillEntity, BillModel>(billEntity);
        return model;
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
        endDate ??= DateTime.Now;
        var result = await _unitOfWork.BillsRepository.GetAsync(b => b.Active && b.DueDate >= startDate && b.DueDate <= endDate);
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

    public string Charge(BillModel model, MovementModel movement)
    {
        throw new NotImplementedException();
    }

    public Task<string> ChargeAsync(BillModel model, MovementModel movement)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Pay(BillModel model, BucketModel bucket, MovementModel movement)
    {
        var modelEntity = await _unitOfWork.BillsRepository.GetByIdAsync(model.Id);
        if (modelEntity == null)
        {
            throw new ArgumentException("The model doesn't exists");
        }
        model = _mapper.Map<BillEntity, BillModel>(modelEntity);
        
        var bucketEntity = _unitOfWork.BucketsRepository.GetById(bucket.Id);
        if (bucketEntity == null)
        {
            throw new ArgumentException("Bucket doesn't exists");
        }
        bucket = _mapper.Map<BucketEntity, BucketModel>(bucketEntity);
        
        var now = DateTime.Now;
        var trackerId = Guid.NewGuid();
        
        var chargeToBucketMovement = new MovementModel()
        {
            Active = true,
            Amount = movement.Amount,
            Type = MovementType.Charge,
            MovementTracker = trackerId,
            ApplicationDate = movement.ApplicationDate,
            CreatedDate = now,
            LastUpdatedDate = now
        };
        
        // Validate the charge
        if (bucket.Balance < movement.Amount)
        {
            throw new ArgumentException("Not enough to charge the bucket");
        }
        
        // Create the movement in the db by creating the relation between the bill and the movement
        chargeToBucketMovement = _unitOfWork.BillsMovementsRepository.PayBill(model, chargeToBucketMovement);
        
        // Create the payment
        
        // Validate the payment
        
        // Return the tracker as a string
        
        throw new NotImplementedException();
    }

    public Task<string> PayAsync(BillModel model, MovementModel movement)
    {
        throw new NotImplementedException();
    }
}