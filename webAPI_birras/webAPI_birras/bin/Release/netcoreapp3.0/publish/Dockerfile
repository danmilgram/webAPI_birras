FROM mcr.microsoft.com/dotnet/core/sdk:2.2.300-alpine3.9 as server

ENV ASPNETCORE_Environment=Production
ENV ASPNETCORE_URLS http://+:5000

WORKDIR /server
VOLUME ./wwwroot/Repository
COPY . ./

RUN dotnet publish -c Release -o publish

EXPOSE 5000/tcp

ENTRYPOINT ["dotnet","publish/Project.dll"]