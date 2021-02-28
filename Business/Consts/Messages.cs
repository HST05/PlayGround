using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Consts
{
    public static class Messages
    {
        public static string success = "Process Succeed !!!";
        public static string fail = "Process Failed !!!";
        public static string duplicateName = "Duplicate name has been detected";
        public static string sortLimit = "Sort limit exceed";
        public static string imageCountExceed = "Image count exceed";
        public static string authorizationDenied = "No permission";
        public static string AccessTokenCreated = "Token creation success";
        public static string UserAlreadyExists = "User already exists";
        public static string SuccessfulLogin = "Login success";
        public static string PasswordError = "Password invalid";
        public static string UserNotFound = "User not found";
        public static string UserRegistered = "User registration success";
    }
}
