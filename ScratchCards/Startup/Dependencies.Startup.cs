using Microsoft.Extensions.DependencyInjection;
using ScratchCards.Interfaces;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards
{
    public partial class Startup
    {
        private void InitDependencies(IServiceCollection services)
        {
            services.AddTransient<IGameManager, SignRepository>();
        }
    }
}
