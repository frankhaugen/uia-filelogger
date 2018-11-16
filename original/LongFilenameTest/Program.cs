using Delimon.Win32.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

namespace LongFilenameTest
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string rootDirectory = "C:\\";
			string userName = Environment.UserName;
			string machineName = Environment.MachineName;
			string text = ".csv";
			string text2 = folderPath + "\\AllFilesFrom_" + machineName + text;
			string text3 = "\\\\filf1\\PersonligArkiv\\" + userName + "\\AllFilesFrom_" + machineName + text;
			List<string> list = new List<string>();
			DateTime now = DateTime.Now;
			try
			{
				File.Delete(text2);
			}
			catch (Exception)
			{
			}
			Console.WriteLine("===========================================================");
			Console.WriteLine("                 UiA - Filelogger 1.5");
			Console.WriteLine("===========================================================");
			Console.WriteLine("\nHit ENTER to start logging...");
			Console.ReadLine();
			foreach (string item in Traverse(rootDirectory))
			{
				Console.WriteLine(item);
				list.Add(item);
			}
			TimeSpan timeSpan = DateTime.Now.Subtract(now);
			Console.WriteLine("Time used: " + timeSpan);
			Console.WriteLine("\n> Writing log file");
			File.WriteAllLines(text2, list.ToArray<string>());
			Console.WriteLine("\n> Copying log to archive");
			try
			{
				File.Copy(text2, text3, true);
				Console.WriteLine("\n> Copying complete");
			}
			catch (Exception ex2)
			{
				Console.WriteLine("Copy failed");
				Console.WriteLine(ex2.Message);
			}
			Console.WriteLine("\n> Hit the ENTER key to close this program");
			Console.ReadLine();
		}

		private static IEnumerable<string> Traverse(string rootDirectory)
		{
			IEnumerable<string> files = Enumerable.Empty<string>();
			IEnumerable<string> directories = Enumerable.Empty<string>();
			try
			{
				FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.PathDiscovery, rootDirectory);
				permission.Demand();
				files = Directory.GetFiles(rootDirectory);
				directories = Directory.GetDirectories(rootDirectory);
			}
			catch
			{
				rootDirectory = null;
			}
			if (rootDirectory != null)
			{
				yield return rootDirectory;
			}
			foreach (string item in files)
			{
				yield return item;
			}
			IEnumerable<string> subdirectoryItems = directories.SelectMany(Traverse);
			foreach (string item2 in subdirectoryItems)
			{
				yield return item2;
			}
		}
	}
}
