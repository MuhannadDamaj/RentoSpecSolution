using RentospectMobileApp.Entities;
using RentospectMobileApp.Entities.CustomEnitities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public class InspectionLocalService
    {
        private readonly SQLiteAsyncConnection _db;

        public InspectionLocalService(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public async Task<(Inspection, List<InspectionImage>)> SaveInspectionHolderAsync(InspectionHolderDTO holder)
        {
            if (holder?.Inspection == null)
                throw new ArgumentNullException(nameof(holder.Inspection), "Inspection cannot be null");

            // Ensure inspection ID
            if (holder.Inspection.ID == Guid.Empty)
                holder.Inspection.ID = Guid.NewGuid();

            // Save signature image path if you’re storing it locally
            if (holder.SignatureBytes != null)
            {
                holder.Inspection.SignatureBase64 = Convert.ToBase64String(holder.SignatureBytes);
                var path = Path.Combine(FileSystem.AppDataDirectory, $"{holder.Inspection.ID}_signature.png");
                File.WriteAllBytes(path, holder.SignatureBytes);
                holder.Inspection.SignaturePath = path;
                holder.Inspection.SignatureData = System.Text.Json.JsonSerializer.Serialize(holder.SignatureLines);
            }

            // Save or replace inspection
            await _db.InsertOrReplaceAsync(holder.Inspection);

            // Save photos
            List<InspectionImage> inspectionImages = new List<InspectionImage>();

            if (holder.InspectionPhotos?.Count > 0)
            {
                int imageOrder = 0;
                foreach (var photo in holder.InspectionPhotos)
                {
                    var bytes = await ImageSourceToBytesAsync(photo);
                    var photoPath = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid()}.jpg");
                    File.WriteAllBytes(photoPath, bytes);
                    var image = new InspectionImage
                    {
                        ID = Guid.NewGuid(),
                        InspectionID = holder.Inspection.ID,
                        PhotoPath = photoPath,
                        OrderIndex = imageOrder++
                    };
                    await _db.InsertAsync(image);
                    inspectionImages.Add(image);
                }
            }

            // Save damaged parts
            if (holder.DamagedParts?.Count > 0)
            {
                foreach (var part in holder.DamagedParts)
                {
                    var damage = new InspectionDamage
                    {
                        ID = Guid.NewGuid(),
                        InspectionID = holder.Inspection.ID,
                        PartName = part.PartName,
                        ListOfDamages = part.ListOfDamages,
                        DamageSeverityScore = part.DamageSeverityScore,
                        LaborOperation = part.LaborOperation,
                        ConfidenceScore = part.ConfidenceScore,
                        PaintLaborUnits = part.PaintLaborUnits,
                        RemovalRefitUnits = part.RemovalRefitUnits,
                        LaborRepairUnits = part.LaborRepairUnits
                    };

                    await _db.InsertAsync(damage);
                }
            }
            return (holder.Inspection, inspectionImages);
        }
        public async Task<(Inspection, List<InspectionImage>)> SavePrimaryInspectionAsync(InspectionHolderDTO holder)
        {
            if (holder?.Inspection == null)
                throw new ArgumentNullException(nameof(holder.Inspection), "Inspection cannot be null");

            // Ensure inspection ID
            if (holder.Inspection.ID == Guid.Empty)
                holder.Inspection.ID = Guid.NewGuid();
            // Save or replace inspection
            await _db.InsertOrReplaceAsync(holder.Inspection);

            // Save photos
            List<InspectionImage> inspectionImages = new List<InspectionImage>();

            if (holder.InspectionPhotos?.Count > 0)
            {
                int imageOrder = 0;
                foreach (var photo in holder.InspectionPhotos)
                {
                    var bytes = await ImageSourceToBytesAsync(photo);
                    var photoPath = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid()}.jpg");
                    File.WriteAllBytes(photoPath, bytes);
                    var image = new InspectionImage
                    {
                        ID = Guid.NewGuid(),
                        InspectionID = holder.Inspection.ID,
                        PhotoPath = photoPath,
                        OrderIndex = imageOrder++
                    };
                    await _db.InsertAsync(image);
                    inspectionImages.Add(image);
                }
            }
            return (holder.Inspection, inspectionImages);
        }

        public async Task UpdateInspectionAIInfoAsync(InspectionHolderDTO holder)
        {
            if (holder?.Inspection == null)
                throw new ArgumentNullException(nameof(holder.Inspection), "Inspection cannot be null");
            // Save or replace inspection
            holder.Inspection.CaseID = holder.Inspection.CaseID;
            holder.Inspection.InspectionNumber = holder.Inspection.InspectionNumber;

            await _db.InsertOrReplaceAsync(holder.Inspection);

        }
        public async Task FinishInspection(Inspection inspection)
        {

            await _db.InsertOrReplaceAsync(inspection);

        }
        private async Task<byte[]> ImageSourceToBytesAsync(ImageSource imageSource)
        {
            if (imageSource is FileImageSource fileImageSource)
            {
                return await File.ReadAllBytesAsync(fileImageSource.File);
            }
            else if (imageSource is StreamImageSource streamImageSource)
            {
                var stream = await streamImageSource.Stream(CancellationToken.None);
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return ms.ToArray();
            }

            return Array.Empty<byte>();
        }
    }
}