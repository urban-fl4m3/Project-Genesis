using Common.ActorModule.Components;

namespace Common.CameraModule
{
    public class CameraManager : ICameraManager
    {
        public IActor GameCamera { get; private set; }

        public CameraManager()
        {
            
        }
        
        public void SetGameCamera(IActor camera)
        {
            GameCamera = camera;
            GameCamera.Activate();
        }
    }
}