using QJB.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Models
{
    [Table("YX_JDItineraryCost")]
    public class JDItineraryCostModel
    {
        [Key]
        public int RelationId { get; set; }
        public string RelationCode { get; set; }
        public string JDItineraryCode { get; set; }
        public string CarTypeCode { get; set; }
        public string CarType { get; set; }
        public decimal Cost { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
