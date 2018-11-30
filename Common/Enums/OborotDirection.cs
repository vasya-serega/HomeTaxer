using System.Runtime.Serialization;

namespace HomeTaxer.Common.Enums
{
    [DataContract]
    public enum OborotDirection
    {
        [EnumMember]
        Costs = 1,  // Витрати

        [EnumMember]
        Incomes = 2 // Доходи
    }
}
