namespace Common.TickModule
{
    public interface ITickManager
    {
        void Initialize();
        
        void AddTick(object owner, ITickUpdate tick);
        void AddTick(object owner, ITickLateUpdate tick);
        void AddTick(object owner, ITickFixedUpdate tick);
        void RemoveTick(ITickUpdate tickUpdate);
        void RemoveTick(ITickLateUpdate tickUpdate);
        void RemoveTick(ITickFixedUpdate tickUpdate);
    }
}