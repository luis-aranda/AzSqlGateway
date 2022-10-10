# Azure SQL DB Gateway PowerShell Module

This PowerShell binary module helps get the Azure SQL DB Gateways programatically. The gateways are documented [here](https://learn.microsoft.com/en-us/azure/azure-sql/database/connectivity-architecture?view=azuresql#gateway-ip-addresses)

The module reads the documentation on Microsoft Docs and returns PowerShell Objects which are easy to interact with. **In order for this to work properly it requires internet connectivity**

This module has also a cmdlet that helps test communication to the gateways from the machine where this module is installed.

The module supports Windows PowerShell and also cross platform (Linux/Mac)