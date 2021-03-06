﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DragonCon.Modeling.Models.Identities;

namespace DragonCon.Logical
{
    public static class IdentityResults
    {
        public class SignIn
        {
            public bool IsSuccess { get; set; }
            public string Details { get; set; }

            public static SignIn Fail(string details = null) => new SignIn
            {
                IsSuccess = false,
                Details = details
            };

            public static SignIn Success(string details = null) => new SignIn
            {
                IsSuccess = true,
                Details = details
            };

        }

        public class Password
        {
            public bool IsSuccess { get; set; }
            public bool IsLongTerm { get; set; }
            public string Token { get; set; }
            public string[] Errors { get; set; }
        }
    }

    public interface IIdentityFacade
    {
        Task<LongTermParticipant> GetUserByUsernameAsync(string username);
        Task<LongTermParticipant> GetUserByUserIdAsync(string id);

        Task<IdentityResults.Password> UpdateParticipant(LongTermParticipant user);

        Task<IdentityResults.Password> AddNewParticipant(IParticipant user, string password = "");
        Task<IdentityResults.Password> GeneratePasswordResetTokenAsync(LongTermParticipant user);
        Task<IdentityResults.Password> ChangePasswordAsync(LongTermParticipant user, string currentPassword, string newPassword);
        Task<IdentityResults.Password> SetPasswordAsync(LongTermParticipant user, string newPassword);
        Task<IdentityResults.Password> ResetPasswordAsync(LongTermParticipant user, string token, string newPassword);

        Task<IdentityResults.SignIn> LoginAsync(string username, string password, bool rememberMe);
        Task<IdentityResults.SignIn> HasUserWithEmail(string userEmail);
        
        Task LogoutAsync(string username);
    }
}
