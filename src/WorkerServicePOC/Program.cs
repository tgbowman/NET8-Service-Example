using WorkerServicePOC;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ScopedBackgroundService>();
builder.Services.AddScoped<TestVisitPaymentService>();

var host = builder.Build();
host.Run();
