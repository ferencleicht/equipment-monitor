FROM mcr.microsoft.com/dotnet/sdk:9.0-noble AS build
WORKDIR /source

COPY . .
RUN dotnet restore

RUN dotnet publish --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0-noble-chiseled AS runtime
WORKDIR /app
COPY --from=build /app .

EXPOSE 5000

ENTRYPOINT [ "dotnet", "Api.dll" ]
