using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    [Headers("Authorization: Bearer ")]
    public interface IUserApi
    {
        [Post("/api/users")]
        Task<CustomApiResponce> SaveUserAsync(UserDto userDto);
        [Get("/api/users")]
        Task<UserDto[]> GetUsersAsync();
        [Get("/api/users/{id}")]
        Task<UserDto[]> GetUserByAsync(int id);
    }
}
