FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY src/Interview.Demo.Domain/Interview.Demo.Domain.csproj ./src/Interview.Demo.Domain/
COPY src/Interview.Demo.Application/Interview.Demo.Application.csproj ./src/Interview.Demo.Application/
COPY src/Interview.Demo.Infrastructure/Interview.Demo.Infrastructure.csproj ./src/Interview.Demo.Infrastructure/
COPY src/Interview.Demo.Api/Interview.Demo.Api.csproj ./src/Interview.Demo.Api/
RUN dotnet restore ./src/Interview.Demo.Api/Interview.Demo.Api.csproj

COPY . ./
RUN dotnet publish ./src/Interview.Demo.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
EXPOSE 5432
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Interview.Demo.Api.dll"]
