using Jabo.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Models
{
    [Table("YX_JDItinerary")]
    public class JDItineraryModel
    {
        [Key]
        public int ItineraryId { get; set; }
        public string Departure { get; set; }
        public string Terminal { get; set; }
        public int? Mileage { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
