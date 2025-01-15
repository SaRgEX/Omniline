### Omniline

## Технологии

- ASP.NET
- EntityFramework
- PostgreSQL

## Библиотеки

- AutoMapper

## Эндпоинты

- [Contact](#contact)
- [Counterparty](#counterparty)

---

## Применение миграций

```sh 
    dotnet ef database update -p ".\Persistence\" -s ".\API\"
```

## Конфигурации

appsettings.Development.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Database": "username=<Имя пользователя>; password=<Пароль>; host=<Сервер>; port=<Порт>; database=contact_db; sslmode=disable"
  }
}
```

## Contact

- GET /Contact
- GET /Contact/{id}
- POST /Contact
- PUT /Contact/{id}
- DELETE /Contact/{id}

## Counterparty

- GET /Counterparty
- GET /Counterparty/{id}
- POST /Counterparty
- PUT /Counterparty/{id}
- DELETE /Counterparty/{id}