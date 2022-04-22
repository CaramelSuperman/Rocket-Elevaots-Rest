using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DotNetCoreMySQL.Models
{
    public partial class ArInternalMetadatum
    {
        public string Key { get; set; } = null!;
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
