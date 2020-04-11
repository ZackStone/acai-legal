https://hub.docker.com/_/microsoft-mssql-server

docker pull mcr.microsoft.com/mssql/server

docker run --name sql_server_uds -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=abc12345' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server

docker container start sql_server_uds

sqlcmd -S localhost -U sa -P 'abc12345' -d master
