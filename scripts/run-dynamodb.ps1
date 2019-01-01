$directory = "C:\Users\Ryan\AppData\Local\Programs\dynamodb"
$databasePath = Resolve-Path "$($PSScriptRoot)\.."

Start-Process `
  -FilePath "java" `
  -ArgumentList "-Djava.library.path=DynamoDBLocal_lib -jar DynamoDBLocal.jar -sharedDb -port 9000 -dbPath $($databasePath)" `
  -WorkingDirectory $directory
