using Jabo.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Models
{
    [Table("YX_Users")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string RoleCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
