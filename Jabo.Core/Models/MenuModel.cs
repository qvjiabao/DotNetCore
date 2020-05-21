using Jabo.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.Models
{
    [Table("YX_Menu")]
    public class MenuModel
    {
        [Key]
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string Target { get; set; }
        public string Icon { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
