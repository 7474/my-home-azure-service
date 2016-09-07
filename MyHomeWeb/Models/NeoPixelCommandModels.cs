using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHomeWeb.Models
{
    public enum FlashMode
    {
        StartToEnd = 0,
        CenterToEdge = 1,
        EdgeToCenter = 2
    }

    public class NeoPixelCommand : DeviceCommand
    {
        public static readonly string COMMAND_NAME = "NeoPixelCommand";

        public FlashMode FlashMode { get; set; }

        [Required]
        [RegularExpression("#[0-9a-f]{6}")]
        public string BaseColor { get; set; }

        [Required]
        [RegularExpression("#[0-9a-f]{6}")]
        public string FlashColor { get; set; }

        public int Delay { get; set; }

        public override string CommandName { get { return COMMAND_NAME; } }

        public override string ToMessageJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}