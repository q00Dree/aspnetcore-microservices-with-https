FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./ ./

RUN dotnet publish ./FirstService/Sample.FirstService/Sample.FirstService.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/out .

# By default, ASPNETCORE uses port 80, but if you need to expose an other port, like 5001, 
# you should use line below or use method webBuilder.UseUrls(urls: "http://0.0.0.0:5001") in Program.cs, while configuring IHostBuilder or configure Kestrel in appsettings.json

# ENV ASPNETCORE_URLS=http://0.0.0.0:5001

ENTRYPOINT ["dotnet", "Sample.FirstService.dll"]

# No need to expose port 5001, because we do this in docker-compose.yml file. 
# If you run 'docker build' with this file so you can uncomment line below or use -p flag instead. 

# EXPOSE 5001