using Business.Abstract;
using Business.Consts;
using Core.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IResult<User> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return  new SuccessResult<User>(Messages.userRegistered, user);
        }

        public IResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByMail(userLoginDto.Email).Data;
            if (userToCheck==null)
            {
                return new FailResult<User>(Messages.userNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new FailResult<User>(Messages.passwordError);
            }

            return new SuccessResult<User>(Messages.successfulLogin, userToCheck);
        }

        public IResult<User> UserExists(string email)
        {
            if (_userService.GetByMail(email).Success)
            {
                return new FailResult<User>(Messages.userAlreadyExists);
            }
            return new SuccessResult<User>();
        }

        public IResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessResult<AccessToken>(Messages.accessTokenCreated, accessToken);
        }
    }
}
