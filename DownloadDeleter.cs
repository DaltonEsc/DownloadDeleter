using System;
using System.IO;
using System.Timers;

namespace AutomateDownloadDeleter
{
	class DownloadDeleter
	{
		private readonly Timer _timer;

		public DownloadDeleter()
		{
			_timer = new Timer(10000){ AutoReset = true };
			_timer.Elapsed += timer_Elapsed;
		}
		private void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			string path = @"D:\CodeZone\C#\AutomateDownloadDeleter\Test";
			DirectoryInfo directory = new DirectoryInfo(path);

			foreach (FileInfo file in directory.GetFiles())
			{
				file.Delete();
			}
			foreach (DirectoryInfo dir in directory.GetDirectories())
			{
				dir.Delete(true);
			}
			Console.WriteLine("Done");

		}
		public void Start()
		{
			_timer.Start();
		}
		public void Stop()
		{
			_timer.Stop();
		}
	}
}
