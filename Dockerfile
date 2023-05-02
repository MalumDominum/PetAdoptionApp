FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . ./

# Remove test project lines from solution file
RUN dotnet sln remove tests/PetAdoptionApp.FunctionalTests/PetAdoptionApp.FunctionalTests.csproj \
 && dotnet sln remove tests/PetAdoptionApp.IntegrationTests/PetAdoptionApp.IntegrationTests.csproj \
 && dotnet sln remove tests/PetAdoptionApp.UnitTests/PetAdoptionApp.UnitTests.csproj

RUN dotnet restore

COPY . ./
RUN dotnet publish src/PetAdoptionApp.Api/PetAdoptionApp.Api.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/publish ./
ENTRYPOINT ["dotnet", "PetAdoptionApp.Api.dll"]