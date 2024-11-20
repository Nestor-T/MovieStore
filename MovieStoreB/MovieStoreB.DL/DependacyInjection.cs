using Microsoft.Extensions.DependencyInjection;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.DL
{
    public static class DependacyInjection
    {
        public static IServiceCollection
            AddDataDependancies(this IServiceCollection service)
        {
            service.AddSingleton<IMovieRepository,MovieRepository>();
        }
    }
}
