using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensores_API.Models
{
    public class SensoresDatabaseSettings : ISensoresDatabaseSettings
    {
        public string SensorCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISensoresDatabaseSettings
    {
        string SensorCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
