# Система управления заказами

## Запуск приложения

Для запуска приложения необходимо поднять базу данных PostgreSQL, запустить backend и frontend.
Backend при старте попытается применить миграции к базе данных, поэтому база данных должна быть доступна при запуске backend.

_Все команды необходимо выполнять из корня проекта._

### Запуск PostgreSQL

```bash
docker run -d --name delivery-orders-db -e POSTGRES_DB=DeliveryOrders -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 postgres:17
```

### Запуск Backend

```bash
cd src/Web.Host
dotnet run --urls "http://localhost:5196"
```

Backend будет доступен по адресу: http://localhost:5196

API endpoints:
- `GET /api/orders` - получить список всех заказов;
- `GET /api/orders/{number}` - получить заказ по номеру;
- `POST /api/orders` - создать новый заказ.

### Запуск Frontend

```bash
cd frontend
npm install
npm run dev
```

Frontend будет доступен по адресу: http://localhost:3000
