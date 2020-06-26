using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.ViewModels
{
    [ProtoBuf.ProtoContract]
    public class UserVModel
    {
        [ProtoBuf.ProtoMember(1)]
        public string UserCode { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string UserName { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string DisplayName { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public string Phone { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public string Sex { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public DateTime? CreateDate { get; set; }
        [ProtoBuf.ProtoMember(7)]
        public string RoleCode { get; set; }
    }
}
