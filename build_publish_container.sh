image="bartw/notepad:"$TRAVIS_BUILD_NUMBER 
docker build -t $image .
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push $image
docker login -u=$HEROKU_USERNAME -p=$HEROKU_AUTH_TOKEN registry.heroku.com;
docker tag $image registry.heroku.com/dapeton/web;
docker push registry.heroku.com/dapeton/web;