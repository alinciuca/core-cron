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

        private TimeSpan DeltaTime => DateTimeOffset.UtcNow - LastUpdate.ToUniversalTime();

        [NotMapped]
        public bool IsAlive => DeltaTime.TotalMinutes <= UpdateFrequencyInMinutes;

        [NotMapped]
        public string HeartBeatColor => IsAlive ? "green" : "red";

        [NotMapped]
        private string TimeOff
        {
            get
            {
                var totalMinutes = DeltaTime.TotalMinutes - UpdateFrequencyInMinutes;
                var hours = (int)(totalMinutes / 60);
                if (hours > 24)
                {
                    return "more than 24 hours ago";
                }
                if (hours <= 24 && hours > 0)
                {
                    return $"{hours} hours ago";
                }
                return $"{(int)totalMinutes} minutes ago";
            }
        }

        [NotMapped]
        public string HeartbeatTooltip => !IsAlive ? $"Service has stopped responding {TimeOff}" : "Service is working normally";
    }
}
