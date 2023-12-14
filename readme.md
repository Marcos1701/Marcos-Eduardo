## Projeto Final de Análise e Projeto de Sistemas

### Instruções para execução do projeto

#### 1. Se possuir o docker instalado, execute o comando abaixo para criar a imagem do banco de dados:

```bash
docker run --name mysql-db -p 3307:3306 -e MYSQL_ROOT_PASSWORD=ifpi -e MYSQL_DATABASE=appcsharp -d mariadb:latest
```

#### 1.1 caso contrario, instale o mysql e crie um banco de dados com o nome appcsharp, usuário root e senha ifpi

#### 2. Execução do projeto

```bash
dotnet restore
dotnet build
dotnet run
```

#### 3. Acesse o endereço fornecido pelo terminal

#### 4. Seja Feliz :D