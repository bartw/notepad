FROM microsoft/dotnet:sdk

ENV DOTNET_USE_POLLING_FILE_WATCHER 1

WORKDIR /app

COPY . .
RUN ./restore.sh

CMD ["/bin/bash", "./watchTest.sh"]