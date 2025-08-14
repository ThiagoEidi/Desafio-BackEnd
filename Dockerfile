FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["Desafio-BackEnd.csproj", "./"]
RUN dotnet restore "Desafio-BackEnd.csproj"

COPY . .

WORKDIR "/app"
EXPOSE 8080

ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]
