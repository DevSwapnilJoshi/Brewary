using System.ComponentModel;

namespace EGlossary.Domain.Enum
{
    public enum Sizes : byte
    {
        [Description("S")]
        Small = 1,

        [Description("M")]
        Medium = 2,

        [Description("L")]
        Large = 3,

        [Description("XL")]
        ExtraLarge = 4,

        [Description("XXL")]
        ExtraExtraLarge = 5,

        [Description("Inch")]
        Inch = 6,
    }
}