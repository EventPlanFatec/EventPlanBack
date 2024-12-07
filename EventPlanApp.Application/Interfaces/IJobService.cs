namespace EventPlanApp.Application.Interfaces
{
    public interface IJobService
    {
        Task MigrateEventosAsync();
    }
}
