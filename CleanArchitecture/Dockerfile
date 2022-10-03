#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CleanArchitecture/CleanArchitecture.csproj", "CleanArchitecture/"]
COPY ["CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj", "CleanArchitecture.Infrastructure/"]
COPY ["CleanArchitecture.Core/CleanArchitecture.Core.csproj", "CleanArchitecture.Core/"]
COPY ["CleanArchitecture.Application/CleanArchitecture.Application.csproj", "CleanArchitecture.Application/"]
RUN dotnet restore "CleanArchitecture/CleanArchitecture.csproj"
COPY . .
WORKDIR "/src/CleanArchitecture"
RUN dotnet build "CleanArchitecture.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.dll"]
