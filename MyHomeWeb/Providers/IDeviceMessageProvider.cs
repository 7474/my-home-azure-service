using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWeb.Providers
{
    public interface IDeviceMessageProvider
    {
        Task SendCommand(IDeviceCommand command);
    }

    public interface IDeviceCommand
    {
        string DeviceId { get; }
        string CommandName { get; }
        string ToMessageJson();
    }
}
