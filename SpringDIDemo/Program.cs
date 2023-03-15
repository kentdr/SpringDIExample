
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Spring.Context.Support;
using Spring.Extensions.DependencyInjection;

using SpringDIDemo;


// Simulate a parent context from legacy code.
var parentContext = new XmlApplicationContext("file://objects.xml");


var hostBuilder = Host.CreateDefaultBuilder(args);
// SpringServiceProviderFactory can take a parent context as a parameter if your legacy code already has a context that you can grab.
// This line tells the generic host to use your supplied service provider (Spring) instead of the default.
hostBuilder.UseServiceProviderFactory(new SpringServiceProviderFactory(parentContext))
  .UseConsoleLifetime()
  .UseNServiceBus(config =>
  {
      var endpointConfig = new EndpointConfiguration("SpringEndpoint");
      endpointConfig.UseTransport(new LearningTransport());

      return endpointConfig;
  })
  .ConfigureServices(services =>
  {
    services.AddHostedService<Worker>();
  });

await hostBuilder.RunConsoleAsync();