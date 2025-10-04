# INDTGestaoSegurosPlatform

Solução com dois microserviços em .NET 8 usando Arquitetura Hexagonal, repositórios mocados e testes unitários.

## Requisitos
- Visual Studio 2022 Community
- .NET 8 SDK

## Estrutura
- PropostaService.Api
- PropostaService.Core
- PropostaService.Infra
- ContratacaoService.Api
- ContratacaoService.Core
- ContratacaoService.Infra
- Shared
- Tests.Proposta
- Tests.Contratacao

## Como abrir
1. Abra 'INDTGestaoSegurosPlatform.sln' no Visual Studio 2022. (\InsurancePlatform\INDTGestaoSegurosPlatform.sln)
2. Restaure pacotes NuGet.

## Como rodar
1. Em Solution Explorer clique com o botão direito na solução → Properties → Startup Project.
2. Selecione Multiple startup projects e marque PropostaService.Api e ContratacaoService.Api como Start.
3. Verifique 'launchSettings.json' das APIs: PropostaService em 'http://localhost:5001', ContratacaoService em 'http://localhost:5002'.
4. Execute (F5) ou Start Without Debugging (Ctrl+F5).

## Endpoints principais

* Abre proposta
- POST http://localhost:5001/api/propostas
  - Body: { "proponente": "Joao Silva", "valor": 1000.99 }
  
* Lista proposta
- GET http://localhost:5001/api/propostas
- GET http://localhost:5001/api/propostas/{id}

* Altera status proposta
- PATCH http://localhost:7098/api/propostas/{id}/status
  - Body: { "status": 1 } // enum EmAnalise=0 Aprovada=1 Rejeitada=2
  
* Abre contratação
- POST http://localhost:5002/api/contratacoes/{propostaId}
  - Só cria contratação se proposta estiver com status Aprovada.

## Testes
- Abra Test Explorer e execute todos os testes.
- Ou na linha de comando: `dotnet test` na raiz da solução.

## Observações
- Dados são mocado em memória; reiniciar aplicações perde dados.
- Para testes de integração locais, inicie PropostaService antes de ContratacaoService.