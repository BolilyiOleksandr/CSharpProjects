using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fn with Processes *****\n");
            //ListAllRunningProcesses();
            //GetSpecificProcess();

            //Console.WriteLine("***** Enter PID of process to investigate *****");
            //Console.WriteLine("PID: ");
            //var pId = Console.ReadLine();
            //var theProcId = int.Parse(pId);
            //EnumThreadsForPid(theProcId);
            //EnumModsForPid(theProcId);
            StartAndKillProcess();

            Console.ReadLine();
        }

        private static void ListAllRunningProcesses()
        {
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.Id
                               select proc;

            foreach (var p in runningProcs)
            {
                var info = string.Format("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info);
            }

            Console.WriteLine("**************************************\r\n");
        }

        private static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void EnumThreadsForPid(int pId)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pId);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);
            var theThreads = theProc.Threads;

            foreach (ProcessThread pt in theThreads)
            {
                var info = string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}", pt.Id,
                    pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }

            Console.WriteLine("********************************\r\n");
        }

        private static void EnumModsForPid(int pId)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pId);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are loaded modules for: {0}", theProc.ProcessName);

            var theMods = theProc.Modules;
            foreach (ProcessModule pm in theMods)
            {
                var info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine("*********************\r\n");
            }
        }

        private static void StartAndKillProcess()
        {
            Process ieProc = null;
            try
            {
                ieProc = Process.Start("IExplore.exe", "www.sports.ru");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("--> Hit enter to kill {0}...", ieProc.ProcessName);
            Console.ReadLine();

            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
