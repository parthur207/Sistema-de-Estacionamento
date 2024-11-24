# Sistema de Estacionamento

## Descrição
Este projeto é um sistema de gerenciamento de estacionamento desenvolvido em **C#** com integração ao banco de dados **MySQL**. O sistema permite registrar a entrada e saída de veículos, realizar consultas detalhadas, atualizar dados, excluir registros e gerar relatórios gerenciais. Ele também calcula automaticamente as tarifas de estacionamento com base na duração de permanência dos veículos.

## Funcionalidades Principais

### 1. Registro de Entrada de Veículos
Permite registrar a entrada de veículos no estacionamento com os seguintes dados:
- **Nome do cliente**
- **Tipo de veículo** (Carro, Caminhão, Moto)
- **Nome do veículo**
- **Cor**
- **Placa**

### 2. Registro de Saída de Veículos
Realiza o checkout de um veículo, calculando automaticamente o tempo de permanência e o valor a ser pago com base na tarifa configurada. Atualiza o status do cliente e a disponibilidade de vagas.

### 3. Consultas de Estacionamento
Permite realizar consultas detalhadas com base em critérios como:
- Data de entrada
- Mês de entrada
- Nome do veículo
- Tipo do veículo

### 4. Exibição de Tarifas
Exibe a tarifa de estacionamento com base no tempo de permanência e tipo de veículo. Calcula automaticamente o valor a ser pago no momento do checkout.

### 5. Geração de Relatórios
Gera relatórios detalhados, incluindo:
- Quantidade de veículos por mês
- Receita total e por mês
- Tempo médio de permanência
- Relatórios gerenciais sobre o uso do estacionamento

### 6. Verificação Automática de Expiração
O sistema verifica se as tarefas pendentes (veículos estacionados) estão expiradas, comparando a data de saída registrada com a data atual e alterando automaticamente o status de "Pendente" para "Expirada".

## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Banco de Dados**: MySQL
- **Bibliotecas**: Microsoft.EntityFrameworkCore, MySql.Data.EntityFrameworkCore
- **Conceitos**: Programação orientada a objetos, Entity Framework, Manipulação de banco de dados com ADO.NET

## Como Executar

1. Clone o repositório do projeto:
    ```bash
    git clone https://github.com/seu-repositorio/Sistema-de-Estacionamento.git
    ```

2. Abra o projeto em sua IDE e configure a string de conexão com o banco de dados MySQL. É necessário criar o banco de dados conforme o arquivo presente na branch Master 'MySql.txt'.

3. Compile e execute o projeto para começar a gerenciar o estacionamento.

## Estrutura do Projeto

- **AtributesClient**: Define os atributos do cliente, como credencial de acesso, nome, entrada, saída, tempo estacionado e valor devido.
- **AtributesVehicle**: Contém as informações do veículo, como tipo, nome, cor e placa.
- **AtributesParking**: Gerencia os dados do estacionamento, incluindo número total e disponível de vagas e a taxa por minuto.
- **MyDbContext**: Gerencia a conexão com o banco de dados e mapeia as tabelas para as classes de atributos.
- **FinalValue**: Calcula os valores a serem pagos com base no período de permanência e nas tarifas.
- **Query_specific_EF**: Implementa consultas detalhadas com base nos critérios fornecidos.
- **Reports**: Gera relatórios gerenciais sobre o uso do estacionamento.
- **Tariffs**: Exibe as tarifas atuais e realiza o cálculo do valor devido.
- **Console_Main**: Contém o método Main, que controla o fluxo da aplicação e gerencia as interações com o usuário.

## Contato
- **Email**: [parthur207@gmail.com]
- **Telefone**: (31) 9 89650-0406
- **LinkedIn**: [www.linkedin.com/in/paulo-andrade-836956237]
