﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace CScan
{

    public static class GlobalResult
    {
        public static string[] EndResult; 
    }
    class Program
    {

        static int cidrnote(string cidr)
        {
            if (cidr == "24")
            {
                Int32 hosts = 254;
                return hosts;
            }
            if (cidr == "25")
            {
                Int32 hosts = 126;
                return hosts;
            }
            if (cidr == "26")
            {
                Int32 hosts = 62;
                return hosts;
            }
            if (cidr == "27")
            {
                Int32 hosts = 30;
                return hosts;
            }
            if (cidr == "28")
            {
                Int32 hosts = 14;
                return hosts;
            }
            if (cidr == "29")
            {
                Int32 hosts = 6;
                return hosts;
            }
            if (cidr == "30")
            {
                Int32 hosts = 2;
                return hosts;
            }
            else
            {
                Console.WriteLine("Can only support /24 - /30 currently");
                System.Environment.Exit(1);
                return (1);
            }

        }
        static void ReturnCIDR(string range, string cidr, string port)
        {
            Int32 hosts = Program.cidrnote(cidr);
            string[] ipsplit = range.Split('.');
            string ipnew = ipsplit[0] + "." + ipsplit[1] + "." + ipsplit[2] + ".";
            string completeip = "";

            for (int f = 0; f < hosts; f++)
            {
                Thread thr1;
                completeip = (ipnew + f.ToString());
                thr1 = new Thread(() => scan(completeip,port));
                thr1.Start();
                Thread.Sleep(1);
            }
      
        }
        static void Help()
        {
            Console.WriteLine("Help Menu");
        }

        public static void scan(string ip, string port)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ip, Int32.Parse(port));
                    Console.WriteLine("OPEN " + ip + ":" + port);
                }
                catch (SocketException exc)
                {

                }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length < 2 || args[0] == "-h" || args[0] == "--help" )
            {
                Program.Help();
            }

            if (args[0].Contains("/"))
            {
                string[] ipcidr = args[0].Split('/');
                string[] portarray = args[1].Split(',');
                Console.WriteLine("Open ports will be shown as found" + "\n");
                foreach (string singleport in portarray)
                {
                    Program.ReturnCIDR(ipcidr[0], ipcidr[1], singleport);
                    
                }
            }
            else
            {
                Console.WriteLine("Open ports will be shown as found" + "\n");
                string[] portarray = args[1].Split(',');
                foreach (string singleport in portarray)
                {
                    Program.scan(args[0], singleport);
                }
            }
            
        }
    }
}
