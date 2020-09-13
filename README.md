# Microservices Starter Kit

| Services                 | Description                                        |
| ------------------------ | -------------------------------------------------- |
| Product Catalog API      | ASP.NET Core Web API, MongoDB                      |
| Shopping Cart Basket API | ASP.NET Core Web API, Redis                        |
| Order API                | ASP.NET Core Web API, SQL Server, MediatR for CQRS |
| Message Broker           | RabbitMQ                                           |
| API Gateway              | Ocelet                                             |

### Launch the solution

`❯ docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up --build`

### API URLs

| Services                 | Description                              |
| ------------------------ | ---------------------------------------- |
| Product Catalog API      | http://localhost:5000/swagger/index.html |
| Shopping Cart Basket API | http://localhost:5001/swagger/index.html |
| Order API                | http://localhost:5002/swagger/index.html |
| Message Broker \*        | http://localhost:15672/#/queues          |
| MS SQL \*\*              | Access using SSMS                        |

\*Message Broker - Username: guest, Password: guest

\*\*MS SQL - Server name: (lcoal), Username: sa, Password: Pa\$\$w0rd

---

Alternaively, you can run following docker commands if you prefer to start containers individually.

| Services  | Description                                                                                                    |
| --------- | -------------------------------------------------------------------------------------------------------------- |
| MongoDB   | docker run -d -p 27017:27017 --name msk-mongo mongo                                                            |
| Redis     | docker run -d -p 6379:6379 --name msk-redis redis                                                              |
| Rabbit MQ | docker run -d --hostname my-rabbit --name some-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management-alpine |
| MS SQL    | docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pa\$\$w0rd' -p 1433:1433 -d mcr.microsoft.com/mssql/server       |

Note: If you already run those, next time you just use `docker ps -a`, get the container id and `docker start <CONTAINER ID>`.

### Troubleshooting

If some containers such as SQL are not loading properly, use the following commands

Stop all containers

`> docker ps`

`> docker stop <CONTAINER ID>`

Remove all containers

`> docker ps -a`

`> docker rm <CONTAINER ID>`

Remove all images

`> docker images`

`> docker rmi <IMAGE ID>`
