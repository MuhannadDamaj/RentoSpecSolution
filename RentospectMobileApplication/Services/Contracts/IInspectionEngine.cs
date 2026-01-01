using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services.Contracts
{
    public interface IInspectionEngine
    {
        Task<string> SaveImageLocallyAsync(byte[] imageBytes, string fileName);
        Task<byte[]> ImageSourceToBytesAsync(ImageSource imageSource);
    }
}
