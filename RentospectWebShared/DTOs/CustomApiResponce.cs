using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public record CustomApiResponce(bool isSuccess, string? erroMessage) 
    {
        public static CustomApiResponce Success() => new(true,null);
        public static CustomApiResponce Error(string errorMesssage) => new(false, errorMesssage);
    }
}
