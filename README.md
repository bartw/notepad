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

## License

Notepad is licensed under the [MIT License](LICENSE).