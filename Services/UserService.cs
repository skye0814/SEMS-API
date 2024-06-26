﻿using Core.Entities;
using Core.WebModel.Request;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly ILogger<UserService> logger;
        private readonly RepositoryWrapper repository;

        public UserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILogger<UserService> logger,
            RepositoryWrapper repository
            )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.logger = logger;
            this.repository = repository;
        }

        public async Task<ApplicationUser> GetUserFromToken(string token)
        {
            try
            {
                var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var key = hmac.Key;
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(token, validations, out var tokenSecure);

                // The user ID is stored in 3rd index of the claim array. The position might change
                // if we change the creation of token in AuthenticationService.cs, always debug
                // if we want to look for the user ID claim
                var nameIdentifier = claims.Claims.ToArray()[3].Value;

                var user = await userManager.FindByIdAsync(nameIdentifier);

                return new ApplicationUser()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = userManager.GetRolesAsync(user).Result.DefaultIfEmpty("").First(),
                    SecurityStamp = null,
                    ConcurrencyStamp = null
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured in User Service: {ex.Message}");
            }
        }

        public async Task<string> InsertApplicationUser(RegisterRequest request)
        {
            try
            {
                string id = Guid.NewGuid().ToString();
                var existingUsername = await userManager.FindByNameAsync(request.UserName);

                if (existingUsername != null)
                    throw new BadRequestException("Username already exists");

                var appUser = await userManager.CreateAsync(
                    new IdentityUser()
                    {
                        Id = id,
                        UserName = request.UserName,
                        Email = request.Email
                    },
                    request.Password
                );

                if (!appUser.Succeeded)
                {
                    var errorMessage = appUser.Errors.First().Description;
                    throw new BadRequestException(errorMessage);
                }

                var createdAppUser = await userManager.FindByNameAsync(request.UserName);
                var isRoleAssigned = await AssignRole(createdAppUser.Id, "Coach");

                if (!isRoleAssigned.Succeeded)
                {
                    var errorMessage = isRoleAssigned.Errors.First().Description;
                    throw new BadRequestException(errorMessage);
                }

                var user = new ApplicationUser()
                {
                    ApplicationUserGuid = id,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName
                    //CustomerID = Guid.NewGuid().ToString(),
                };

                //await customerService.InsertCustomer(user);
                await repository.ApplicationUser.CreateApplicationUser(user);

                return createdAppUser.Id;
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }

        public async Task<IdentityResult> AssignRole(string id, string roleName)
        {
            IdentityResult? result = null;
            var errors = new List<IdentityError>();
            try
            {
                var userDb = await userManager.FindByIdAsync(id);
                var role = await roleManager.RoleExistsAsync(roleName);

                if (userDb == null)
                {
                    errors.Add(new IdentityError()
                    {
                        Code = "400",
                        Description = "User not found"
                    });
                    result = IdentityResult.Failed(errors.ToArray());
                    return result;
                }
                if (!role)
                {
                    errors.Add(new IdentityError()
                    {
                        Code = "400",
                        Description = $"The role {roleName} does not exist"
                    });
                    result = IdentityResult.Failed(errors.ToArray());
                    return result;
                }

                var userRole = await userManager.GetRolesAsync(userDb);

                if (userRole.Count != 0)
                {
                    await userManager.RemoveFromRolesAsync(userDb, userRole);
                }

                result = await userManager.AddToRoleAsync(userDb, roleName);

                if (!result.Succeeded)
                {
                    throw new Exception($"There was an error occured in UserService: {result.Errors}");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error occured in UserService: {ex.Message}");
            }
        }
    }
}
