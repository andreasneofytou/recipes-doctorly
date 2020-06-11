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

    public partial class DishType : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the DishType class.
        /// </summary>
        public DishType() { }

        /// <summary>
        /// Initializes a new instance of the DishType class.
        /// </summary>
        public DishType(int id, string name = default(string))
            : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
