﻿using System;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// LogRequest
    /// </summary>
    public sealed class LogRequest
    {
        ///        
        [JsonProperty("event", Required = Required.Always)]
        public Event RequestEvent { get; set; } = default!;

        ///
        [JsonProperty("verbose")]
        public bool Verbose { get; set; } = default!;

        ///
        [JsonProperty("signature")]
        public string Signature { get; set; } = default!;

        ///
        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = default!;

        ///
        [JsonProperty("prev_root")]
        public string PrevRoot { get; set; } = default!;

        ///
        public LogRequest(Event requestEvent, bool verbose, string signature, string publicKey, string prevRoot)
        {
            this.RequestEvent = requestEvent;
            this.Verbose = verbose;
            this.Signature = signature;
            this.PublicKey = publicKey;
            this.PrevRoot = prevRoot;
        }
    }
}

