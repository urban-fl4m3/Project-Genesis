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

        private readonly ICommandQueue _initializer = new CommandQueue();

        public GameBootstrap(LoggerInitializeCommand loggerInitializeCommand,
            SyncThreadInitializeCommand syncThreadInitializeCommand)
        {
            _loggerInitializeCommand = loggerInitializeCommand;
            _syncThreadInitializeCommand = syncThreadInitializeCommand;
        }

        public void Run()
        {
            _initializer.Add(_loggerInitializeCommand);
            _initializer.Add(_syncThreadInitializeCommand);
            
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