using Microsoft.Extensions.DependencyInjection;
using ScratchCards.Interfaces.Manager;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Managers;
using ScratchCards.Repository;

namespace ScratchCards
{
    public partial class Startup
    {
        private void InitDependencies(IServiceCollection services)
        {
            services.AddTransient<ISignRepository, SignRepository>();
            services.AddTransient<IGameManager, GameManager>();
            services.AddTransient<ISignManager, SignManager>();
        }
    }
}
