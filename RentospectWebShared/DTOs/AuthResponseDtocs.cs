using System.Text.Json.Serialization;

namespace RentospectShared.DTOs
{
    public record AuthResponseDto(LoggedInUser user, string? ErrorMessage = null)
    {
        [JsonIgnore]
        public bool HasError => ErrorMessage != null;
    }
}
