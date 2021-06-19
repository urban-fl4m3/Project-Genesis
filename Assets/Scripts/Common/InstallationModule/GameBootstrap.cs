using System;
using Common.Commands;
using Common.InstallationModule.InitializeCommands;

namespace Common.InstallationModule
{
    public class GameBootstrap : IGameBootstrap
    {
        public event EventHandler RunCompleted;
        
        private readonly LoggerInitializeCommand _loggerInitializeCommand;
        
        private readonly ICommandQueue _initializer = new CommandQueue();

        public GameBootstrap(LoggerInitializeCommand loggerInitializeCommand)
        {
            _loggerInitializeCommand = loggerInitializeCommand;
        }

        public void Run()
        {
            _initializer.Add(_loggerInitializeCommand);
            
            _initializer.OnComplete += InitializerOnOnComplete;
            _initializer.ExecuteAll();
        }

        private void InitializerOnOnComplete(object sender, EventArgs e)
        {
            _initializer.OnComplete -= InitializerOnOnComplete;
            RunCompleted?.Invoke(this, e);
        }
    }
}