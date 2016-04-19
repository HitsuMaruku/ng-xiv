using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMAngular.Models
{
    public class Character
    {
        public int CharacterID { get; set; }
        public int WorldID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLegacy { get; set; }

    }
}