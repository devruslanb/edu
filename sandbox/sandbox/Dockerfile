FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["sandbox/sandbox.csproj", "sandbox/"]
RUN dotnet restore "sandbox/sandbox.csproj"
COPY . .
WORKDIR "/src/sandbox"
RUN dotnet build "sandbox.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "sandbox.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sandbox.dll"]
