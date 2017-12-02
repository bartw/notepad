[![Build Status](https://travis-ci.org/bartw/notepad.svg?branch=master)](https://travis-ci.org/bartw/notepad)

# Notepad

## Running notepad locally

Make sure you have [docker](https://www.docker.com/) and a nice terminal.
Open a terminal and execute the following commands:

```shell
docker build -t notepad .
docker run -it --rm --name notepad -p 5001:5001 notepad
```

Now browse to http://localhost:5001/ and you should see the app running.

## Continuous Integration/Delivery

After each push to GitHub, a build on [Travis CI](https://travis-ci.org/bartw/notepad) is started.
Travis CI builds the code and runs the tests. 
If all tests are green, Travis CI will build a Docker image and push it to [Docker Hub](https://hub.docker.com/r/bartw/notepad/) and Heroku.
Heroku runs the image and exposes it at https://dapeton.herokuapp.com/.

## License

Notepad is licensed under the [MIT License](LICENSE).