using ExpensesControl.DataModelManager.Enums;
using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Services.IServices;

public abstract class MovementAbsService
{
    /// <summary>
    /// This methods generates a new MovementModel. Is intended to be use by the derived classes to create movements
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="movementType"></param>
    /// <param name="applicationDate"></param>
    /// <param name="tracker"></param>
    /// <returns></returns>
    protected MovementModel MovementModelGenerator(decimal amount,
        MovementType movementType,
        DateTime? applicationDate = null,
        Guid? tracker = null)
    {
        var now = DateTime.Now;
        var movement = new MovementModel()
        {
            Active = true,
            Amount = amount,
            LastUpdatedDate = now,
            Type = movementType,
            CreatedDate = now,
            MovementTracker = tracker ?? Guid.NewGuid(),
            ApplicationDate = applicationDate ?? now
        };
        return movement;
    }
}