# fiap.tech-challenge.fast-food.infra.cognito

Este repositório é responsável por manter AWS Lambda de autenticação da aplicação [**_Fast Food API_**](https://github.com/leandrocamara/fiap.tech-challenge.fast-food.api).

## Execução

Após a execução dos [_Workflows_](https://github.com/leandrocamara/fiap.tech-challenge.fast-food.lambda.auth/actions) (GitHub Actions), uma AWS Lambda [**_Lambda_**](https://docs.aws.amazon.com/lambda/) é provisionada na _AWS_.

Há duas maneiras de executar e criar a lambda: 

1. Realizando um `push` na `main`, por meio de um `Merge Pull Request`;

2. Executando o [_Manual Deployment_](https://github.com/leandrocamara/fiap.tech-challenge.fast-food.lambda.auth/actions/workflows/manual-deployment.yaml) (_Workflow_)

    ![Manual Deployment](./docs/manual-deployment.png)

    2.1. Por padrão, o _Workflow_ utilizará as `Secrets` configuradas no projeto. Caso esteja utilizando o `AWS Academy`, recomenda-se informar as credencias da conta. **Obs.:** Cada sessão do _AWS Academy_ dura **4 horas**.



## Tech Challenge
Projeto para a curso de [Pós Graduação FIAP - Software Architecture](https://postech.fiap.com.br/curso/software-architecture/).

O grupo (19) é composto por:
- [Danilo Queiroz da Silva](https://github.com/DaniloQueirozSilva)
- [Elton Douglas Souza](https://github.com/eltonds88)
- [Leandro da Silva Câmara](https://github.com/leandrocamara)
- [Marcelo Patricio da Silva](https://github.com/mpatricio007)
