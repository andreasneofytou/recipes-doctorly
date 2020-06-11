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

    public partial class Login
    {
        /// <summary>
        /// Initializes a new instance of the Login class.
        /// </summary>
        public Login() { }

        /// <summary>
        /// Initializes a new instance of the Login class.
        /// </summary>
        public Login(string email = default(string), string password = default(string))
        {
            Email = email;
            Password = password;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

    }
}
