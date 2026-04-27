using PCBuilder.Services.IdentityServiceAPI.Data;
using PCBuilder.Services.IdentityServiceAPI.DTOs;
using PCBuilder.Services.IdentityServiceAPI.Interfaces;
using PCBuilder.Services.IdentityServiceAPI.JWT;
using PCBuilder.Services.IdentityServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PCBuilder.Services.IdentityServiceAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IdentityDbContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            IUserRepository userRepository,
            IdentityDbContext context,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            if (request.Password != request.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("User with this email already exists.");

            var customerRole = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == "User" || r.Name == "Customer");

            if (customerRole == null)
                throw new Exception("User role not found.");

            var user = new IdentityUser
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                IsActive = true,
                Balance = 15000m,
                CreatedAt = DateTime.UtcNow
            };

            user.UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = customerRole.Id,
                Role = customerRole
            });

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                User = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Balance = user.Balance,
                    Roles = roles
                }
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("Invalid email or password.");

            var passwordIsValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!passwordIsValid)
                throw new Exception("Invalid email or password.");

            if (!user.IsActive)
                throw new Exception("User account is inactive.");

            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                User = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Balance = user.Balance,
                    Roles = roles
                }
            };
        }
            public async Task<CurrentUserResponseDto> GetCurrentUserAsync(string userId)
            {
                if (!Guid.TryParse(userId, out var id))
                {
                    return null;
                }

                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return null;
                }

                return new CurrentUserResponseDto
                {
                    Id = user.Id.ToString(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email ?? string.Empty,
                    Balance = user.Balance
                };
            }
        }
    }