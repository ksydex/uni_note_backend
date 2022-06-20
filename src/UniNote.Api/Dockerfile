FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/UniNote.Core/UniNote.Core.csproj", "UniNote.Core/"]
COPY ["src/UniNote.Domain/UniNote.Domain.csproj", "UniNote.Domain/"]
COPY ["src/UniNote.Data/UniNote.Data.csproj", "UniNote.Data/"]
COPY ["src/UniNote.Application/UniNote.Application.csproj", "UniNote.Application/"]
COPY ["src/UniNote.Api/UniNote.Api.csproj", "UniNote.Api/"]

RUN dotnet restore "/src/UniNote.Api/UniNote.Api.csproj"
COPY /src .
WORKDIR "/src/UniNote.Api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniNote.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniNote.Api.dll"]
