FROM microsoft/dotnet:sdk

ENV DOTNET_USE_POLLING_FILE_WATCHER 1

WORKDIR /app
COPY Notes.Data.EfCore/Notes.Data.EfCore.csproj Notes.Data.EfCore/
COPY Notes.Domain/Notes.Domain.csproj Notes.Domain/
COPY Notes.Web/Notes.Web.csproj Notes.Web/

RUN dotnet restore Notes.Web/Notes.Web.csproj

COPY . .

WORKDIR Notes.Web

EXPOSE 5001:5001

CMD ASPNETCORE_URLS=http://*:5001 dotnet watch run