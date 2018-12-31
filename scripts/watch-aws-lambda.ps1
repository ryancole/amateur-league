$lambdaDirectory = Resolve-Path "$($PSScriptRoot)\..\packages\aws-lambda"
$graphqlDirectory = "$($lambdaDirectory)\graphql-function"

Start-Process `
    -FilePath "npm" `
    -ArgumentList "run watch" `
    -WorkingDirectory $graphqlDirectory

Start-Process `
    -FilePath "sam" `
    -ArgumentList "build" `
    -WorkingDirectory $lambdaDirectory `
    -Wait

Start-Process `
    -FilePath "sam" `
    -ArgumentList "local start-api" `
    -WorkingDirectory $lambdaDirectory
