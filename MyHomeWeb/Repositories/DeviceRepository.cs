using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.Devices;

namespace MyHomeWeb.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private RegistryManager registryManager;

        public DeviceRepository(RegistryManager registryManager)
        {
            this.registryManager = registryManager;
        }

        public async Task<Device> get(string deviceId)
        {
            return await registryManager.GetDeviceAsync(deviceId);
        }

        public async Task<IEnumerable<Device>> all()
        {
            return await registryManager.GetDevicesAsync(100);
        }
    }
}