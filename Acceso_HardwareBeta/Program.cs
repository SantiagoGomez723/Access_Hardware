using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Acceso_Hardware2;

namespace HardwareySO
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 0;
            while(m == 0)
            {
                int menu = Menu();
                if(menu == 7)
                {
                    m = menu;
                }
                switch (menu)
                {
                    case 1:
                        string Serial = "";
                        Serial = Acceso_Hardware2.informacion.SerialNumber();
                        Console.WriteLine(Serial);
                        Serial = Acceso_Hardware2.informacion.SerialCD();
                        Console.WriteLine(Serial);
                        break;
                    case 2:
                        string[] unidad = Environment.GetLogicalDrives();
                        Console.WriteLine("Units = " + string.Join(" ", unidad));
                        break;
                    case 3:
                        Console.WriteLine("Processors number = " + Environment.ProcessorCount);
                        string RAM = "";
                        RAM = Acceso_Hardware2.informacion.RAM();
                        Console.WriteLine(RAM);
                        break;
                    case 4:
                        String MAC = "";
                        MAC = Acceso_Hardware2.informacion.macAddress();
                        Console.WriteLine(MAC);
                        break;
                    case 5:
                        Read();
                        edit();
                        break;

                    case 6:
                        string PS = "";
                        List<string> Process = new List<string>();
                        Process = Acceso_Hardware2.informacion.Procesos();
                        foreach (string c in Process)
                        {
                            Console.WriteLine(c);
                        }
                        Console.WriteLine("What process do you want to stop? Enter the name");
                        PS = Console.ReadLine();
                        Acceso_Hardware2.informacion.MatarProcesos(PS);
                        Console.WriteLine("The process has been deleted");
                        break;
                    default:
                        Console.WriteLine("Please, enter a valid option");
                        break;
                }

            }    
        }
        public static void edit()
        {
            Console.WriteLine("Enter the path of the register to edit");
            string Source = Console.ReadLine();
            Console.WriteLine("Enter the key of the register to edit");
            string KeyName = Console.ReadLine();
            Console.WriteLine("Enter the value of the key:" + KeyName);
            string value = Console.ReadLine();
            setRegistryValue(Source, KeyName, value);

        }
        public static void Read()
        {
            Console.WriteLine("Enter the path of the register to read");
            string Source = Console.ReadLine();
            Console.WriteLine("Enter the key of the register to read");
            string Key = Console.ReadLine();
            Console.WriteLine("The value in the path: " + Source + " was: " + ReadRegistryValue(Source, Key));
        }
        
        private static string ReadRegistryValue(string Source, string key)
        {
            return Registry.GetValue(Source, key, "NO FOUND").ToString();
        }
        private static void setRegistryValue(string source, string keyName, string value)
        {
            Registry.SetValue(source, keyName, value);
        }        

        static int Menu()
        {
            Console.WriteLine("Please, select an option\n");
            Console.WriteLine("\t.-Read the number of the hard disk series / CD / DVD.");
            Console.WriteLine("\t.-How many units of disk does it have?");
            Console.WriteLine("\t.-General balance of system: Processors, RAM, NIC");
            Console.WriteLine("\t.-Obtener MAC Address. - Get Mac Address");
            Console.WriteLine("\t.-Access to system register - Create key / Read key / Delete key / Modify key.");
            Console.WriteLine("\t.-Get the active processes / Cancel process.");
            Console.WriteLine("\t.-Log off");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
    }



}

