using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    /// <summary>
    /// Indicators for derived types
    /// </summary>
    [DataContract]
    public abstract class Dto
    {
        [DataMember]
        public int TypeId { get; set; }
        [DataMember]
        public string TypeName { get; set; }
    }
}
