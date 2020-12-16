using QJB.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Models
{
    [Table("YX_RoleMenu")]
    public class RoleMenuModel
    {
        [Key]
        public int RoleMenuId { get; set; }
        public string RoleCode { get; set; }
        public string MenuCode { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
