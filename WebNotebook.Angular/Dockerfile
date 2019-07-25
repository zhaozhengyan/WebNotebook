FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebNotebook.Angular/WebNotebook.Angular.csproj", "WebNotebook.Angular/"]
RUN dotnet restore "WebNotebook.Angular/WebNotebook.Angular.csproj"
COPY . .
WORKDIR "/src/WebNotebook.Angular"
RUN dotnet build "WebNotebook.Angular.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebNotebook.Angular.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebNotebook.Angular.dll"]