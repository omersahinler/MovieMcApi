FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80

COPY src/Domain/MovieAPI.Domain.Core/*.csproj ./Domain/MovieAPI.Domain.Core/
COPY src/Domain/MovieAPI.Domain/*.csproj ./Domain/MovieAPI.Domain/
COPY src/Infrastructure/MovieAPI.Infrastructure/*.csproj ./Infrastructure/MovieAPI.Infrastructure/
COPY src/Application/MovieAPI.Application/*.csproj ./Application/MovieAPI.Application/
COPY src/Presentation/MovieAPI.Api/*.csproj ./Presentation/MovieAPI.Api/

COPY ./*.sln .

RUN dotnet restore Presentation/MovieAPI.Api/*.csproj
COPY . .
RUN dotnet publish src/Presentation/MovieAPI.Api/*.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MovieAPI.Api.dll"]