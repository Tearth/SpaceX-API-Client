﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oddity.Models.Ships;

namespace Oddity.Models.Launches
{
    public class LaunchFairingsInfo : ModelBase
    {
        public bool? Reused { get; set; }
        public bool? Recovered { get; set; }

        [JsonProperty("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        [JsonProperty("ships")]
        public List<string> ShipsId
        {
            get => _shipsId;
            set
            {
                _shipsId = value;
                Ships = _shipsId.Select(p => new Lazy<ShipInfo>(() => Context.ShipsEndpoint.Get(p).Execute())).ToList();
            }
        }

        public List<Lazy<ShipInfo>> Ships { get; private set; }

        private List<string> _shipsId;
    }
}
