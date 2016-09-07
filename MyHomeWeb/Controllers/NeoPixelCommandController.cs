using Microsoft.Azure.Devices;
using MyHomeWeb.Models;
using MyHomeWeb.Providers;
using MyHomeWeb.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomeWeb.Controllers
{
    public class NeoPixelCommandController : Controller
    {
        // XXX
        private static readonly RegistryManager registryManager = RegistryManager.CreateFromConnectionString(
            ConfigurationManager.AppSettings.Get("IoTHubManagementConnectionString"));
        private static readonly ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(
            ConfigurationManager.AppSettings.Get("IoTHubManagementConnectionString"));

        private IDeviceRepository deviceRegistory;
        private IDeviceMessageProvider messageProvider;

        public NeoPixelCommandController()
        {
            deviceRegistory = new DeviceRepository(registryManager);
            messageProvider = new DeviceMessageProvider(serviceClient);
        }

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var result = (await deviceRegistory.all());
            return View(result);
        }

        public ActionResult Publish(string id)
        {
            var command = new NeoPixelCommand()
            {
                FlashMode = FlashMode.StartToEnd,
                DeviceId = id,
                BaseColor = "#008040",
                FlashColor = "#80f0c0",
                Delay = 50
            };
            return View(command);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Publish(string id, NeoPixelCommand request)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(request));
            request.DeviceId = id;

            // XXX Validate? Fooooh!
            await messageProvider.SendCommand(request);
            return RedirectToAction("Publish", "NeoPixelCommand", id);
        }
    }
}