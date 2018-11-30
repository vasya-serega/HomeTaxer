using System.Collections.Generic;
using System.Runtime.Serialization;
using HomeTaxer.Common.Model;

namespace HomeTaxer.Common.Schemas
{
    [DataContract]
    public class DictOptions
    {
        [DataMember]
        public Dictionary<int, string> AccountNames = new Dictionary<int, string>();

        [DataMember]
        public List<Category> Categories = new List<Category>();

        [DataMember]
        public Dictionary<int, string> Currencies = new Dictionary<int, string>();
    }
}
