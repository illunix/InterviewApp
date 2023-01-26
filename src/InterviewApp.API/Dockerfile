FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/InterviewApp.API/InterviewApp.API.csproj", "src/InterviewApp.API/"]
COPY ["src/InterviewApp.Core/InterviewApp.Core.csproj", "src/InterviewApp.Core/"]
RUN dotnet restore "src/InterviewApp.API/InterviewApp.API.csproj"
COPY . .
WORKDIR "/src/src/InterviewApp.API"
RUN dotnet build "InterviewApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterviewApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterviewApp.API.dll"]
