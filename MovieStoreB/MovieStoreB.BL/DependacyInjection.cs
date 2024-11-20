using Microsoft.Extensions.DependencyInjection;
using MovieStoreB.BL.Interfaces;
using MovieStoreB.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.BL
{
    public static class DependacyInjection
    {
        public static IServiceCollection AddBL (this IServiceCollection service)
        {
            service.AddSingleton<IMovieService,MovieRepository>();
            
        }
    }
}
