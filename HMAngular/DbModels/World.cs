using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMAngular.Models
{
    public class World
    {
        public int WorldID { get; set; }
        public int DataCenterID { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public bool IsLegacy { get; set; }

    }
}