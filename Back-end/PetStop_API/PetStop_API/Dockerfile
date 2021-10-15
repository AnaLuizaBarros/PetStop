#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PetStop_API/PetStop_API.csproj", "PetStop_API/"]
RUN dotnet restore "PetStop_API/PetStop_API.csproj"
COPY . .
WORKDIR "/src/PetStop_API"
RUN dotnet build "PetStop_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetStop_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetStop_API.dll"]

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet PetStop_API.dll