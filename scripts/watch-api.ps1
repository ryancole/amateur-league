$functionsApplicationBuildPath = Resolve-Path "$($PSScriptRoot)\..\packages\api"

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run build" `
  -WorkingDirectory $functionsApplicationBuildPath `
  -Wait

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run watch" `
  -WorkingDirectory $functionsApplicationBuildPath

Start-Process `
  -FilePath "sam" `
  -ArgumentList "local start-api --template template.json" `
  -WorkingDirectory $functionsApplicationBuildPath