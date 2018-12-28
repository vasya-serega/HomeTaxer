using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HomeTaxer.Common.Model
{
    [DataContract]
    public class SubCategory
    {
        public SubCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }
    }
}
