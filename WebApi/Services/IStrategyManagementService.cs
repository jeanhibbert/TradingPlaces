using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using TradingPlaces.Server.Domain.Dtos;

namespace TradingPlaces.WebApi.Services
{
    public interface IStrategyManagementService : IHostedService
    {
        IList<string> RegisterStrategy(StrategyDetailsDto strategyDetails);
        bool UnregisterStrategy(string strategyId);
    }
}