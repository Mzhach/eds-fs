FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["SimpleStorage/SimpleStorage.csproj", "SimpleStorage/"]
RUN dotnet restore "SimpleStorage/SimpleStorage.csproj"
COPY . .
WORKDIR "/src/SimpleStorage"
RUN dotnet build "SimpleStorage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleStorage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleStorage.dll"]