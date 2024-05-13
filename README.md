# fiap.tech-challenge.fast-food.infra.cognito

Este reposit�rio � respons�vel por manter AWS Lambda de autentica��o da aplica��o [**_Fast Food API_**](https://github.com/leandrocamara/fiap.tech-challenge.fast-food.api).

## Execu��o

Ap�s a execu��o dos [_Workflows_](https://github.com/leandrocamara/fiap.tech-challenge.fast-food.lambda.auth/actions) (GitHub Actions), uma AWS Lambda [**_Lambda_**](https://docs.aws.amazon.com/lambda/) � provisionada na _AWS_.

H� duas maneiras de executar e criar a lambda:

1. Realizando um `push` na `main`, por meio de um `Merge Pull Request`;

2. Executando o [_Manual Deployment_](https://github.com/leandrocamara/fiap.tech-challenge.fast-food.lambda.auth/actions/workflows/manual-deployment.yaml) (_Workflow_)

    ![Manual Deployment](./docs/manual-deployment.png)

    2.1. Por padr�o, o _Workflow_ utilizar� as `Secrets` configuradas no projeto. Caso esteja utilizando o `AWS Academy`, recomenda-se informar as credencias da conta. **Obs.:** Cada sess�o do _AWS Academy_ dura **4 horas**.



## Tech Challenge
Projeto para a curso de [P�s Gradua��o FIAP - Software Architecture](https://postech.fiap.com.br/curso/software-architecture/).

O grupo (19) � composto por:
- [Danilo Queiroz da Silva](https://github.com/DaniloQueirozSilva)
- [Elton Douglas Souza](https://github.com/eltonds88)
- [Leandro da Silva C�mara](https://github.com/leandrocamara)
- [Marcelo Patricio da Silva](https://github.com/mpatricio007)