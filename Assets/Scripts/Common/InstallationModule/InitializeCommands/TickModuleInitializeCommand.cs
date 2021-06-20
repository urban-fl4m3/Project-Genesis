using Common.Commands;
using Common.TickModule;

namespace Common.InstallationModule.InitializeCommands
{
    public class TickModuleInitializeCommand : Command
    {
        private readonly ITickManager _tickManager;

        public TickModuleInitializeCommand(ITickManager tickManager)
        {
            _tickManager = tickManager;
        }
        
        public override void Execute()
        {
            _tickManager.Initialize();
            CompleteCommand();
        }
    }
}