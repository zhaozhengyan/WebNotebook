FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
RUN ls -la
COPY ./ /src
WORKDIR "/src/WebNotebook"
RUN ls -la
FROM build AS publish
RUN dotnet publish "WebNotebook.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebNotebook.dll"]

