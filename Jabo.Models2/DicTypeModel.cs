using Jabo.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Models
{
    [Table("YX_DicType")]
    public class DicTypeModel
    {
        [Key]
        public int DicTypeId { get; set; }
        public string DicTypeCode { get; set; }
        public string DicTypeName { get; set; }
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
