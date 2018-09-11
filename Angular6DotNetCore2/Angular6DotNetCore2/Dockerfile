#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54676
EXPOSE 44329

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Angular6DotNetCore2/Angular6DotNetCore2.csproj", "Angular6DotNetCore2/"]
RUN dotnet restore "Angular6DotNetCore2/Angular6DotNetCore2.csproj"
COPY . .
WORKDIR "/src/Angular6DotNetCore2"
RUN dotnet build "Angular6DotNetCore2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Angular6DotNetCore2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Angular6DotNetCore2.dll"]