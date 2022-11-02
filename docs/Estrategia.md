# Estratégia Inicial

## Itens avaliados
- Orientação a objeto
- Qualidade de código
- Aplicação de padrões
- Resiliência
- Disponibilidade
- Performance
- Capacidade de monitoramento
- Testes em suas diversas formas
- Bom uso do Git (clareza dos commits, divisão do trabalho e melhores práticas). 

## Requisitos de projeto
- Repositório no Github
- Sem necessidade de ferramentas externas
- Testes unitários

## Funcionalidades
- Cadastro de funcionários
- Informar montante disponível para distribução
- Repartição dos lucros com os funcionários

### Relatório do Cálculo
- Quanto cada colaborador deve receber
- Total de funcionários
- Total distribuído
- Total disponibilizado (Valor que a empresa desejava distribuir)
- Relação entre o total distribuido contra total disponibilizado

## Regra de distribução

- Peso A: 1 a 4
- Peso B: 1 a 5
- Peso C: 1 a 4

Fórmula:
```
((((Salário Bruto * Peso A) + (Salário Bruto * Peso B)) / (Salário Bruto * Peso C)) * 12 meses
```
Peso A: PTA = Peso por tempo de admissao

Peso B: PAA = Peso por area de atuacao

Peso C: PFS = Peso por faixa salarial


## Decisões do projeto
- API em .NET 6
- Testes unitários em XUnit e FluentAssertions
- React
- OpenAPI (Swagger)
- SQLite?

- Logs?
- Auditoria?
- Escalabilidade?

### Entidades
- Funcionario
    Matrícula, Nome, Área de Atuação, Cargo, Salario Bruto, Data de Admissão, Ativo?
- DistribuicaoDisponivel
    Montante disponível para distribução, Data de Criação    
- Pesos
    Tipo Peso, Valor

- RelatorioDistribuicao
    Total de Funcionarios, Total Disponibilizado, Total distribuído, Relação entre o total distribuido contra total disponibilizado, Data de Criação
- RelatorioDistribuicao_Funcionario
    Matricula, Área de Atuação, Cargo, Salario Bruto, Valor Distribuido, Valor Total, Data de Criação
- RelatorioDistribuicao_Peso
    Tipo Peso, Valor, Data de Criação

### Telas
- Cadastro de Funcionários
    + CRUD de Funcionários
- Configuração do Cálculo
    + Valor do total disponibilizado
    + Pesos?
- Relatório de Distribuição
    + Geração do Relatório
    + Histórico
- Sobre ou Início
    + Introdução da aplicação
    + Divulgação do contato
