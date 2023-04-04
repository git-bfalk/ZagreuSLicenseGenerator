using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Management;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace ZagreuS_License_Generator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "ZagreuS License Generator v1.0";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ZagreuS License Generator v1.0 - by ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("@rc_bfalk");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = " Calulating HWID...";
            string hwid = getUniqueID("C");
            Console.Title = "ZagreuS License Generator v1.0";
            Console.WriteLine("\n HWID: " + hwid);
            Console.Write(" Enter Username: ");
            Console.ForegroundColor = ConsoleColor.White;
            string username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Creating License...\n");
            string password = StringToHex(Convert.ToBase64String(Encoding.UTF8.GetBytes(Strings.StrReverse(Convert.ToBase64String(Encoding.UTF8.GetBytes(Encrypt(Strings.StrReverse(hwid + username))))))));
            Console.Write(" HWID: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(hwid);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Username: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(username);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Password: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(password);
            Console.ForegroundColor = ConsoleColor.Green;
            Clipboard.SetText(password);
            Console.WriteLine("\n Password copied to clipboard!\n");
            //File.WriteAllLines("license.txt", new string[] { "HWID: " + hwid, ";; If the HWID is not the same as on the login page of ZagreuS Builder, this license will not work!", "", "Username: " + username, "Password: " + password });
            //Console.WriteLine("\n License saved as 'license.txt'!\n");
            Console.ResetColor();
            Console.Write(" Press any key to exit...");
            Console.ReadKey();
        }

        private static object HwYRJPDeUsIPwotbAMNuCpb(string MFOAYGwPfeNOECGFh, string OhJQHZtHlXpmggKrA)
        {
            string text = "";
            int num = Strings.Asc(OhJQHZtHlXpmggKrA);
            short num2 = checked((short)Strings.Len(MFOAYGwPfeNOECGFh));
            for (short num3 = 1; num3 <= num2; num3 += 1)
            {
                text += Conversions.ToString(Strings.Chr(num ^ Strings.Asc(Strings.Mid(MFOAYGwPfeNOECGFh, (int)num3, 1))));
            }
            return text;
        }

        private static string StringToHex(string text)
        {
            checked
            {
                int num = text.Length - 1;
                string text2 = "";
                for (int i = 0; i <= num; i++)
                {
                    text2 = Conversions.ToString(Operators.ConcatenateObject(text2, NewLateBinding.LateGet(NewLateBinding.LateGet(Strings.Asc(text.Substring(i, 1)), null, "ToString", new object[] { HwYRJPDeUsIPwotbAMNuCpb("2", "JbThpjBWaljnaVBQQFlaBfq") }, null, null, null), null, "ToUpper", new object[0], null, null, null)));
                }
                return text2;
            }
        }

        private static string Encrypt(string TheText)
        {
            string text = "";
            int num = Strings.Len(TheText);
            checked
            {
                for (int i = 1; i <= num; i++)
                {
                    string text2 = Conversions.ToString(Strings.Chr(Strings.Asc(Strings.Mid(Strings.StrReverse(TheText), i, 1)) + 1));
                    text += text2;
                }
                return Strings.Trim(text);
            }
        }

        private static string getUniqueID(string drive)
        {
            if (drive == "")
            {
                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {
                    bool isReady = driveInfo.IsReady;
                    if (isReady)
                    {
                        drive = driveInfo.RootDirectory.ToString();
                        break;
                    }
                }
            }
            bool flag2 = drive.EndsWith(Conversions.ToString(DUtKARBaGcYrjGvQbkDBLsZ("}\u001b", "GwoagkwTMVCROkCFsdceKio")));
            if (flag2)
            {
                drive = drive.Substring(0, checked(drive.Length - 2));
            }
            string volumeSerial = getVolumeSerial(drive);
            string cpuid = getCPUID();
            string serialNumber = getSerialNumber();
            string macaddress = GetMACAddress();
            return string.Concat(new string[]
			{
				cpuid.Substring(0, 2),
				volumeSerial.Substring(0, 2),
				cpuid.Substring(9, 4),
				serialNumber.Substring(0, 4),
				cpuid.Substring(2, 4),
				volumeSerial.Substring(2, 4),
				cpuid.Substring(0xC),
				volumeSerial.Substring(3, 4),
				serialNumber.Substring(0xA, 4),
				macaddress.Substring(2, 4)
			});
        }

        private static string getCPUID()
        {
            string text = "";
            ManagementClass managementClass = new ManagementClass("win32_processor");
            ManagementObjectCollection instances = managementClass.GetInstances();
            try
            {
                foreach (ManagementBaseObject managementBaseObject in instances)
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    if (text == "")
                    {
                        text = managementObject.Properties["processorID"].Value.ToString();
                        break;
                    }
                }
            }
            catch { }
            return text;
        }

        private static string GetMACAddress()
        {
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = managementClass.GetInstances();
            string text = string.Empty;
            try
            {
                foreach (ManagementBaseObject managementBaseObject in instances)
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    if (text.Equals(string.Empty))
                    {
                        if (Convert.ToBoolean(managementObject["IPEnabled"]))
                        {
                            text = managementObject["MacAddress"].ToString();
                        }
                        managementObject.Dispose();
                    }
                    text = text.Replace(":", string.Empty);
                }
            }
            catch { }
            return text;
        }

        private static string getSerialNumber()
        {
            string text = string.Empty;
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            try
            {
                foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    text = managementObject["SerialNumber"].ToString();
                }
            }
            catch { }
            return text;
        }

        private static string getVolumeSerial(string drive)
        {
            ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            managementObject.Get();
            string text = managementObject["VolumeSerialNumber"].ToString();
            managementObject.Dispose();
            return text;
        }

        private static object DUtKARBaGcYrjGvQbkDBLsZ(string IbjqPHtLROdppRHsL, string LFdJvarDXHIQTvMhb)
        {
            string text = "";
            int num = Strings.Asc(LFdJvarDXHIQTvMhb);
            short num2 = checked((short)Strings.Len(IbjqPHtLROdppRHsL));
            for (short num3 = 1; num3 <= num2; num3 += 1)
            {
                text += Conversions.ToString(Strings.Chr(num ^ Strings.Asc(Strings.Mid(IbjqPHtLROdppRHsL, (int)num3, 1))));
            }
            return text;
        }
    }
}
