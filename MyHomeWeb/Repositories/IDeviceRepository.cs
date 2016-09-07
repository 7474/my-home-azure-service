using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWeb.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> all();
        Task<Device> get(string deviceId);
    }
}
