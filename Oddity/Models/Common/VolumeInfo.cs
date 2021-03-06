﻿using Newtonsoft.Json;

namespace Oddity.Models.Common
{
    public class VolumeInfo : ModelBase
    {
        [JsonProperty("cubic_meters")]
        public double? CubicMeters { get; set; }

        [JsonProperty("cubic_feet")]
        public double? CubicFeet { get; set; }

        public override string ToString()
        {
            return $"{CubicFeet} m^3 ({CubicFeet} ft^3)";
        }
    }
}
