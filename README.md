# ShopsRUs

This a Bill-Creator Service . Project writed with .Net 6.0 and used Mongo for the selection of database structure.

## Installation

First, you need the clone the repository to a folder of your choice.

```bash
git clone https://github.com/baysalalper/ShopsRUs.git
```

After that, you need to change directory to enter the project folder itself.

```bash
cd ShopsRUs
```

Now you can build and run the project with Docker-Compose. Docker build and start the project and Mongo database for you. It even add the required table and datas for your convinience with mongo-seed commands.

```bash
docker-compose pull
docker-compose up --build -d
```

## Usage

Now your project is up and running. You can use integrated Swagger to use projects APIs.
```bash
http://localhost:5026/swagger/index.html    
```

Followings are the Test data you can use on swagger to test the code:

```bash
UserId: "1" For Employee
UserId: "2" For Affiliate
UserId: "3" For 2 years+ customer with no connection with Company  
```

```bash
ProductSku: "SKU1" Non-Grocery Product with 200 unit-price
ProductSku: "SKU2" Grocery Product with 200 unit-price
```

To stop the containers you can use the following command

```bash
docker-compose down
```
## Contrubitor
Alper BAYSAL