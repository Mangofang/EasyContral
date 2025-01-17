using System;
using System.Management;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EasyContral
{
    internal class SystemInfo
    {
        public static string GetClientID()
        {
            string cpuId = GetCpuId();
            string diskId = GetDiskId();
            string macAddress = GetMacAddress();

            string rawId = cpuId + diskId + macAddress;
            return GenerateHash(rawId);
        }
        public static string GetSystemName() 
        {
            return Environment.MachineName + "/" + Environment.UserName;
        }
        public static string GetSystemVersion()
        {
            return Environment.OSVersion.ToString();
        }
        public static string GetCpuName() 
        {
            string CpuName = "";
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Program.AESDecrypt("vyVG9Ps5VPw2fSEtjBfIyFURLYT0+SdizLD+SwqnwLmRMh/dYzpiA238IO2robDe", Program.Key, Program.IV));
            foreach (ManagementObject obj in searcher.Get())
            {
                CpuName = obj["Name"].ToString();
            }
            return CpuName;
        }
        public static string GetMemoryInMb()
        {
            double totalInMb = 0;
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Program.AESDecrypt("YQt0Wh55Vn6ntrQaGYwaHAm2Lk0fJY0SjrILxtzC8sVvn/f1xvJtigKK7Bms78gN", Program.Key, Program.IV));
            foreach (ManagementObject obj in searcher.Get())
            {
                ulong totalPhysicalMemory = (ulong)obj["TotalPhysicalMemory"];
                totalInMb = totalPhysicalMemory / (1024 * 1024);
            }
            return totalInMb.ToString();
        }
        public static List<string> GetDrive()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            List<string> Drives = new List<string>();
            foreach (DriveInfo drive in allDrives)
            {
                Drives.Add(drive.Name);
            }
            return Drives;
        }
        private static string GetCpuId()
        {
            string cpuId = "";
            using (ManagementClass mc = new ManagementClass("Win32_Processor"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    cpuId = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
            }
            return cpuId;
        }

        private static string GetDiskId()
        {
            string diskId = "";
            using (ManagementClass mc = new ManagementClass("Win32_DiskDrive"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    diskId = mo.Properties["SerialNumber"].Value.ToString();
                    break;
                }
            }
            return diskId;
        }

        private static string GetMacAddress()
        {
            string macAddress = "";
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        macAddress = mo["MacAddress"].ToString();
                        break;
                    }
                }
            }
            return macAddress;
        }

        private static string GenerateHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 16; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
