FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExpensesControl.Services/ExpensesControl.Services.csproj", "ExpensesControl.Services/"]
RUN dotnet restore "ExpensesControl.Services/ExpensesControl.Services.csproj"
COPY . .
WORKDIR "/src/ExpensesControl.Services"
RUN dotnet build "ExpensesControl.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpensesControl.Services.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpensesControl.Services.dll"]
