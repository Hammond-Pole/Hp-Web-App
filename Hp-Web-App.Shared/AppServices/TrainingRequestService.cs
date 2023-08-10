using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;

public interface ITrainingRequestService
{
    Task<TrainingRequestModel> CreateRequestAsync(TrainingRequestModel trainingRequest);
}

public class TrainingRequestService : ITrainingRequestService
{
    private readonly DbWebAppContext _context;

    public TrainingRequestService(DbWebAppContext context)
    {
        _context = context;
    }

    public async Task<TrainingRequestModel> CreateRequestAsync(TrainingRequestModel trainingRequest)
    {
        if (trainingRequest is null) throw new ArgumentNullException(nameof(trainingRequest));

        _context.Add(trainingRequest);
        await _context.SaveChangesAsync();
        return trainingRequest ?? new TrainingRequestModel();
    }
}