using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using HomeTaxer.Client.HomeTaxesReference;

namespace HomeTaxer.Client.Model
{
    public class TempCategory
    {
        private readonly List<TempSubCategory> _subCategories = new List<TempSubCategory>();

        public TempCategory(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            _subCategories.AddRange(category.SubCategories.Select(sc => new TempSubCategory(sc)));
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
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsModified { get; set; }

        public bool IsDeleted { get; set; }

        public List<TempSubCategory> SubCategories => _subCategories;
    }
}
