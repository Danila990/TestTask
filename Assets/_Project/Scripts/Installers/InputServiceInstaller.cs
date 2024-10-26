using MyCode._Player;
using MyCode.Core;
using VContainer;
using VContainer.Unity;

namespace MyCode
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IInputService, PcInputService>(Lifetime.Singleton).As<ITickable>();
        }
    }
}