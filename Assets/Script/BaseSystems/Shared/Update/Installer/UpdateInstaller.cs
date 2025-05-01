using GameSystems.Shared.SystemBase;

namespace GameSystems.Shared.Interfaces.Installer 
{
    public class UpdateInstaller : BaseInstaller<IUpdateManager>
    {
        public static IUpdateManager UpdateManager { get; private set; }
        public override IUpdateManager CreateSystem()
        {
            UpdateManager = new UpdateManager();
            return UpdateManager;
        }


        protected void Update()
        {
            UpdateManager?.Update();
        }
        protected void LateUpdate()
        {
            UpdateManager?.LateUpdate();
        }
        protected void FixedUpdate()
        {
            UpdateManager?.FixedUpdate();
        }
    }
}