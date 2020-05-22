#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Lil.Search/Lil.Search.csproj", "Lil.Search/"]
RUN dotnet restore "Lil.Search/Lil.Search.csproj"
COPY . .
WORKDIR "/src/Lil.Search"
RUN dotnet build "Lil.Search.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lil.Search.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lil.Search.dll"]
