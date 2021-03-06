Configuration DefaultProfileDSC {
	param(
	[string]$ComputerName='localhost'
	)

	# Import the module that contains the resources we're using.
	Import-DscResource -ModuleName PsDesiredStateConfiguration

	Node localhost {
		WindowsFeature Feature-FileAndStorage-Services { 
				Ensure = 'Present' 
				Name = 'FileAndStorage-Services' 
		} 


		WindowsFeature Feature-Storage-Services { 
				Ensure = 'Present' 
				Name = 'Storage-Services' 
		} 


		WindowsFeature Feature-Web-Server { 
				Ensure = 'Present' 
				Name = 'Web-Server' 
		} 


		WindowsFeature Feature-Web-WebServer { 
				Ensure = 'Present' 
				Name = 'Web-WebServer' 
		} 


		WindowsFeature Feature-Web-Common-Http { 
				Ensure = 'Present' 
				Name = 'Web-Common-Http' 
		} 


		WindowsFeature Feature-Web-Default-Doc { 
				Ensure = 'Present' 
				Name = 'Web-Default-Doc' 
		} 


		WindowsFeature Feature-Web-Dir-Browsing { 
				Ensure = 'Present' 
				Name = 'Web-Dir-Browsing' 
		} 


		WindowsFeature Feature-Web-Http-Errors { 
				Ensure = 'Present' 
				Name = 'Web-Http-Errors' 
		} 


		WindowsFeature Feature-Web-Static-Content { 
				Ensure = 'Present' 
				Name = 'Web-Static-Content' 
		} 


		WindowsFeature Feature-Web-Health { 
				Ensure = 'Present' 
				Name = 'Web-Health' 
		} 


		WindowsFeature Feature-Web-Http-Logging { 
				Ensure = 'Present' 
				Name = 'Web-Http-Logging' 
		} 


		WindowsFeature Feature-Web-Performance { 
				Ensure = 'Present' 
				Name = 'Web-Performance' 
		} 


		WindowsFeature Feature-Web-Stat-Compression { 
				Ensure = 'Present' 
				Name = 'Web-Stat-Compression' 
		} 


		WindowsFeature Feature-Web-Security { 
				Ensure = 'Present' 
				Name = 'Web-Security' 
		} 


		WindowsFeature Feature-Web-Filtering { 
				Ensure = 'Present' 
				Name = 'Web-Filtering' 
		} 


		WindowsFeature Feature-Web-Basic-Auth { 
				Ensure = 'Present' 
				Name = 'Web-Basic-Auth' 
		} 


		WindowsFeature Feature-Web-Windows-Auth { 
				Ensure = 'Present' 
				Name = 'Web-Windows-Auth' 
		} 


		WindowsFeature Feature-Web-App-Dev { 
				Ensure = 'Present' 
				Name = 'Web-App-Dev' 
		} 


		WindowsFeature Feature-Web-Net-Ext { 
				Ensure = 'Present' 
				Name = 'Web-Net-Ext' 
				DependsOn = '[WindowsFeature]Feature-Web-Filtering','[WindowsFeature]Feature-NET-Framework-Core','[WindowsFeature]Feature-NET-Framework-45-ASPNET'
		} 


		WindowsFeature Feature-Web-Net-Ext45 { 
				Ensure = 'Present' 
				Name = 'Web-Net-Ext45' 
				DependsOn = '[WindowsFeature]Feature-Web-Filtering','[WindowsFeature]Feature-NET-Framework-45-ASPNET'
		} 


		WindowsFeature Feature-Web-Asp-Net45 { 
				Ensure = 'Present' 
				Name = 'Web-Asp-Net45' 
				DependsOn = '[WindowsFeature]Feature-Web-Filtering','[WindowsFeature]Feature-Web-Default-Doc','[WindowsFeature]Feature-Web-ISAPI-Filter','[WindowsFeature]Feature-Web-ISAPI-Ext','[WindowsFeature]Feature-Web-Net-Ext45'
		} 


		WindowsFeature Feature-Web-ISAPI-Ext { 
				Ensure = 'Present' 
				Name = 'Web-ISAPI-Ext' 
		} 


		WindowsFeature Feature-Web-ISAPI-Filter { 
				Ensure = 'Present' 
				Name = 'Web-ISAPI-Filter' 
		} 


		WindowsFeature Feature-Web-Mgmt-Tools { 
				Ensure = 'Present' 
				Name = 'Web-Mgmt-Tools' 
		} 


		WindowsFeature Feature-Web-Mgmt-Console { 
				Ensure = 'Present' 
				Name = 'Web-Mgmt-Console' 
				DependsOn = '[WindowsFeature]Feature-Server-Gui-Mgmt-Infra'
		} 


		WindowsFeature Feature-NET-Framework-Features { 
				Ensure = 'Present' 
				Name = 'NET-Framework-Features' 
		} 


		WindowsFeature Feature-NET-Framework-Core { 
				Ensure = 'Present' 
				Name = 'NET-Framework-Core' 
		} 


		WindowsFeature Feature-NET-HTTP-Activation { 
				Ensure = 'Present' 
				Name = 'NET-HTTP-Activation' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-Core','[WindowsFeature]Feature-Web-Net-Ext','[WindowsFeature]Feature-WAS-Process-Model','[WindowsFeature]Feature-WAS-NET-Environment','[WindowsFeature]Feature-WAS-Config-APIs'
		} 


		WindowsFeature Feature-NET-Non-HTTP-Activ { 
				Ensure = 'Present' 
				Name = 'NET-Non-HTTP-Activ' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-Core','[WindowsFeature]Feature-WAS-Process-Model','[WindowsFeature]Feature-WAS-NET-Environment','[WindowsFeature]Feature-WAS-Config-APIs'
		} 


		WindowsFeature Feature-NET-Framework-45-Features { 
				Ensure = 'Present' 
				Name = 'NET-Framework-45-Features' 
		} 


		WindowsFeature Feature-NET-Framework-45-Core { 
				Ensure = 'Present' 
				Name = 'NET-Framework-45-Core' 
		} 


		WindowsFeature Feature-NET-Framework-45-ASPNET { 
				Ensure = 'Present' 
				Name = 'NET-Framework-45-ASPNET' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core'
		} 


		WindowsFeature Feature-NET-WCF-Services45 { 
				Ensure = 'Present' 
				Name = 'NET-WCF-Services45' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core'
		} 


		WindowsFeature Feature-NET-WCF-HTTP-Activation45 { 
				Ensure = 'Present' 
				Name = 'NET-WCF-HTTP-Activation45' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core','[WindowsFeature]Feature-NET-Framework-45-ASPNET','[WindowsFeature]Feature-Web-Asp-Net45','[WindowsFeature]Feature-WAS-Process-Model','[WindowsFeature]Feature-WAS-Config-APIs'
		} 


		WindowsFeature Feature-NET-WCF-MSMQ-Activation45 { 
				Ensure = 'Present' 
				Name = 'NET-WCF-MSMQ-Activation45' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core','[WindowsFeature]Feature-NET-Framework-45-ASPNET','[WindowsFeature]Feature-WAS-Process-Model','[WindowsFeature]Feature-WAS-Config-APIs','[WindowsFeature]Feature-MSMQ-Server'
		} 


		WindowsFeature Feature-NET-WCF-Pipe-Activation45 { 
				Ensure = 'Present' 
				Name = 'NET-WCF-Pipe-Activation45' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core','[WindowsFeature]Feature-NET-Framework-45-ASPNET','[WindowsFeature]Feature-WAS-Process-Model','[WindowsFeature]Feature-WAS-Config-APIs'
		} 


		WindowsFeature Feature-NET-WCF-TCP-Activation45 { 
				Ensure = 'Present' 
				Name = 'NET-WCF-TCP-Activation45' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core','[WindowsFeature]Feature-NET-WCF-TCP-PortSharing45','[WindowsFeature]Feature-NET-Framework-45-ASPNET','[WindowsFeature]Feature-WAS-Process-Model','[WindowsFeature]Feature-WAS-Config-APIs'
		} 


		WindowsFeature Feature-NET-WCF-TCP-PortSharing45 { 
				Ensure = 'Present' 
				Name = 'NET-WCF-TCP-PortSharing45' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core'
		} 


		WindowsFeature Feature-MSMQ { 
				Ensure = 'Present' 
				Name = 'MSMQ' 
		} 


		WindowsFeature Feature-MSMQ-Services { 
				Ensure = 'Present' 
				Name = 'MSMQ-Services' 
		} 


		WindowsFeature Feature-MSMQ-Server { 
				Ensure = 'Present' 
				Name = 'MSMQ-Server' 
		} 


		WindowsFeature Feature-FS-SMB1 { 
				Ensure = 'Present' 
				Name = 'FS-SMB1' 
		} 


		WindowsFeature Feature-User-Interfaces-Infra { 
				Ensure = 'Present' 
				Name = 'User-Interfaces-Infra' 
		} 


		WindowsFeature Feature-Server-Gui-Mgmt-Infra { 
				Ensure = 'Present' 
				Name = 'Server-Gui-Mgmt-Infra' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core','[WindowsFeature]Feature-PowerShell','[WindowsFeature]Feature-WoW64-Support'
		} 


		WindowsFeature Feature-Server-Gui-Shell { 
				Ensure = 'Present' 
				Name = 'Server-Gui-Shell' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core','[WindowsFeature]Feature-PowerShell','[WindowsFeature]Feature-Server-Gui-Mgmt-Infra'
		} 


		WindowsFeature Feature-PowerShellRoot { 
				Ensure = 'Present' 
				Name = 'PowerShellRoot' 
		} 


		WindowsFeature Feature-PowerShell { 
				Ensure = 'Present' 
				Name = 'PowerShell' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-45-Core'
		} 


		WindowsFeature Feature-PowerShell-V2 { 
				Ensure = 'Present' 
				Name = 'PowerShell-V2' 
				DependsOn = '[WindowsFeature]Feature-PowerShell','[WindowsFeature]Feature-NET-Framework-Core'
		} 


		WindowsFeature Feature-PowerShell-ISE { 
				Ensure = 'Present' 
				Name = 'PowerShell-ISE' 
				DependsOn = '[WindowsFeature]Feature-PowerShell','[WindowsFeature]Feature-NET-Framework-45-Core'
		} 


		WindowsFeature Feature-WAS { 
				Ensure = 'Present' 
				Name = 'WAS' 
		} 


		WindowsFeature Feature-WAS-Process-Model { 
				Ensure = 'Present' 
				Name = 'WAS-Process-Model' 
		} 


		WindowsFeature Feature-WAS-NET-Environment { 
				Ensure = 'Present' 
				Name = 'WAS-NET-Environment' 
				DependsOn = '[WindowsFeature]Feature-NET-Framework-Core','[WindowsFeature]Feature-NET-Framework-45-ASPNET'
		} 


		WindowsFeature Feature-WAS-Config-APIs { 
				Ensure = 'Present' 
				Name = 'WAS-Config-APIs' 
		} 


		WindowsFeature Feature-WoW64-Support { 
				Ensure = 'Present' 
				Name = 'WoW64-Support' 
		} 


		Package Package-URLRewrite { 
				Ensure = 'Present' 
				Path = 'http://download.microsoft.com/download/6/7/D/67D80164-7DD0-48AF-86E3-DE7A182D6815/rewrite_2.0_rtw_x64.msi' 
				Name = 'IIS URL Rewrite Module 2' 
				Arguments = '/quiet' 
				ProductId = 'EB675D0A-2C95-405B-BEE8-B42A65D23E11' 
				DependsOn = '[WindowsFeature]Feature-Web-Server' 
		} 
	} 
} 

