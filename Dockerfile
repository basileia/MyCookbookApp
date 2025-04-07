FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY MyCookbook/*.csproj ./MyCookbook/
COPY MyCookbook.Client/*.csproj ./MyCookbook.Client/
COPY MyCookbook.Shared/*.csproj ./MyCookbook.Shared/

RUN dotnet restore

COPY . .

RUN dotnet build -c Release --no-restore

RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyCookbook.dll"]  
