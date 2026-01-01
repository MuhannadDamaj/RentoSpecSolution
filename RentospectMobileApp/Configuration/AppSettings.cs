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
//        public const string ApiBaseUrl = "https://localhost:7051"; // local emulator
//#else
//        public const string ApiBaseUrl = "https://localhost:7051"; // production
//#endif
#if DEBUG
        public const string ApiBaseUrl = "https://trucklingly-casklike-judah.ngrok-free.dev"; // local emulator
#else
        public const string ApiBaseUrl = "https://trucklingly-casklike-judah.ngrok-free.dev"; // production
#endif
    }
}
