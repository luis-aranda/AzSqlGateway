$OutputPath = "$PSScriptRoot\bin\Release\netstandard2.0\publish"

task Build {
    Set-Location $PSScriptRoot
    
    dotnet publish -c Release

    Copy-Item "$PSScriptRoot\AzSqlGateway.psd1" -Destination "$OutputPath"
}

task Publish {
    Rename-Item -Path $OutputPath -NewName "AzSqlGateway"
    $ModulePath = "$PSScriptRoot\bin\Release\netstandard2.0\AzSqlGateway"
    Publish-Module -Path $ModulePath -NuGetApiKey $Env:APIKEY
}

task . Build