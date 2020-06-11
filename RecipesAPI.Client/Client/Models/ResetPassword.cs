﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace RecipesAPI.Client.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class ResetPassword
    {
        /// <summary>
        /// Initializes a new instance of the ResetPassword class.
        /// </summary>
        public ResetPassword() { }

        /// <summary>
        /// Initializes a new instance of the ResetPassword class.
        /// </summary>
        public ResetPassword(string userId, string resetToken, string password)
        {
            UserId = userId;
            ResetToken = resetToken;
            Password = password;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "resetToken")]
        public string ResetToken { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (UserId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "UserId");
            }
            if (ResetToken == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ResetToken");
            }
            if (Password == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Password");
            }
            if (this.UserId != null)
            {
                if (this.UserId.Length < 1)
                {
                    throw new ValidationException(ValidationRules.MinLength, "UserId", 1);
                }
            }
            if (this.ResetToken != null)
            {
                if (this.ResetToken.Length < 1)
                {
                    throw new ValidationException(ValidationRules.MinLength, "ResetToken", 1);
                }
            }
            if (this.Password != null)
            {
                if (this.Password.Length < 1)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Password", 1);
                }
            }
        }
    }
}