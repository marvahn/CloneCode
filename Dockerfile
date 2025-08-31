FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Debug -o ./publish

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
ENV ASPNETCORE_URLS=http://0.0.0.0:3000
WORKDIR /app
COPY --from=build ./app/publish .

EXPOSE 3000

ENTRYPOINT ["dotnet", "CloneCode.dll"]