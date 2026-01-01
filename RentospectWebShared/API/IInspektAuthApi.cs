using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    public interface IInspektAuthApi
    {
        [Post("/api/authenticate")]
        Task<AuthenticateResponse> Authenticate([Body] AuthenticateRequest request);
    }
}
