docker build -t notepad-frontend .
docker run -it --rm -v C:\Users\bartw\Documents\repos\notepad\frontend\src:/app/src -v C:\Users\bartw\Documents\repos\notepad\frontend\dist:/app/dist notepad-frontend

docker build -t notepad-backend-test .
docker run -it --rm --name notepad-backend-test -v C:\Users\bartw\Documents\repos\notepad\backend:/app notepad-backend-test

docker run -it --rm -v C:\Users\bartw\Documents\repos\notepad\backend:/app -e DOTNET_USE_POLLING_FILE_WATCHER=1 microsoft/dotnet:sdk
dotnet restore watch.proj
dotnet msbuild watch.proj /t:Test

docker image prune

https://stackoverflow.com/a/42608990

```shell
docker run -it --rm -v C:\Users\bartw\Documents\repos\notepad\:/travis ruby /bin/bash
gem install travis
wget -qO- https://cli-assets.heroku.com/install-ubuntu.sh | sh
heroku login
heroku auth:token
cd travis
travis encrypt "DOCKER_USERNAME=super_\\\$$ecret" --add env.global
```

docker build -t notepad -f Dockerfile .
docker run -it --rm --name notepad -p 5001:5001 -v C:\Users\bartw\Documents\repos\notepad\backend:/app notepad
