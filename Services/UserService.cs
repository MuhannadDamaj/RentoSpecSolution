using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class UserService
    {
        private readonly RentospectContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(RentospectContext rentospectContext
                           , IPasswordHasher<User> passwordHasher)
        {
            _context = rentospectContext;
            this._passwordHasher = passwordHasher;
        }
        public async Task<CustomApiResponce> SaveUserAsync(UserDto userDto)
        {
            if (userDto.ID == 0)
            {
                var user = new User()
                {
                    BranchID = userDto.BranchID,
                    Email = userDto.Email,
                    FullName = userDto.FullName,
                    IsActive = userDto.IsActive,
                    PhoneNumber = userDto.PhoneNumber,
                    Role = userDto.Role,
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, userDto.Password);
                _context.Users.Add(user);
            }
            else
            {
                var dbUser = await _context.Users
                                  .FirstOrDefaultAsync(user => user.ID == userDto.ID);
                if (dbUser == null)
                    return CustomApiResponce.Error("User does not exist");
                dbUser.Email = userDto.Email;
                dbUser.FullName = userDto.FullName;
                dbUser.IsActive = userDto.IsActive;
                dbUser.PasswordHash = userDto.Password;
                dbUser.PhoneNumber = userDto.PhoneNumber;
                dbUser.Role = userDto.Role;
                dbUser.BranchID = userDto.BranchID;
                dbUser.PasswordHash = _passwordHasher.HashPassword(dbUser, userDto.Password);

                _context.Users.Update(dbUser);
            }

            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<UserDto[]> GetUsersAsync() => await _context.Users.Where(cmp => cmp.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new UserDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  BranchID = c.BranchID,
                                                                                  Email = c.Email,
                                                                                  FullName = c.FullName,
                                                                                  IsActive = c.IsActive,
                                                                                  Password = c.PasswordHash,
                                                                                  Role = c.Role,
                                                                                  PhoneNumber = c.PhoneNumber
                                                                              }).ToArrayAsync();
    }
}
