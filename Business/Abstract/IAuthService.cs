using Core.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult<User> Register(UserRegisterDto userRegisterDto, string password);
        IResult<User> Login(UserLoginDto userLoginDto);
        IResult<User> UserExists(string email);
        IResult<AccessToken> CreateAccessToken(User user);
    }
}
