$functionsApplicationBuildPath = Resolve-Path "$($PSScriptRoot)\..\packages\graphql"

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run build" `
  -WorkingDirectory $functionsApplicationBuildPath `
  -Wait

Start-Process `
  -FilePath "npm" `
  -ArgumentList "start" `
  -WorkingDirectory $functionsApplicationBuildPath