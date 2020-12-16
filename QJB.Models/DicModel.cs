using QJB.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Models
{
    [Table("YX_Dic")]
    public class DicModel
    {
        [Key]
        public int DicId { get; set; }
        public string DicCode { get; set; }
        public string DicName { get; set; }
        public string DicTypeCode { get; set; }
        public int? Sort { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
