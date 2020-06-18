#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["NetCoreWebApiArchitectureDemo/NetCoreWebApiArchitectureDemo.csproj", "NetCoreWebApiArchitectureDemo/"]
RUN dotnet restore "NetCoreWebApiArchitectureDemo/NetCoreWebApiArchitectureDemo.csproj"
COPY . .
WORKDIR "/src/NetCoreWebApiArchitectureDemo"
RUN dotnet build "NetCoreWebApiArchitectureDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreWebApiArchitectureDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreWebApiArchitectureDemo.dll"]