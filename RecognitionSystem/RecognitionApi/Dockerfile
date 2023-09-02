FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RecognitionApi/RecognitionApi.csproj", "RecognitionApi/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
RUN dotnet restore "RecognitionApi/RecognitionApi.csproj"
COPY . .
WORKDIR "/src/RecognitionApi"
RUN dotnet build "RecognitionApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecognitionApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecognitionApi.dll"]
