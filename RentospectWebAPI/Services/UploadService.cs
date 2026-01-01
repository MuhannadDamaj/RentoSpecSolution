using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using RentospectShared.API;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
using System.Collections.Generic;

namespace RentospectWebAPI.Services
{
    public static class CarClassColumns
    {
        public const string fileName = "rentospect_car_classes_template";
        public const string Name = "Name";
        public const string Description = "Description";
    }
    public static class CarColumns
    {
        public const string fileName = "rentospect_car_template";
        public const string PlateNumber = "PlateNumber";
        public const string Year = "Year";
        public const string Color = "Color";
        public const string MVA_Number = "MVA_Number";
        public const string CarMake = "CarMake";
        public const string CarModel = "CarModel";
        public const string CarClass = "CarClass";
    }

    public class UploadService
    {
        public int CompanyID;
        public UploadService(RentospectContext context)
        {
            _context = context;
        }

        public RentospectContext _context { get; }

        public async Task<UploadResultDto> UploadExcelAsync(IFormFile file, int companyID)
        {
            CompanyID = companyID;
            var result = new UploadResultDto();
            if (file == null || file.Length == 0)
            {
                result.Errors.Add("No file uploaded");
                return result;
            }
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheets.First();
            int rowCount = worksheet.LastRowUsed().RowNumber();
            int colCount = worksheet.LastColumnUsed().ColumnNumber();

            result.TotalRows = rowCount - 1; // Exclude header row

            // Read headers
            var headers = new List<string>();
            for (int col = 1; col <= colCount; col++)
                headers.Add(worksheet.Cell(1, col).GetString());
            List<Car> cars = new List<Car>();
            string fileName = Path.GetFileName(file.FileName);
            if (fileName.Replace(".xlsx", "").Equals(CarColumns.fileName))
                return await ManageUploadedCars(result, worksheet, rowCount, colCount, headers);
            if (fileName.Replace(".xlsx", "").Equals(CarClassColumns.fileName))
                return await ManageUploadedCarClasses(result, worksheet, rowCount, colCount, headers);
            result.Errors.Add($"Invalid file name");
            return result;
        }

        private async Task<UploadResultDto> ManageUploadedCars(UploadResultDto result,
                                                                IXLWorksheet worksheet,
                                                                int rowCount,
                                                                int colCount,
                                                                List<string> headers)
        {
            List<Car> cars = new List<Car>();
            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    var rowData = new Dictionary<string, string>();
                    Car car = new Car();
                    car.IsActive = true;
                    for (int col = 1; col <= colCount; col++)
                    {
                        string? header = headers[col - 1];
                        switch (header)
                        {
                            case CarColumns.PlateNumber:
                                car.PlateNumber = worksheet.Cell(row, col).GetString();
                                break;
                            case CarColumns.Year:
                                car.Year = int.Parse(worksheet.Cell(row, col).GetString());
                                break;
                            case CarColumns.Color:
                                car.Color = worksheet.Cell(row, col).GetString();
                                break;
                            case CarColumns.MVA_Number:
                                car.MVA_Number = worksheet.Cell(row, col).GetString();
                                break;
                            case CarColumns.CarMake:
                                car.CarMake = worksheet.Cell(row, col).GetString();
                                break;
                            case CarColumns.CarModel:
                                car.CarModel = worksheet.Cell(row, col).GetString();
                                break;
                            case CarColumns.CarClass:
                                car.CarClassId = GetClassIDFromName(worksheet.Cell(row, col).GetString());
                                break;
                        }
                    }
                    cars.Add(car);
                    result.SuccessRows++;
                }
                catch (Exception ex)
                {
                    result.Errors.Add($"Row {row}: {ex.Message}");
                }
            }
            await _context.AddRangeAsync(cars);
            await _context.SaveChangesAsync();
            return result;
        }
        private async Task<UploadResultDto> ManageUploadedCarClasses(UploadResultDto result,
                                                                     IXLWorksheet worksheet,
                                                                     int rowCount,
                                                                     int colCount,
                                                                     List<string> headers)
        {
            List<CarClass> carClasses = new List<CarClass>();

            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    var rowData = new Dictionary<string, string>();
                    CarClass carClass = new CarClass();
                    carClass.IsActive = true;
                    carClass.CompanyID = CompanyID;
                    for (int col = 1; col <= colCount; col++)
                    {
                        string? header = headers[col - 1];
                        switch (header)
                        {
                            case CarClassColumns.Name:
                                carClass.Name = worksheet.Cell(row, col).GetString();
                                break;
                            case CarClassColumns.Description:
                                carClass.Description = worksheet.Cell(row, col).GetString();
                                break;
                        }
                    }
                    carClasses.Add(carClass);
                    result.SuccessRows++;
                }
                catch (Exception ex)
                {
                    result.Errors.Add($"Row {row}: {ex.Message}");
                }
            }
            await _context.AddRangeAsync(carClasses);
            await _context.SaveChangesAsync();
            return result;
        }
        private int GetClassIDFromName(string className)
        {
           var carClass=  _context.CarClasses.FirstOrDefault(c => c.Name.Trim().Equals(className.Trim()) && c.IsActive);
           if(carClass == null)
                return 0;
            return carClass.ID;
            
        }

    }
}
