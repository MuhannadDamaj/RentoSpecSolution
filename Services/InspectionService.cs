using Microsoft.EntityFrameworkCore;
using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
using System.Net.Sockets;

namespace RentospectWebAPI.Services
{
    public class InspectionService
    {
        private readonly RentospectContext _context;
        private readonly IWebHostEnvironment _env;

        public InspectionService(RentospectContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task SaveInspectionAsync(InspectionUploadDto dto)
        {
            var inspection = new Inspection
            {
                ID = dto.ID,
                InspectionNumber = dto.InspectionNumber,
                InspectionTypeID = dto.InspectionTypeID,
                CheckType = (InspectionCheckTypeEnum)dto.CheckType,
                UserID = dto.UserID,
                CarID = dto.CarID,
                InspectionDate = dto.InspectionDate,
                DriverName = dto.DriverName,
                DriverEmail = dto.DriverEmail,
                AgreementNumber = dto.AgreementNumber,
                CompanyID = dto.CompanyID,
                PlateNumber = dto.PlateNumber,
                Status = (InspactionStatusEnum)dto.Status,
                IsTermsAndConditionsAgreed = dto.IsTermsAndConditionsAgreed,
                SignatureBase64 = dto.SignatureBase64
            };

            var existing = await _context.Inspections
                .FirstOrDefaultAsync(i => i.ID == dto.ID);

            if (existing == null)
            {
                _context.Inspections.Add(inspection);
            }
            else
            {
                // Update existing inspection
                existing.Status = (InspactionStatusEnum)dto.Status;
                existing.SignatureBase64 = dto.SignatureBase64;
                existing.IsTermsAndConditionsAgreed = dto.IsTermsAndConditionsAgreed;
                existing.DriverName = dto.DriverName;
                existing.DriverEmail = dto.DriverEmail;
                existing.PlateNumber = dto.PlateNumber;
                existing.AgreementNumber = dto.AgreementNumber;
                _context.Inspections.Update(existing);
            }
            await _context.SaveChangesAsync();
        }

        public async Task SaveInspectionImageAsync(Guid inspectionId, IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(_env.WebRootPath, "inspectionImages", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            await _context.InspectionImages.AddAsync(new InspectionImage
            {
                ID = Guid.NewGuid(),
                InspectionID = inspectionId,
                FileName = fileName,
                FilePath = path,
                OrderIndex = 0, // You might want to set this properly
                IsActive = true,
            });

            await _context.SaveChangesAsync();
        }

        public async Task SaveInspectionImagesBulkAsync(Guid inspectionId, IFormFileCollection files, List<int> orderIndexes)
        {
            var folder = Path.Combine("wwwroot", "inspection-images", inspectionId.ToString());
            Directory.CreateDirectory(folder);

            var list = new List<InspectionImage>();

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var orderIndex = orderIndexes[i];

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(folder, fileName);

                using var stream = File.Create(filePath);
                await file.CopyToAsync(stream);

                list.Add(new InspectionImage
                {
                    ID = Guid.NewGuid(),
                    InspectionID = inspectionId,
                    FileName = fileName,
                    FilePath = filePath,
                    OrderIndex = orderIndex,
                    IsActive = true
                });
            }

            _context.InspectionImages.AddRange(list);
            await _context.SaveChangesAsync();
        }
        public async Task<InspectionImage> SaveInspectionImageBytesAsync(Guid inspectionId, string fileName, byte[] imageBytes)
        {
            // 1) Ensure folder exists
            var folderPath = Path.Combine(_env.WebRootPath, "inspectionImages");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // 2) Generate final file path
            var uniqueName = $"{Guid.NewGuid()}_{fileName}";
            var filePath = Path.Combine(folderPath, uniqueName);

            // 3) Save file to disk
            await File.WriteAllBytesAsync(filePath, imageBytes);

            // 4) Create DB record
            var entity = new InspectionImage
            {
                ID = Guid.NewGuid(),
                InspectionID = inspectionId,
                FilePath = filePath,  // store only name (better than full path)
                IsActive = true,
                FileName = uniqueName
            };

            // 5) Save to database
            _context.InspectionImages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateInspectionAIInfo(Guid inspectionId, string session, string caseID)
        {
            var insp = _context.Inspections.FirstOrDefault(insp => insp.ID.Equals(inspectionId));
            if (insp != null)
            {
                insp.InspectionNumber = session;
                insp.CaseID = caseID;
            }
            await _context.SaveChangesAsync();
        }
    }
}
