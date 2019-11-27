using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ProcessorName
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            foreach (ManagementObject mo in s2.Get())
                Console.WriteLine("Processador: {0}", mo["Name"]);


            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM  Win32_BaseBoard");

            foreach (ManagementObject objManagemnet in objMOS.Get())
            {
                try
                {
                    Console.WriteLine("======================================================================");
                    Console.WriteLine("         Detalhes da Placa Mãe (By Leandro - Art Chik 2017)                                ");
                    Console.WriteLine("======================================================================");
                    Console.WriteLine("Caption             :" + objManagemnet.GetPropertyValue("Caption").ToString());
                    Console.WriteLine("CreationClassName   :" + objManagemnet.GetPropertyValue("CreationClassName").ToString());
                    Console.WriteLine("Description         :" + objManagemnet.GetPropertyValue("Description").ToString());
                    Console.WriteLine("InstallDate         :" + Convert.ToDateTime(objManagemnet.GetPropertyValue("InstallDate")));
                    Console.WriteLine("Manufacturer        :" + objManagemnet.GetPropertyValue("Manufacturer").ToString());
                    Console.WriteLine("Model               :" + Convert.ToString(objManagemnet.GetPropertyValue("Model")));
                    Console.WriteLine("Name                :" + objManagemnet.GetPropertyValue("Name").ToString());
                    Console.WriteLine("PartNumber          :" + Convert.ToInt32(objManagemnet.GetPropertyValue("PartNumber")));
                    Console.WriteLine("PoweredOn           :" + objManagemnet.GetPropertyValue("PoweredOn").ToString());
                    Console.WriteLine("Product             :" + objManagemnet.GetPropertyValue("Product").ToString());
                    Console.WriteLine("SerialNumber        :" + objManagemnet.GetPropertyValue("SerialNumber").ToString());
                    Console.WriteLine("SKU                 :" + Convert.ToString(objManagemnet.GetPropertyValue("SKU")));
                    Console.WriteLine("Status              :" + Convert.ToString(objManagemnet.GetPropertyValue("Status")));
                    Console.WriteLine("Tag                 :" + Convert.ToString(objManagemnet.GetPropertyValue("Tag")));
                    Console.WriteLine("Version             :" + Convert.ToString(objManagemnet.GetPropertyValue("Version")));
                    Console.WriteLine("Weight              :" + Convert.ToString(objManagemnet.GetPropertyValue("Weight")));
                    Console.WriteLine("Height              :" + Convert.ToString(objManagemnet.GetPropertyValue("Height")));
                    Console.WriteLine("PoweredOn           :" + Convert.ToString(objManagemnet.GetPropertyValue("PoweredOn")));
                }
                catch (Exception ex) { }
            }

            Console.ReadKey();
        }
    }
}
