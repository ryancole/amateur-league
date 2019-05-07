$data = "$($PSScriptRoot)\..\data"

New-Item -ItemType Directory -Path $data -Force

docker run -v "$($data):/data" -p 8000:8000 dwmkerr/dynamodb -dbPath /data -sharedDb