using MyHomeWeb.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHomeWeb.Models
{


    public abstract class DeviceCommand : IDeviceCommand
    {
        public abstract string CommandName { get; }

        [Required]
        public string DeviceId { get; set; }

        public abstract string ToMessageJson();
    }
}