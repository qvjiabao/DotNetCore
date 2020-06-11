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
    }
}
