#Requires -Modules platyPS

Import-Module "$PSScriptRoot\bin\Debug\netstandard2.0\publish\AzSqlGateway.dll"
New-MarkdownHelp -Module AzSqlGateway -OutputFolder "$PSScriptRoot\help"