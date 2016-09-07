using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyHomeWeb.Providers
{
    public class DeviceMessageProvider : IDeviceMessageProvider
    {
        private ServiceClient serviceClient;

        public DeviceMessageProvider(ServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        public async Task SendCommand(IDeviceCommand command)
        {
            var message = new Message(Encoding.ASCII.GetBytes(command.ToMessageJson()));
            await serviceClient.SendAsync(command.DeviceId, message);
        }
    }
}