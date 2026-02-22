# Stage 1: Build Vue frontend
FROM node:20-alpine AS frontend-build
WORKDIR /app
COPY pcmaintenance.client/package*.json ./
RUN npm ci
COPY pcmaintenance.client/ .
RUN npm run build

# Stage 2: Build and publish PcMaintenance.Server
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src
COPY PcMaintenance.sln .
COPY PcMaintenance.Server/PcMaintenance.Server.csproj PcMaintenance.Server/
RUN dotnet restore PcMaintenance.Server
COPY PcMaintenance.Server/ PcMaintenance.Server/
RUN dotnet publish PcMaintenance.Server -c Release -o /out --no-restore

# Stage 3: Runtime – backend din publish, frontend din frontend-build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /out .
COPY --from=frontend-build /app/dist ./dist
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "PcMaintenance.Server.dll"]
