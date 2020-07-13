﻿using Newtonsoft.Json;

namespace Oddity.Models.Common
{
    public class ThrustInfo : ModelBase
    {
        [JsonProperty("kN")]
        public double? Kilonewtons { get; set; }

        [JsonProperty("lbf")]
        public double? PoundForce { get; set; }
    }
}