$directory = Resolve-Path "$($PSScriptRoot)\..\packages\api"

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run build" `
  -WorkingDirectory $directory `
  -Wait

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run watch" `
  -WorkingDirectory $directory

Start-Process `
  -FilePath "npm" `
  -ArgumentList "start" `
  -WorkingDirectory $directory