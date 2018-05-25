﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Oddity.API.Models.Launchpad
{
    public class LaunchpadInfo
    {
        public LaunchpadType Type { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public LaunchpadStatus Status { get; set; }
        public LaunchpadLocation Location { get; set; }
        public string Details { get; set; }
    }
}