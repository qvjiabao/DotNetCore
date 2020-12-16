using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Shared
{
    public class JDItineraryVModel
    {
        public int itineraryId { get; set; }
        public string jDItineraryCode { get; set; }
        public string departure { get; set; }
        public string terminal { get; set; }
        public int mileage { get; set; }
        public DateTime? createDate { get; set; }
    }
}
