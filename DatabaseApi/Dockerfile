#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
RUN sed -i '/MinProtocol/d' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["DatabaseApi/DatabaseApi.csproj", "DatabaseApi/"]
COPY ["DataBase/DataBase.csproj", "DataBase/"]
RUN dotnet restore "DatabaseApi/DatabaseApi.csproj"
COPY . .
WORKDIR "/src/DatabaseApi"
RUN dotnet build "DatabaseApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DatabaseApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatabaseApi.dll"]