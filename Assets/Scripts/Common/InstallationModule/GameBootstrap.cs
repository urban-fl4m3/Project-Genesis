using System;
using Common.Commands;
using Common.InstallationModule.InitializeCommands;

namespace Common.InstallationModule
{
    public class GameBootstrap : IGameBootstrap
    {
        public event EventHandler RunCompleted;
        
        private readonly LoggerInitializeCommand _loggerInitializeCommand;
        private readonly SyncThreadInitializeCommand _syncThreadInitializeCommand;
        private readonly TickModuleInitializeCommand _tickModuleInitializeCommand;

        private readonly ICommandQueue _initializer = new CommandQueue();

        public GameBootstrap(LoggerInitializeCommand loggerInitializeCommand,
            SyncThreadInitializeCommand syncThreadInitializeCommand,
            TickModuleInitializeCommand tickModuleInitializeCommand)
        {
            _loggerInitializeCommand = loggerInitializeCommand;
            _syncThreadInitializeCommand = syncThreadInitializeCommand;
            _tickModuleInitializeCommand = tickModuleInitializeCommand;
        }

        public void Run()
        {
            _initializer.Add(_loggerInitializeCommand);
            _initializer.Add(_syncThreadInitializeCommand);
            _initializer.Add(_tickModuleInitializeCommand);
            
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