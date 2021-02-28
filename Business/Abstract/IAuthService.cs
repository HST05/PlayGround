using Core.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult<User> Register(UserRegisterDto userForRegisterDto,string password);
        IResult<User> Login(UserLoginDto userForLoginDto);
        IResult<User> UserExists(string email);
        IResult<AccessToken> CreateAccessToken(User user);
    }
}
