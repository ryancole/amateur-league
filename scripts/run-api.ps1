$functionsApplicationBuildPath = Resolve-Path "$($PSScriptRoot)\..\packages\api"

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run build" `
  -WorkingDirectory $functionsApplicationBuildPath `
  -Wait

Start-Process `
  -FilePath "sam" `
  -ArgumentList "local start-api" `
  -WorkingDirectory $functionsApplicationBuildPath