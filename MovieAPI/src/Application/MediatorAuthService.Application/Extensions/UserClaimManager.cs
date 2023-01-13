﻿using MovieAPI.Application.Dtos.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieAPI.Application.Extensions;

internal static class UserClaimManager
{
    public static IEnumerable<Claim> GetClaims(UserDto user, List<string> audiences)
    {
        var userList = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        userList.AddRange(audiences.Select(audience => new Claim(JwtRegisteredClaimNames.Aud, audience)));

        return userList;
    }
}