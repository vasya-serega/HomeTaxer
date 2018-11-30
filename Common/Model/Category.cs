using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HomeTaxer.Common.Model
{
    [DataContract]
    public class Category
    {
        private readonly Dictionary<int, string> _subCategories = new Dictionary<int, string>();

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public Dictionary<int, string> SubCategories
        {
            get
            {
                return _subCategories.ToDictionary(dictItem => dictItem.Key, dictItem => dictItem.Value);
            }
        }

        /// <summary>
        /// This value will not be stored into DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void AddSubCatLocally(int id, string name)
        {
            _subCategories.Add(id, name);
        }
    }
}
