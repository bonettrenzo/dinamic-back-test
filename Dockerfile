FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR webapp

EXPOSE 80
EXPOSE 5000

#COPY PROJECT FILE
COPY ./*.csproj ./
RUN dotnet restore

#COPY EVERYTHING ELSE
COPY . .
RUN dotnet publish -c Release -o out

#BUILD IMAGE 
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT ["dotnet", "backend.dll"]
