# Sistema de Estacionamento

## Descrição
Este projeto é um **Sistema de Gerenciamento de Estacionamento** desenvolvido em **C#**, com integração ao banco de dados **MySQL**. O sistema permite o registro de entrada e saída de veículos, realização de consultas detalhadas, atualização e exclusão de registros, além da geração de relatórios gerenciais. Ele também calcula automaticamente as tarifas de estacionamento com base na duração de permanência dos veículos.

## Funcionalidades Principais

- **Registro de Entrada de Veículos**  
  Permite registrar a entrada de veículos no estacionamento com os seguintes dados:  
  - Nome do cliente.  
  - Tipo de veículo (Carro, Caminhão, Moto).  
  - Nome do veículo.  
  - Cor.  
  - Placa.  
  Além disso, o sistema verifica a disponibilidade de vagas antes de registrar a entrada.

- **Registro de Saída de Veículos**  
  Realiza o checkout de um veículo, calculando automaticamente:  
  - O tempo de permanência.  
  - O valor a ser pago com base na tarifa configurada.  
  Após o checkout, o status do cliente é atualizado e a vaga utilizada é liberada.

- **Consultas de Estacionamento**  
  Permite realizar consultas detalhadas com base em critérios como:  
  - Data de entrada.  
  - Mês de entrada.  
  - Nome do veículo.  
  - Tipo de veículo.  
  - Registros históricos.  
  - Veículos atualmente estacionados.

- **Exibição de Tarifas**  
  Exibe as regras tarifárias, incluindo:  
  - Tarifa básica por minuto.  
  - Tarifas fixas para períodos específicos (exemplo: entre 8 e 12 horas).  
  - Exemplos práticos de cálculo com base no tempo de permanência e tipo de veículo.

- **Geração de Relatórios**  
  Gera relatórios detalhados que incluem:  
  - Quantidade total e mensal de veículos atendidos.  
  - Receita total e por mês.  
  - Tempo médio de permanência dos veículos.  
  - Relatórios gerenciais úteis para a administração.

- **Configurações do Sistema**  
  Funcionalidade administrativa para:  
  - Alterar a capacidade de vagas do estacionamento por tipo de veículo.  
  - Modificar o valor da tarifa por minuto.

## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Banco de Dados**: MySQL
- **Bibliotecas**:  
  - Microsoft.EntityFrameworkCore  
  - MySql.Data.EntityFrameworkCore
- **Conceitos**:  
  - Programação orientada a objetos  
  - Entity Framework  
  - Manipulação de banco de dados com ADO.NET

## Como Executar

1. Clone o repositório do projeto:
    ```bash
    git clone https://github.com/parthur207/Sistema-de-Estacionamento.git
    ```

2. Abra o projeto em sua IDE e configure a string de conexão com o banco de dados MySQL. Crie o banco de dados conforme o arquivo presente na branch **Master** (`MySql.txt`).

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
- **Console_Main**: Contém o método `Main()`, que controla o fluxo da aplicação e gerencia as interações com o usuário.

## Contato

- **Email**: [parthur207@gmail.com]
- **Telefone**: (31) 9 89650-0406
- **LinkedIn**: [www.linkedin.com/in/paulo-andrade-836956237](https://www.linkedin.com/in/paulo-andrade-836956237)
