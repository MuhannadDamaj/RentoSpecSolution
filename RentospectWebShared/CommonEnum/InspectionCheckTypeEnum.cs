using System.ComponentModel;

namespace RentospectShared.CommonEnum
{
    public enum InspectionCheckTypeEnum
    {
        [Description("Check IN")]
        CheckIN = 0,
        [Description("Check Out")]
        CheckOUT = 1,
        [Description("Partial Check Out")]
        PartialCheckOUT = 2
    }
}
