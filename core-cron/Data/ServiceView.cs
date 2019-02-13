using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Cron.Data
{
    public class ServiceView
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceIdentifier { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public int UpdateFrequencyInMinutes { get; set; }

        private int DeltaTime => (DateTimeOffset.Now - LastUpdate).Minutes;

        [NotMapped]
        public bool IsAlive => DeltaTime <= UpdateFrequencyInMinutes;

        [NotMapped]
        public string HeartBeatColor => IsAlive ? "green" : "red";

        [NotMapped]
        public string HeartbeatTooltip => !IsAlive ? $"Service has stopped responding {DeltaTime - UpdateFrequencyInMinutes} minutes ago" : "Service is working normally";
    }
}
