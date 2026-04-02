using Microsoft.Maui.Devices;

namespace Lesson38MauiApp.Services
{
    public class DeviceService
    {
        public string GetModel() => DeviceInfo.Model;
        public string GetManufacturer() => DeviceInfo.Manufacturer;
        public string GetOsVersion() => DeviceInfo.VersionString;

        public int? GetBatteryLevel()
        {
            try
            {
                var charge = Battery.ChargeLevel;

                // Some platforms return -1 when unknown
                if (charge < 0)
                    return null;

                return (int)(charge * 100);
            }
            catch (Exception)
            {
                // Could log here if desired
                return null;
            }
        }

        public string GetPowerSource()
        {
            try
            {
                return Battery.PowerSource.ToString();
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }
    }
}
