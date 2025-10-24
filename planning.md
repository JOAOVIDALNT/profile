# PROFILE

## O QUE É
No longo prazo, o profile deve ser uma rede de newsletters. Onde o usuário cadastrado, terá o link do seu perfil associado ao seu nickname onde poderá escrever e expor artigos, parecido com o que é feito em um medium ou dev.to da vida.

A diferença crucial deve ser o serviço de notificação por email para os inscritos no profile do usuário. A principio essa deve ser a única interação entre usuários dentro da rede -> <strong>inscrição</strong>.

Outras maneiras de notificação também devem ser implementadas, idealmente mensagem de texto via sms ou whatsapp. Futuramente os meios de notificação devem seguir as preferências do usuário inscrito.

## MVP
Na primeira versão, o cadastro de usuário estará implementado mas não se fará acessível. Sendo assim, apenas o usuário criador (vulgo eu) poderá postar e a dinâmica de inscrição será realizada através de um formulário preenchido com o email do inscrito.

## STACK E REQUISITOS
Pra esse projeto, tenho os seguintes requisitos:
- Backend .NET com banco relacional (o de preferência)
- DDD com clean arch sem muita firula com services e não usecases
- k8s pra orquestrar os containers
- deploy e deepdive nos serviços do azure (AKS, Static web apps, app service, sqldb)
- azure functions + service bus para envio de email
- Frontend Angular com deepdive nos recursos do rxjs
- testar o zardui como alternativa de lib

## CUIDADOS
- Evitar testes no MVP, o foco é nos objetos de estudo.
- Evitar overengenering, ex: embora usando DDD, não vou aplicar o modelo de domínio rico para entidades
- cuidar com os custos e a segurança desde o primeiro deploy
- validar se os requisitos e objetos de estudos estão sendo implementados e documentar qualquer mudança.

## PRAZO
Esse projeto tem um prazo de 2 dias -> 25/10 -- 26/10 para o MVP. Todos os requisitos previamente listados devem estar presentes no MVP.

