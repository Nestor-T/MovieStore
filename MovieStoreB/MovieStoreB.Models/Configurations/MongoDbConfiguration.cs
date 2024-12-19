using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.Models.Configurations
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatabaseName{ get; set; }
    }
}
