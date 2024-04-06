# Jogo Galo Da Velha

### Autoria

#### Elementos do grupo:
- Hugo Figueira Silva  22001815
- Steven Hall 2200173
  
### _Report_:

#### Hugo:
- Código:
  - _Game_ Construção do tabuleiro, mais tarde passado a classe _boardMapping_
    - _UI_ (Layout do tabuleiro, menu peças disponiveis, desenho das peças ,legenda, frases de output e cores)
    - Atualização do tabuleiro e movimento das peças
    - Condições de vitoria (Verificar linhas horizontais, verticais e diagonais)
    - Lógica de input e output (Como o jogador poderia escolher as peças e lugar do  tabuleiro desejado)
    - Mensagens de erro
    - Reescrever e formatar mensagem inicial (WelcomeText.txt)
  - _Bug fixing_
- Relatório: 0.0%
- UML: 0.0%

#### Steven: 
- Código: 
  - Classes  
    - _Piece_ 
    - _Game_ Instanciação de peças, organização, formatão e métodos: _RunGame, Welcome, CheckForDraw_ e _EndGame_.
    - _Board_ 
    - _FileDirectory_
   
  - Enumeradores
    - _GameStatus_ 
    - _Player_  
    - _PieceHole_
    - _PieceShape_
    - _PieceSize_
    - _PieceColor_ 
  - _Bug fixing_ 
- Relatório: 0.0%
- UML: 0.0%

## Arquitetura da solução
### Descrição da solução
- Projeto desenvolvido utilizando a linguagem _C#_ 8.0 e [_.NET_](https://learn.microsoft.com/en-us/dotnet/api/?view=netstandard-2.1).

- Projeto consiste no jogo do GaloDaVelha, apresentado visualmente em consola (terminal)

A solução do projeto consiste em jogar o jogo do Galo da Velha na consola, que é um jogo para 2 jogadores (_PvP_). Cada jogador tem o seu turno respectivo, dando a cada um a possibilidade de ganhar ou empatar (caso não haja mais peças disponíveis)

Antes do jogo começar, o utilizador é apresentado com as regras. Para avançar, pressiona ENTER.
A primeira visualização mostra o tabuleiro, peças disponíveis, legenda e turno do jogador.
O tabuleiro inicial está vazio, com letras representando os espaços.

O menu das peças mostra tamanho, cor, forma e presença de furo. A forma é representada por símbolos Unicode, distinguindo quadrados e círculos. 'B' significa grande e 's' significa pequeno. Cada peça é numerada.
Uma legenda explica os símbolos.

Se desejar sair, o jogador escreve 'ESC'.
Em cada turno, o jogador escolhe onde colocar a peça e seu número.
Após o turno, o tabuleiro e peças são atualizados.
O jogo continua até um jogador ganhar ou haver empate.
Mensagens indicam a vitória do jogador ou empate.
O programa sugere o comando para jogar novamente.


Arquitetura deste projeto consiste em criar uma instância de um jogo a partir da classe _Program_, sendo esta a classe _Game_. Grande maioria do código e lógica está contido dentro de _Game_, mas a classe _Game_ utiliza código externo como enumeradores e classes para a lógica de jogo poder funcionar bem e respeitar o princípio _Single Responsability_.

Classes utilizadas (instanciadas) por _Game_ são _Piece_ _Board_ e _FileDirectory_ onde, respectivamente: 
- _Piece_: Peças são inicializadas dentro de um _array_ da classe _Game_ fazendo uso do construtor que posteriormente utiliza os _setters_ privados para configurar cada peça. 
Há um total de 16 instâncias ou peças. 
- _Board_: Instância é criada para poder haver acesso ao layout do tabuleiro. _Layout_ do tabuleiro é obtido através de um _getter_ público.
- _FileDirectory_: Dentro do método _Welcome_, é feito uma instancia local da classe _FileDirectory_. Assim é possível utilizar o _getter_ que devolve um diretório (especificamente qual diretório, depende de como o código é corrido). Utilizando o comando normal(ensinado em aula: dontet run --project ProjectName) um texto de boas-vindas é aprensetado ao utilizador.

Enumeradores Utilizados pela classe _Game_: Estes Enumerados são utilizados para gerir a lógica de _gameplay_ como definir o estado  de jogo e definir qual jogador é o turno.

- GameStatus: Contém os estados em que o jogo pode se encontrar sendo:
  - draw = Empate por falta de peças
  - player1Win = Vitória do jogador 1
  - player2Win  = Vitória do jogador 2
  - exit = Algum dos jogadores decidiu sair do jogo
- Player: Contém o estado de jogador, podendo ser jogador 1 ou 2. É tuilizado para mostrar o turno e apresentar de qual jogador é a vitória.
  - player1 
  - player2

Enumeradores utilizados pela classe _Piece_: Estes enumeradores são utilizados para definir limites e as características de cada peça como cor, se tem furo ou não, formato e finalmente tamanho
- PieceColor: 
- PieceHole:
- PieceShape:
- PieceSize: 

- Cilco de jogo:
O tabuleiro é construido visualmente por caracteres como '+' ou '-', onde esses caracteres encontram-se em ciclos for. Em cada espaço vazio do tabuleiro, tem feito print de cada elemento array de letras. Onde mais tarde podem ser substituidos pelas peças que o jogador escolhe. Depois de ser dado os inputs do jogador, caso não é dado erro de mensagem, é corrida o metodo VerifiedGameStatus. Isso verifica que existe uma sequencia de cores, tamanho, forma ou furo na vertical, horizontal e diagonal. E para verificar, é corrido por cada 2 elementos da array 'piecesVerified'. Se os elemtos não forem vazios, é verificado se existe uma sequencia. Se tiver e se a ,emsage,Exibida é false, então a mensagemExibida passa para true, para evitar repitição da frase de vitorio e é mostrado o jogador vencendor e como venceu.

### Diagrama _UML_

```mermaid
graph TD

  A([Main])   --> B[/"Start"/];
  B           --> C[RunGame];


  C             --> WEL[/"WELCOME"/];
  WEL           --> PrintWelcomeText[/"Welcome Text"/];
  C             --> D[CheckFoDraw];
  C             --> E[UpdateBoard];
  C             --> F{DecidePlayerTurn};

  D             --> Draw{"piecesArray.Lenght <1"?}
  Draw  -- true --> Z


  F -- Player 1 --> Set[/SetPieceOnBoard/]
  F -- Player 2 --> Set


  Set           --> EXIT{"Input == ESC?"}
  Set           --> Input{"Valid Input?"}
  Input -- true --> Ver["VerifiedGameStatus"]

  EXIT  -- true --> Z

  E             --> PrintBoard

  Ver           --> I{WinOnHorizontal?};
  Ver           --> K{WinOnDiagonal?};
  Ver           --> L{WinOnVertical?}

  I     -- true --> Z([EndGame])
  K     -- true --> Z([EndGame])
  L     -- true --> Z([EndGame])

 

```
## Referências 

### IAs generativas
  O uso de IAs generativas foi usado e neste tópico explicaremos como: 
- Utilizamos o _Chat Bing_ que utiliza o (_Chat GPT-4_) foi utilizado para tirar dúvidas e explicar itens da [_API_](https://learn.microsoft.com/en-us/dotnet/api/?view=netstandard-2.1) de forma mais clara e simples erros, exemplos e também para obter de forma mais rápida _links_ com código útil com foi o caso de [_Envrionment.Exit(Int32)_](https://learn.microsoft.com/en-us/dotnet/api/system.environment.exit?view=netstandard-2.1) e  [_List .Select_](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=netstandard-2.1). 

- O único 100% proveniente de IAs generativas, foi o código da tabela, ou seja, o código contido dentro do método _UpdateBoard_, dentro da classe _Game_ (Game.cs) que desenha a tabela com carecteres "+" e "-".

- A IA generativa também auxiliou nas boas práticas e convenções _C#_, informando que seria má prática inicializar variáveis isoladas da classe Piece, sendo melhor utilizar um _array_ ou _List_ onde, optamos por inicializar as _Pieces_ num _array_ na classe _Game_. Finalmente, relativamente a documentação (_XML_) informou que se pode fazer documentação em enumeradores e então procedemos a fazer.
   

### Consultas com docentes
  
A Realização deste projeto consistiu essencialmente em pesquisa própria, conhecimento adquirido por trabalhos e ensino fornecido por proferessores em diversas unidades curriculares lecionadas na [licenciatura de Videojogos](https://www.ulusofona.pt/lisboa/licenciaturas/videojogos).
#

### _Links_ de pesquisa utilizados para realização do projeto
* [_Getters & Setters_](https://www.w3schools.com/cs/cs_properties.php)
* [_Console.Clear()_]()
* [_C# Arrays W3 Schools_](https://www.w3schools.com/cs/cs_arrays.php)
* [_Tic Tac toe_ linhas, colunas e diagonal](https://www.c-sharpcorner.com/UploadFile/75a48f/tic-tac-toe-game-in-C-Sharp/)

* [Unicode Symbols](https://symbl.cc/en/unicode-table/)
* [Digrama UML Mermaid](https://mermaid.js.org/syntax/classDiagram.html)
* [_Mermaid Flowchart_](https://mermaid.js.org/syntax/flowchart.html)

#### _API_
* [_Arrays & Multidimensional Arrays_](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays)
* [_Stream Reader & Error Handling_](https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netstandard-2.1)
* [_List_ ](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netstandard-2.1)
* [_List .Select_](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=netstandard-2.1)
* [_PadRight(Int32)_](https://learn.microsoft.com/en-us/dotnet/api/system.string.padright?view=netstandard-2.1)
* [_ANSI Color codes_](https://www.lihaoyi.com/post/BuildyourownCommandLinewithANSIescapecodes.html)
* [_Envrionment.Exit(Int32)_](https://learn.microsoft.com/en-us/dotnet/api/system.environment.exit?view=netstandard-2.1)

#### _Youtube_
* [Planeamente Geral de classes, enumeradores](https://www.youtube.com/watch?v=NUNlVjt82m8&t=738s)
* [FUTURO VER BOARD CLASS](https://www.youtube.com/watch?v=Z1Zi41eiNGs&t=80s)
* [_Stream Reader_ exemplo](https://www.youtube.com/watch?v=tApBDuVwCrc)
---




