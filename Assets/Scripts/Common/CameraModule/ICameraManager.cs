using Common.ActorModule.Components;

namespace Common.CameraModule
{
    public interface ICameraManager
    {
        IActor GameCamera { get; }

        void SetGameCamera(IActor camera);
    }
}