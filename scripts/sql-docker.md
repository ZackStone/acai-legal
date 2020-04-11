### URL da imagem docker do SQL Server
https://hub.docker.com/_/microsoft-mssql-server

### Download da imagem
docker pull mcr.microsoft.com/mssql/server

### Criar um container com a imagem, passando os parametros de configuração
docker run --name sql_server_uds -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=abc12345' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server

### Rodar o container
docker container start sql_server_uds

### Teste de conexão
sqlcmd -S localhost -U sa -P 'abc12345' -d master
