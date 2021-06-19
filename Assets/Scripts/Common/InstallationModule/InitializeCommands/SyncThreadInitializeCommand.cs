using Common.Commands;
using Common.SyncThreadModule;

namespace Common.InstallationModule.InitializeCommands
{
    public class SyncThreadInitializeCommand : Command
    {
        private readonly ISyncProcessor _syncProcessor;

        public SyncThreadInitializeCommand(ISyncProcessor syncProcessor)
        {
            _syncProcessor = syncProcessor;
        }
        
        public override void Execute()
        {
            _syncProcessor.Create();
            CompleteCommand();
        }
    }
}