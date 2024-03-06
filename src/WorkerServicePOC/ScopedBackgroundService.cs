namespace WorkerServicePOC
{
    public sealed class ScopedBackgroundService(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<ScopedBackgroundService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var messages = new List<string>
                {
                    "message 1",
                    "message 2",
                    "message 3"
                };

                foreach (var message in messages)
                {
                    await DoWorkAsync(message);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task DoWorkAsync(string message)
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();

            var visitPaymentService = scope.ServiceProvider.GetRequiredService<TestVisitPaymentService>();
            
            var paymentProcessor = new TestScopedService(visitPaymentService);

            await paymentProcessor.ProcessPayment(message);
        }
    }
}
