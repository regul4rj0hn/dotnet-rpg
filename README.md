```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=RpgGameDB1!" \
   -p 1433:1433 --name rpg-mssql \
   -d mcr.microsoft.com/mssql/server
```