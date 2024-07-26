# Serpent Stealer Analysis
> [!WARNING]  
> This repository was created for the purpose of research and analysis of the malware.\
> All tests were conducted with the aim of understanding the structure and the objective of the malware's creation.

* [`Hashes`](#hashes)
* [`VirusTotal`](#virustotal)
* [`PEStudio Analysis`](#pestudio-analysis)
  * [`File Details`](#file-details)
  * [`Indicators`](#indicators)
  * [`Imports`](#imports) 
* [`Serpent Code`](https://github.com/h0ru/SerpentStealerAnalysis/tree/main/serpent)


- - -

![On_the_market](https://github.com/user-attachments/assets/341359ce-29c2-4a6e-a314-33b811b64cdb)
https://x.com/DailyDarkWeb/status/1713963018646593714

- - -

## Hashes
```
MD5: a83230ddced4ae435220d8756cc07be9
SHA1: a8de896e026e2c03b324218ede714a66b7e7248f
SHA256: c4f981f1f532ec827032775c88a45f1b4153c3d27885f189654ad6ee85c709c1
```
## VirusTotal
![image](https://github.com/user-attachments/assets/5b6d9dcf-b731-4594-861f-543cef60a298)
https://www.virustotal.com/gui/file/c4f981f1f532ec827032775c88a45f1b4153c3d27885f189654ad6ee85c709c1

- - -

## PEStudio Analysis
### File Details
![image](https://github.com/user-attachments/assets/e4ad1a45-731a-4bb7-81c6-caeb80684f9b)
### Indicators
![image](https://github.com/user-attachments/assets/c078ab1f-f69d-4c28-ba91-684b833b2319)
```
URLs:
hxxp[://]checkip[.]dyndns[.]org
hxxps[://]api[.]steampowered[.]com/IPlayerService/GetOwnedGames/v1/?key=
hxxps[://]api[.]steampowered[.]com/IPlayerService/GetSteamLevel/v1/?key=
hxxps[://]api[.]steampowered[.]com/ISteamUser/GetPlayerSummaries/v0002/?key=
hxxps[://]discord[.]com/api/webhooks/1156720932375756921/Xu5g1XzMRXTKDzrIOMcPMC1orYzXGQKBYTTRVOX4oR-IbivHh0LzqCucl2b-obrco6jj
```
### Imports
![image](https://github.com/user-attachments/assets/5b49c58e-992b-4173-8762-ea57b5d76b8a)
https://www.dll-files.com/mscoree.dll.html

- - -
