﻿using System;          
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace PomodoroTodo.Helpers
{
    public class EntityData
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [UpdatedAt]
        public DateTimeOffset UpdatedAt { get; set; }

        [Version]
        public string AzureVersion { get; set; }
    }
}
