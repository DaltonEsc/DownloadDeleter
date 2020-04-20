using System;
using Topshelf;

namespace AutomateDownloadDeleter
{
	class Program
	{
		static void Main(string[] args)
		{
			var exitCode = HostFactory.Run(x =>
			{
				x.Service<DownloadDeleter>(s =>
				{
					s.ConstructUsing(deleter => new DownloadDeleter());
					s.WhenStarted(deleter => deleter.Start());
					s.WhenStopped(deleter => deleter.Stop());
				});
				x.RunAsLocalSystem();

				x.SetServiceName("DownloadDeleter");
				x.SetDisplayName("Download Deleter");
				x.SetDescription("A simple Download folder cleaner script. Deletes everything in download folder every week.");
			});

			int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
			Environment.ExitCode = exitCodeValue;
		}
	}
}
