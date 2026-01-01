using RentospectMobileApp.Entities;
using RentospectMobileApplication.Entities.CustomEnitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.DBService.Contracts
{
    public interface IInspectionDBService
    {
        Task<List<InspectionList>> GetInspectionsAsync();
    }
}
