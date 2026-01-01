using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Configuration
{
    public class AppSettings
    {
//#if DEBUG
//        public const string ApiBaseUrl = "https://rentospectwebapi20251111015419-e0fdgudsfxg7egdg.uaenorth-01.azurewebsites.net"; // local emulator
//#else
//        public const string ApiBaseUrl = "https://localhost:7051"; // production
//#endif
#if DEBUG
        public const string ApiBaseUrl = "https://rentospectwebapi20251111015419-e0fdgudsfxg7egdg.uaenorth-01.azurewebsites.net"; // local emulator
#else
        public const string ApiBaseUrl = "https://rentospectwebapi20251111015419-e0fdgudsfxg7egdg.uaenorth-01.azurewebsites.net"; // production
#endif
    }
}
