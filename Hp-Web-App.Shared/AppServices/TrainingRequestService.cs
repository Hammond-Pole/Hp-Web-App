using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;

/// <summary>
/// Service for handling training request operations.
/// </summary>
public interface ITrainingRequestService
{
    /// <summary>
    /// Creates a new training request.
    /// </summary>
    /// <param name="trainingRequest">The training request data.</param>
    /// <returns>The created training request.</returns>
    Task<TrainingRequestModel> CreateRequestAsync(TrainingRequestModel trainingRequest);
}

/// <summary>
/// Service implementation for handling training request operations.
/// </summary>
public class TrainingRequestService : ITrainingRequestService
{
    private readonly DbWebAppContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="TrainingRequestService"/> class.
    /// </summary>
    /// <param name="context">The web app database context.</param>
    public TrainingRequestService(DbWebAppContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public async Task<TrainingRequestModel> CreateRequestAsync(TrainingRequestModel trainingRequest)
    {
        if (trainingRequest is null) throw new ArgumentNullException(nameof(trainingRequest));

        try
        {
            _context.Add(trainingRequest);
            await _context.SaveChangesAsync();

            return trainingRequest;
        } 
        catch(Exception ex)
        {
            throw new Exception("Error creating training request. See inner exception.", ex);
        }
    }
}