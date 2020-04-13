# Imagem para o build usando o sdk
FROM microsoft/dotnet:2.1-sdk-alpine AS build-env
WORKDIR /app

# Seta caminho do .csproj
ARG PROJ_PATH="./1 - Application/AcaiLegal.Application"
ARG CSPROJ=${PROJ_PATH}/AcaiLegal.Application.csproj

# Copia o código fonte e roda o build
COPY . ./
RUN dotnet publish "${CSPROJ}" -c Release -o /app/out

# Imagem para a execução usando o runtime
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app

# Copia os arquivos do build e inicia a aplicação
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AcaiLegal.Application.dll"]
