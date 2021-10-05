FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RunToBeat.Api/RunToBeat.Api.csproj", "RunToBeat.Api/"]
RUN dotnet restore "RunToBeat.Api/RunToBeat.Api.csproj"
COPY . .
WORKDIR "/src/RunToBeat.Api"
RUN dotnet build "RunToBeat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RunToBeat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RunToBeat.Api.dll"]
