FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mail/Mail.csproj", "Mail/"]
RUN dotnet restore "Mail/Mail.csproj"
COPY . .
WORKDIR "/src/Mail"
RUN dotnet build "Mail.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mail.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mail.dll"]
