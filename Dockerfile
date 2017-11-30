FROM node:alpine as frontend-build
WORKDIR /frontend
COPY ./frontend/package.json .
COPY ./frontend/package-lock.json .
RUN npm install
COPY ./frontend .
RUN npm run build:docker:prod

FROM microsoft/dotnet:sdk as backend-build
WORKDIR /backend
COPY ./backend .
WORKDIR Notes.Web
RUN dotnet restore
COPY --from=frontend-build /frontend/dist wwwroot
RUN dotnet publish -c Release

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=backend-build  /backend/Notes.Web/bin/Release/netcoreapp2.0/publish .
ENTRYPOINT ["dotnet", "Notes.Web.dll"]