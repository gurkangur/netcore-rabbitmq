    docker run -d --hostname my-rabbit --name myrabbit -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=admin -p 5672:5672 -p 15672:15672 rabbitmq:3-management

![Direct exchange](https://www.rabbitmq.com/img/tutorials/intro/exchange-direct.png)

![Fanout exchange](https://www.rabbitmq.com/img/tutorials/intro/exchange-fanout.png)


[AMQP 0-9-1 Model Explained](https://www.rabbitmq.com/tutorials/amqp-concepts.html)
