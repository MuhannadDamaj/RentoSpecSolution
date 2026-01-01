using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class AuthenticateResponse
    {
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
        public string Session { get; set; }
    }
}
