$funcApplicationPath = "$($env:USERPROFILE)\AppData\Local\AzureFunctionsTools\Releases\2.15.0\cli\func.exe"
$functionsApplicationBuildPath = Resolve-Path "$($PSScriptRoot)\..\src\LeagueApiFunction\bin\Debug\netcoreapp2.1"

Start-Process `
  -FilePath $funcApplicationPath `
  -ArgumentList "host start" `
  -WorkingDirectory $functionsApplicationBuildPath