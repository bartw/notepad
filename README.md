# Notepad

docker build -t notepad-frontend .
docker run -it --rm -v C:\Users\bartw\Documents\repos\notepad\frontend\src:/app/src -v C:\Users\bartw\Documents\repos\notepad\frontend\dist:/app/dist notepad-frontend

docker build -t notepad-backend-test .
docker run -it --rm --name notepad-backend-test -v C:\Users\bartw\Documents\repos\notepad\backend:/app notepad-backend-test

docker run -it --rm -v C:\Users\bartw\Documents\repos\notepad\backend:/app -e DOTNET_USE_POLLING_FILE_WATCHER=1 microsoft/dotnet:sdk
dotnet restore watch.proj
dotnet msbuild watch.proj /t:Test

remove dangling images on windows:
FOR /f "tokens=*" %i IN ('docker images -q -f "dangling=true"') DO docker rmi %i

## License

Notepad is licensed under the [MIT License](LICENSE).