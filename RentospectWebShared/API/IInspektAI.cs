using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    public interface IInspektAI
    {
        [Post("/api/upload")] // Replace with the actual AI endpoint path
        Task<AIResponse> AnalyzeCarAsync(
        [Header("Authorization")] string bearerToken,
        [Header("ngrok-skip-browser-warning")] string skip,
        [Body] AIRequest request
    );
    }
}
