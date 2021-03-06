﻿using Newtonsoft.Json;
using Oddity.Models.Common;

namespace Oddity.Models.Rockets
{
    public class RocketEnginesInfo : ModelBase
    {
        public uint? Number { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public string Layout { get; set; }

        public IspInfo Isp { get; set; }

        [JsonProperty("thrust_sea_level")]
        public ThrustInfo ThrustSeaLevel { get; set; }

        [JsonProperty("thrust_vacuum")]
        public ThrustInfo ThrustVacuum { get; set; }

        [JsonProperty("engine_loss_max")]
        public uint? EngineLossMax { get; set; }

        [JsonProperty("propellant_1")]
        public string FirstPropellant { get; set; }

        [JsonProperty("propellant_2")]
        public string SecondPropellant { get; set; }

        [JsonProperty("thrust_to_weight")]
        public double? ThrustToWeight { get; set; }
    }
}
