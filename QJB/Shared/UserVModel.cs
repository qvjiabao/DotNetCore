using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace QJB.Shared
{
    public class UserVModel
    {
        public string UserCode { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Sex { get; set; }

        public DateTime? CreateDate { get; set; }

        public string RoleCode { get; set; }
    }
}
