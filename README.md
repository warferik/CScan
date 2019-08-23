# CScan
Simple C# Port Scanner, can take a single IP or CIDR /24 - /30

CScan.exe 192.168.1.2 22,445,3389

CScan.exe 192.168.1.0/24 21-23,25,80,443

CScan.exe 192.168.1.0/24 top100

CScan.exe 192.168.1.0/24 top1000


Just Scan Ports that can lead RCE (subjective)

CScan.exe 192.168.1.110 rce

