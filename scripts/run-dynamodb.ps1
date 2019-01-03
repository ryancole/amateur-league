$directory = "C:\Users\Ryan\AppData\Local\Programs\dynamodb"

Start-Process `
    -FilePath "java" `
    -ArgumentList "-Djava.library.path=DynamoDBLocal_lib -jar DynamoDBLocal.jar -inMemory -sharedDb -port 8001" `
    -WorkingDirectory $directory
