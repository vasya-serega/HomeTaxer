using System;

namespace HomeTaxer.Client.Model.Enums
{
    public enum LineEditBoxEntity
    {
        Account,
        Category,
        SubCategory
    }

    public static class LineEditBoxEntityExtentions
    {

        public static string GetName(this LineEditBoxEntity lineEditBoxEntity)
        {
            switch (lineEditBoxEntity)
            {
                case LineEditBoxEntity.Account:
                    return "рахунку";
                case LineEditBoxEntity.Category:
                    return "категорії";
                case LineEditBoxEntity.SubCategory:
                    return "підкатегорії";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
