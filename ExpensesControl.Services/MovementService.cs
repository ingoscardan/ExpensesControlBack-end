using System.Diagnostics.CodeAnalysis;
using ExpensesControl.DataModelManager.Enums;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb;
using ExpensesControl.Services.IServices;

namespace ExpensesControl.Services;

public class MovementService : MovementAbsService, IMovementService
{
    private readonly UnitOfWork _unitOfWork;
    public MovementService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public MovementModel ChargeBucket(BucketModel bucket,
        decimal amount,
        DateTime? applicationDate = null,
        Guid? tracker = null)
    {
        var chargeMovement = MovementModelGenerator(amount, MovementType.Charge, applicationDate, tracker);
        var now = chargeMovement.CreatedDate;

        if (bucket.Balance < amount)
        {
            throw new InvalidOperationException(
                $"Not enough balance(${bucket.Balance}) in the bucket to apply the charge of ${amount}");
        }
        
        // TODO: Validates no same movement has been created within the previous 3 minutes
        var threeMinutesBeforeNow = now.AddMinutes(-3);
        
        return chargeMovement;
    }

    public MovementModel PayBucket(BucketModel bucket, decimal amount, DateTime? applicationDate = null, Guid? tracker = null)
    {
        throw new NotImplementedException();
    }

    public MovementModel PayBill(BillModel bill, BucketModel bucket, decimal amount, DateTime? applicationDate = null, Guid? tracker = null)
    {
        // Charge validations
        var chargeMovement = MovementModelGenerator(amount, MovementType.Charge, applicationDate, tracker);
        var now = chargeMovement.CreatedDate;
        if (bucket.Balance < amount)
        {
            throw new InvalidOperationException(
                $"Not enough balance(${bill.Balance}) in the bucket to pay the bill of ${amount}");
        }
        
        var threeMinutesBeforeNow = chargeMovement.CreatedDate.AddMinutes(-3);
        // TODO: Validates no same movement has been created within the previous 3 minutes
        
        // Payment validations
        var paymentMovement = chargeMovement;
        paymentMovement.Type = MovementType.Pay;
        
        // Validates no same charge has been created within the previous 3 minutes
        if (bill.Movements.Any(m =>
                m.Active && m.Amount == amount && m.ApplicationDate == applicationDate &&
                m.CreatedDate > threeMinutesBeforeNow))
        {
            throw new InvalidOperationException("A similar payment has been created in the last 3 minutes");
        }
        
        // Validates no repeated payment has been created
        if (bill.Movements.Any(m =>
                m.Active &&
                m.Amount == amount &&
                m.ApplicationDate == applicationDate &&
                m.Type == MovementType.Pay))
        {
            throw new InvalidOperationException("Duplicated payment");
        }

        return chargeMovement;
    }
    
    /// <summary>
    /// Searches within the database the movements that have the same characteristics like:
    /// Application Date
    /// Amount
    /// Type
    /// </summary>
    /// <param name="movement"></param>
    /// <returns></returns>
    protected bool ValidateMovement(MovementModel movement)
    {
        // TODO: Pending to implement due lack of repository for movements
        return true;
    }
}
