using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UserPreferences
    {
        public int UserId { get; set; }
        public string EventType { get; set; }
        public string Location { get; set; }
        public string PriceRange { get; set; }
    }
}
