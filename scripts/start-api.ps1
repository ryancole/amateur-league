$directory = Resolve-Path "$($PSScriptRoot)\..\packages\api"

Start-Process `
  -FilePath "npm" `
  -ArgumentList "start" `
  -WorkingDirectory $directory