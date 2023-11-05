FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExpensesControl.Rdb/ExpensesControl.Rdb.csproj", "ExpensesControl.Rdb/"]
RUN dotnet restore "ExpensesControl.Rdb/ExpensesControl.Rdb.csproj"
COPY . .
WORKDIR "/src/ExpensesControl.Rdb"
RUN dotnet build "ExpensesControl.Rdb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpensesControl.Rdb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpensesControl.Rdb.dll"]
