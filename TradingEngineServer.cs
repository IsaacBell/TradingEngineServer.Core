﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingEngineServer.Core.Configuration;
using TradingEngineServer.Log;

namespace TradingEngineServer.Core
{
    sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly TextLogger _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfig;

        public TradingEngineServer(TextLogger logger, IOptions<TradingEngineServerConfiguration> config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tradingEngineServerConfig = config.Value ?? throw new ArgumentNullException(nameof(config));
        }

        public Task Run(CancellationToken token) => ExecuteAsync(token);
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Info(nameof(TradingEngineServer), $"Started {nameof(TradingEngineServer)}");
            while (!stoppingToken.IsCancellationRequested) {
                // Kill server
                //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                //cancellationTokenSource.Cancel();
                //cancellationTokenSource.Dispose();
            }
            _logger.Info(nameof(TradingEngineServer), $"Stopped {nameof(TradingEngineServer)}");
            return Task.CompletedTask;
        }
    }
}
