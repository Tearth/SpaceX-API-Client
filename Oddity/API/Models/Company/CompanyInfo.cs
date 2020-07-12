﻿using Newtonsoft.Json;

namespace Oddity.API.Models.Company
{
    public class CompanyInfo : ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Founder { get; set; }
        public uint? Employees { get; set; }
        public uint? Vehicles { get; set; }
        public string Ceo { get; set; }
        public string Cto { get; set; }
        public string Coo { get; set; }
        public ulong? Valuation { get; set; }
        public string Summary { get; set; }

        public HeadquartersInfo Headquarters { get; set; }
        public CompanyLinksInfo Links { get; set; }

        [JsonProperty("founded")]
        public uint? FoundedYear { get; set; }

        [JsonProperty("launch_sites")]
        public uint? LaunchSites { get; set; }

        [JsonProperty("test_sites")]
        public uint? TestSites { get; set; }

        [JsonProperty("cto_propulsion")]
        public string CtoPropulsion { get; set; }

    }
}
