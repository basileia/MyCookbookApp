FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./MyCookbook/
COPY ./MyCookbook/MyCookbook/*.csproj ./MyCookbook/MyCookbook/
COPY ./MyCookbook/MyCookbook.Client/*.csproj ./MyCookbook/MyCookbook.Client/
COPY ./MyCookbook/MyCookbook.Shared/*.csproj ./MyCookbook/MyCookbook.Shared/

RUN dotnet restore

COPY . .

RUN dotnet build -c Release --no-restore

RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyCookbook.dll"]  
