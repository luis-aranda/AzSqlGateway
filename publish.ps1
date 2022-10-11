$ModulePath = "$PSScriptRoot\bin\Release\netstandard2.0\publish"
Publish-Module -Path $ModulePath -NuGetApiKey $env:APIKEY