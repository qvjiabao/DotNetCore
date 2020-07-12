using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.ViewModels
{
    public class JDItineraryCostVModel
    {
        public int relationId { get; set; }
        public string relationCode { get; set; }
        public string jDItineraryCode { get; set; }
        public string carTypeCode { get; set; }
        public string carType { get; set; }
        public decimal Cost { get; set; }
        public DateTime? createDate { get; set; }
    }
}
