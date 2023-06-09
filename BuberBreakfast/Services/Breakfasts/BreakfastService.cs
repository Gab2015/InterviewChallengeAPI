using BuberBreakfast.Models;
using BuberBreakfast.Models.Persistence;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    //private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
    private readonly BuberBreakfastDbContext _dbContext;

    public BreakfastService(BuberBreakfastDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        //_breakfasts.Add(breakfast.Id, breakfast);
        _dbContext.Add(breakfast);
        _dbContext.SaveChanges();
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        //_breakfasts.Remove(id);
        var breakfast = _dbContext.breakfasts.Find(id);
        if (breakfast is null)
        {
            return Errors.Breakfast.NotFound;
        }
        _dbContext.Remove(breakfast);
        _dbContext.SaveChanges();
        return Result.Deleted;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_dbContext.breakfasts.Find(id) is Breakfast breakfast)
        {
            return breakfast;
        }

        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast)
    {
        //var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
        //_breakfasts[breakfast.Id] = breakfast;

        var isNewlyCreated = _dbContext.breakfasts.Find(breakfast.Id) is not Breakfast dbBreakfast;
        if (isNewlyCreated) 
        {
            _dbContext.breakfasts.Add(breakfast);
        }
        else
        {
            _dbContext.breakfasts.Update(breakfast);
        }
        _dbContext.SaveChanges();
        return new UpsertedBreakfast(isNewlyCreated);
    }
}
