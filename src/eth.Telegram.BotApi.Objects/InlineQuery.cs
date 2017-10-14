﻿using Newtonsoft.Json;

namespace eth.Telegram.BotApi.Objects
{
    /// <summary>
    /// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
    /// </summary>
    public class InlineQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [JsonProperty("from", Required = Required.Always)]
        public User From { get; set; }

        /// <summary>
        /// Text of the query
        /// </summary>
        [JsonProperty("query", Required = Required.Always)]
        public string Query { get; set; }

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        [JsonProperty("offset", Required = Required.Always)]
        public string Offset { get; set; }
        
        /// <summary>
        /// Optional. Sender location, only for bots that request user location
        /// </summary>
        [JsonProperty("location", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Location Location { get; set; }
    }
}