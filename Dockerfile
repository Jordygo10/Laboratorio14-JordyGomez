FROM mcr.microsoft.com/dotnet/sdk:8.0.428 AS build
WORKDIR /src

COPY global.json Laboratorio14-JordyGomez.csproj ./
RUN dotnet restore Laboratorio14-JordyGomez.csproj

COPY . .
RUN dotnet publish Laboratorio14-JordyGomez.csproj -c Release --no-restore -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Laboratorio14-JordyGomez.dll"]
