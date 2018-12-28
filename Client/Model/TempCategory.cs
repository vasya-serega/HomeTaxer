using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HomeTaxer.Client.HomeTaxesReference;

namespace HomeTaxer.Client.Model
{
    [DataContract]
    public class TempCategory : Category
    {
        public TempCategory(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            SubCategories = new Dictionary<int, string>(category.SubCategories);
        }

        public TempCategory(int id, string name)
        {
            if (id >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "New category must have negative value");
            }

            Id = id;
            Name = name;
            IsModified = true;
            SubCategories = new Dictionary<int, string>();
        }

        //public string EditableName { get; set; }
        public new string Name { get; set; }

        public bool IsModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
