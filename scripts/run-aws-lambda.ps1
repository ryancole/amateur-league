$lambdaDirectory = Resolve-Path "$($PSScriptRoot)\..\packages\aws-lambda"
$graphqlDirectory = "$($lambdaDirectory)\graphql-function"

Start-Process `
  -FilePath "npm" `
  -ArgumentList "run build" `
  -WorkingDirectory $graphqlDirectory `
  -Wait

Start-Process `
  -FilePath "sam" `
  -ArgumentList "build" `
  -WorkingDirectory $lambdaDirectory `
  -Wait

Start-Process `
  -FilePath "sam" `
  -ArgumentList "local start-api" `
  -WorkingDirectory $lambdaDirectory
