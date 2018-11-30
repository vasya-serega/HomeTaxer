using System;
using System.Runtime.Serialization;

namespace HomeTaxer.Common.Schemas
{
    [DataContract]
    public class Oborot
    {
        [DataMember]
        public int? OborotId;

        [DataMember]
        public DateTime Date;

        [DataMember]
        public int AccountNameId;

        [DataMember]
        public int CategoryId;

        [DataMember]
        public string Category;

        [DataMember]
        public int? SubCategoryId;

        [DataMember]
        public string SubCategory;

        [DataMember]
        public double Count;

        [DataMember]
        public decimal Summa;

        [DataMember]
        public int CurrencyId;

        [DataMember]
        public string Currency;

        [DataMember]
        public string Note;
    }
}
