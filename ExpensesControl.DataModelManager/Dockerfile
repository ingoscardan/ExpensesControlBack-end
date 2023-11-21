FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExpensesControl.DataModelManager/ExpensesControl.DataModelManager.csproj", "ExpensesControl.DataModelManager/"]
RUN dotnet restore "ExpensesControl.DataModelManager/ExpensesControl.DataModelManager.csproj"
COPY . .
WORKDIR "/src/ExpensesControl.DataModelManager"
RUN dotnet build "ExpensesControl.DataModelManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpensesControl.DataModelManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpensesControl.DataModelManager.dll"]
