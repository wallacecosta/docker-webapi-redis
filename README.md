# docker-webapi-redis
Exemplo de WebApi com Redis e Docker

# Dependências

- SDK .NET 6.0
- Docker
- IDE de preferência (nesse caso utilizei VS Code)

# Desenvolvimento

Feito o clone somente executar na raíz do projeto o seguinte:

- Executando o comando abaixo serão geradas as imagens, build e o ambiente estará pronto

    ```
    docker-compose up -d --build

- Agora é só verificar o endpoint para observar a aplicação executando, pode ser utilizado alguma aplicação como Postman ou mesmo via navegador.

    ```
    http://localhost:5555/swagger/index.html
    ```

