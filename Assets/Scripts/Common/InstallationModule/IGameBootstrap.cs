using System;

namespace Common.InstallationModule
{
    public interface IGameBootstrap
    {
        event EventHandler RunCompleted;
        void Run();
    }
}