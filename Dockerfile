FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /app

# Copy the project file
COPY *.sln ./
COPY ShipServiceManagement.App/*.csproj ./ShipServiceManagement.App/
COPY ShipServiceManagement.Logic/*.csproj ./ShipServiceManagement.Logic/
COPY ShipServiceManagement.Messaging/*.csproj ./ShipServiceManagement.Messaging/
COPY ShipServiceManagement.Models/*.csproj ./ShipServiceManagement.Models/
COPY ShipServiceManagement.Persistence/*.csproj ./ShipServiceManagement.Persistence/

# Restore the packages
RUN dotnet restore

# Copy everything else
COPY . ./
WORKDIR /app/ShipServiceManagement.App

FROM build AS publish
# Build the release
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM microsoft/dotnet:2.0-runtime AS runtime
WORKDIR /app

# Copy the output from the build env
COPY --from=publish /app/ShipServiceManagement.App/out ./

ENTRYPOINT [ "dotnet", "ShipServiceManagement.App.dll" ]