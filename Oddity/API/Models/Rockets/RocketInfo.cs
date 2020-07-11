﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Rockets
{
    public class RocketInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Active { get; set; }
        public uint? Stages { get; set; }
        public uint? Boosters { get; set; }

        [JsonProperty("cost_per_launch")]
        public uint? CostPerLaunch { get; set; }

        [JsonProperty("success_rate_pct")]
        public uint? SuccessRate { get; set; }

        [JsonProperty("first_flight")]
        public DateTime? FirstFlight { get; set; }

        public SizeInfo Height { get; set; }
        public SizeInfo Diameter { get; set; }
        public MassInfo Mass { get; set; }

        [JsonProperty("first_stage")]
        public FirstStageInfo FirstStage { get; set; }

        [JsonProperty("second_stage")]
        public SecondStageInfo SecondStage { get; set; }

        public EnginesInfo Engines { get; set; }

        [JsonProperty("landing_legs")]
        public LandingLegsInfo LandingLegs { get; set; }

        [JsonProperty("payload_weights")]
        public List<PotentialPayloadWeightInfo> PayloadWeights { get; set; }

        public string Country { get; set; }
        public string Company { get; set; }
        public string Wikipedia { get; set; }
        public string Description { get; set; }

        [JsonProperty("flickr_images")]
        public List<string> FlickrImages { get; set; }
    }
}
