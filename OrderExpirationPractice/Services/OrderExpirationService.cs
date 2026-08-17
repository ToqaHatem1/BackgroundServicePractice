
namespace OrderExpirationPractice.Services
{
    public class OrderExpirationService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public OrderExpirationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer( //instead of using -> while (true) { await Task.Delay(10000);}
                TimeSpan.FromSeconds(10));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                // check orders
            }
        }
    }
}
