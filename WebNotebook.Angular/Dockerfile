FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
# Setup NodeJs
RUN apt-get update && \
    apt-get npm && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
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