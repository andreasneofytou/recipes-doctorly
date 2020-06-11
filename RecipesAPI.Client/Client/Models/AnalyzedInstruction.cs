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

    public partial class AnalyzedInstruction : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the AnalyzedInstruction class.
        /// </summary>
        public AnalyzedInstruction() { }

        /// <summary>
        /// Initializes a new instance of the AnalyzedInstruction class.
        /// </summary>
        public AnalyzedInstruction(int id, int? stepSequence = default(int?), string instruction = default(string), IList<Ingredient> ingredients = default(IList<Ingredient>), IList<Equipment> equipment = default(IList<Equipment>))
            : base(id)
        {
            StepSequence = stepSequence;
            Instruction = instruction;
            Ingredients = ingredients;
            Equipment = equipment;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "stepSequence")]
        public int? StepSequence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "instruction")]
        public string Instruction { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ingredients")]
        public IList<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "equipment")]
        public IList<Equipment> Equipment { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Ingredients != null)
            {
                foreach (var element in this.Ingredients)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.Equipment != null)
            {
                foreach (var element1 in this.Equipment)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
        }
    }
}
