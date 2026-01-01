using RentospectMobileApp.Entities.CustomEnitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public class InspectionHolderService
    {
        public InspectionHolderDTO CurrentInspection { get; private set; }
        public void SetInspection(InspectionHolderDTO dto)
        {
            CurrentInspection = dto;
        }
        public InspectionHolderDTO GetInspection()
        {
            return CurrentInspection;
        }
        public void Clear()
        {
            CurrentInspection = null;
        }
    }
}
