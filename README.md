# T_Komp_proj

### Task

Celem aplikacji będzie połączenie się z bazą danych MS SQL Server (może być Express) używając loginu
oraz hasła i odczytanie z tabel systemowych listy kolumn należących do obiektów będących w bazie
danych DEV_DATA_1.
Należy pobrać tylko kolumny typu int.

Pobrane dane dotyczące powyższych obiektów pokazać w DataGrid lub podobnej kontrolce na oknie
głównym aplikacji.
Na oknie głównym aplikacji powinny się też znaleźć pola loginu i hasła do połączenia z bazą danych
oraz przycisk Testuj połączenie. Po jego naciśnięciu ma się wyświetlić informacja czy połączenie się
udało.


I use docker to setup the express database 

RUN DOKCER INSTANTION: 

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD={{YourPassword}}" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest 


SQL DATABASE SETUP: 

```sql
CREATE DATABASE DEV_DATA_1

CREATE TABLE DEV_DATA_1.dbo.Table_A (Col_A1 int, Col_A2 varchar(10), Col_A3 date);
CREATE TABLE DEV_DATA_1.dbo.Table_B (Col_B1 int, Col_B2 nchar(10), Col_B3 int);
CREATE TABLE DEV_DATA_1.dbo.Table_C (Col_C1 varchar(10), Col_C2 timestamp, Col_C3 int,
Col_C4 char(10) );
```
