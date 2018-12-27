$projectRootPath = Resolve-Path "$($PSScriptRoot)\.."

# path to our http api server project folder
$httpApiProjectPath = Resolve-Path "$($PSScriptRoot)\..\src\LeagueHttpApi"

Start-Process `
  -FilePath "dotnet" `
  -ArgumentList "run" `
  -WorkingDirectory $httpApiProjectPath
