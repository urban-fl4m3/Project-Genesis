using Common.Logger;

namespace Common.InstallationModule
{
    public class GameBootstrap : IGameBootstrap
    {
        private readonly ILogger _logger;

        public GameBootstrap(ILogger logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            _logger.Log("Installation Module", "Bootstrap start running...");
        }
    }
}