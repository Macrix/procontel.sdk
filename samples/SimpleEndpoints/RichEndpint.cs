using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "Rich", SupportedRoles = SupportedRoles.Provider)]
  public class RichEndpint
  {
    private readonly ILogger _logger;
    private readonly IMessageBus _messageBus;
    private readonly IConfigurationReader _configurationReader;
    private readonly IRuntimeContext _runtimeContext;
    
    public RichEndpint(
      ILogger logger,
      IMessageBus messageBus,
      IConfigurationReader configurationReader,
      IRuntimeContext runtimeContext)
    {
      _logger = logger;
      _messageBus = messageBus;
      _configurationReader = configurationReader;
      _runtimeContext = runtimeContext;
    }
  }
}
