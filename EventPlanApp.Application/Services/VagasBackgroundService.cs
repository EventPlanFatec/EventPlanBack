using EventPlanApp.Application.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class VagasBackgroundService : BackgroundService
{
    private readonly VagasMonitorService _vagasMonitorService;

    public VagasBackgroundService(VagasMonitorService vagasMonitorService)
    {
        _vagasMonitorService = vagasMonitorService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _vagasMonitorService.MonitorarVagasAsync();
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); 
        }
    }
}
