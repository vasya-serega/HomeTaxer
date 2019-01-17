using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HomeTaxer.Common.Model;
using Category = HomeTaxer.Client.HomeTaxesReference.Category;

namespace HomeTaxer.Client.Model
{
    public class TempSubCategory
    {
        public TempSubCategory(KeyValuePair<int, string> subCategory)
        {
            Id = subCategory.Key;
            Name = subCategory.Value;
        }

        public TempSubCategory(int id, string name)
        {
            if (id >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "New subcategory must have negative value");
            }

            Id = id;
            Name = name;
            IsModified = true;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
