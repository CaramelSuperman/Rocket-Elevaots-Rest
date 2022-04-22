using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DotNetCoreMySQL.Models
{
    public partial class Intervention
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Author { get; set; }
        public string? CustomerId { get; set; }
        public string? BuildingId { get; set; }
        public string? BatteryId { get; set; }
        public string? ColumnId { get; set; }
        public string? ElevatorId { get; set; }
        public DateTime? StartIntervention { get; set; }
        public DateTime? EndIntervention { get; set; }
        public string? Result { get; set; }
        public string? Report { get; set; }
        public string? Status { get; set; }
        public string? Employee { get; set; }
    }
}
