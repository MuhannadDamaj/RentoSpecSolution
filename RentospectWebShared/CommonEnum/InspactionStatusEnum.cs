using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.CommonEnum
{
    public enum InspactionStatusEnum
    {
        [Description("T&C Required")]
        TAndCRequired = 0,
        [Description("Pending")]
        Pending = 1,
        [Description("Ready")]
        Ready = 2,
        [Description("Signature Required")]
        SignatureRequired = 3,
        [Description("Done")]
        Done = 4,
    }
}
