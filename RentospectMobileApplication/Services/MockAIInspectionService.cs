
using RentospectMobileApp.Services.Contracts;
using RentospectShared.AICallReadingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public class MockAIInspectionService : IAIInspectionService
    {
        public async Task<InspectionResult> GetInspectionResultAsync()
        {
            // Simulate API response delay
            await Task.Delay(300);

            string jsonString = """
{
    "status": "Available",
    "caseId": "202508080645066036954287",
    "inspectionId": "in230120250808064506",
    "vendor": "Inspektlabs",
    "version": "2.0.1",
    "uploadStatus": "complete upload",
    "vehicleType": "car_sedan",
    "appFormData": "",
    "geoLocation": "NA",
    "vehicleReadings": {
        "odometerReading": "___",
        "vinReading": "_________________",
        "fuelMeterReading": "",
        "licensePlateReading": "6XJR450",
        "engineNumberReading": "",
        "observations": "",
        "make": "Toyota(40%)",
        "model": "Corolla(40%)",
        "subModel": "",
        "color": "silver(40%)",
        "laborHoursEstimate": 13.26
    },
    "fraudDetection": {
        "videoFraudStatus": "False",
        "videoFraudReason": "",
        "videoFraudTimestamp": ""
    },
    "preInspection": {
        "recommendationStatus": "N",
        "message": "VIN is not detected",
        "damagedParts": [
            {
                "partName": "Front Bumper",
                "listOfDamages": "scratch_or_spot, tear, stitch_or_screw",
                "damageSeverityScore": 1,
                "laborOperation": "Replace",
                "confidenceScore": 0.936,
                "paintLaborUnits": 2.59,
                "removalRefitUnits": 0.84,
                "laborRepairUnits": 0
            },
            {
                "partName": "Right Headlight",
                "listOfDamages": "crack",
                "damageSeverityScore": 0.926,
                "laborOperation": "Replace",
                "confidenceScore": 0.992,
                "paintLaborUnits": 0.0,
                "removalRefitUnits": 0.2,
                "laborRepairUnits": 0
            },
            {
                "partName": "Hood",
                "listOfDamages": "scratch_or_spot, shallow_dent",
                "damageSeverityScore": 0.452,
                "laborOperation": "Repair",
                "confidenceScore": 0.806,
                "paintLaborUnits": 2.86,
                "removalRefitUnits": 0.64,
                "laborRepairUnits": 6.13
            }
        ]
    },
    "claim": {},
    "additionalFeatures": {
        "sizeOfDamage": {},
        "highProbabilityInternalDamages": [],
        "fastTrackFlag": "",
        "windshieldDamageRegion": "",
        "hailDamage": {},
        "blending_data": {}
    },
    "relevantImages": [
        {
            "imageId": "in230120250808064506-1.PNG",
            "originalImageId": "2.PNG",
            "imageUrl": "https://inspektlabs-eu.s3.amazonaws.com/client_1556/2025/08/in230120250808064506/output_angle/in230120250808064506-1.PNG?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAWCBSHU66ECWP77MC%2F20250808%2Feu-central-1%2Fs3%2Faws4_request&X-Amz-Date=20250808T064936Z&X-Amz-Expires=604799&X-Amz-SignedHeaders=host&X-Amz-Signature=db7fddb6a595c1ef9717df9e9cd9d0444626288f4b7c0869ed52c8da19468f13",
            "originalImageURL": "https://inspektlabs-eu.s3.amazonaws.com/client_1556/2025/08/in230120250808064506/original/in230120250808064506-1.PNG?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAWCBSHU66ECWP77MC%2F20250808%2Feu-central-1%2Fs3%2Faws4_request&X-Amz-Date=20250808T064936Z&X-Amz-Expires=604799&X-Amz-SignedHeaders=host&X-Amz-Signature=7c06629e57958900c99094a98d6b0159e9c16644b0e84ba57cb1612e288bfe6f",
            "requestImageUrl": "NA",
            "qualityScore": 5,
            "blurScore": 1,
            "lumaScore": 3,
            "zoomScore": 4,
            "detectedAngle": 0,
            "imageTag": "license_plate_detected",
            "photoType": "Front",
            "boundingBoxInformation": [
                {
                    "partComponent": "Front Bumper",
                    "damageType": "scratch_or_spot",
                    "damageId": ["50010"],
                    "damageSeverityScore": 0.274,
                    "confidenceScore": 0.809,
                    "isHailDamage": 0,
                    "hailSize": "",
                    "numberOfHailDamages": "",
                    "partOrientationUncertain": 0,
                    "coordinates": {
                        "x": 211,
                        "y": 464,
                        "height": 278,
                        "width": 224
                    }
                }
            ],
            "geoLocation": "NA",
            "timeStamp": "NA",
            "imageHeight": 853,
            "imageWidth": 1280
        }
    ],
    "customSection": {},
    "totalLoss": {
        "totalLossStatus": 0,
        "totalLossScore": 37,
        "repairDecision": "Bodyshop Repair"
    },
    "document": {
        "make": "",
        "yearOfManufacture": "",
        "licenseExpiry": ""
    }
}
""";


            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<InspectionResult>(jsonString, options);
        }
    }
}
