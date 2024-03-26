# Jogo Galo Da Velha

## Autoria

### Elementos do grupo:
- Hugo Figueira Silva 22001815
- Steven Hall 2200173
  
### Report:
#### Hugo:
- Sistema de inventário
- Diagramas _UML_
- Instanciação de objetos dentro do inventário
- Inserção dos valores dos objetos presentes no dicionário
- Criação das malas e leitura de objetos dentro da mala
- _Bug fixing_  


#### Steven: 
- Leitura de diretório e ficheiros
- Sistema de _warning_
- _UI_:  
  - indicação de Diretório  
  - conteúdo de ficheiro  
  -  ícones  
  -  conteúdo de inventário   
  -  código respectivo
- Relatório

- _Bug fixing_

## Arquitetura da solução
### Descrição da solução
- Projeto desenvolvido utilizando o motor de jogo [_Unity Engine_ 2022.3.1 _LTS_](https://unity.com/releases/editor/whats-new/2022.3.1#release-notes).
- Objetivo principal abrir um dado ficheiro e apresentar o seus conteúdos (itens para inventário neste caso) ao utilizador. 

A solução do projeto consiste em abrir o diretório ambiente de trabalho (Tecla Q). Em seguida é apresentado um menu esilo _pop up_ o qual solicita ao utilizador inserir o número de linha correspondente ao ficheiro desejado (Clicar em _done_).    

Caso a operação anterior realize-se com sucesso, será apresentado um menu de inventário com os itens presentes no ficheiro selecionado no passo anterior.    

- Adicionar itens: Para adicionar itens a este inventário (clicar em _add_) e em seguida é apresentado outro menu com a lista de todos os itens disponíveis (clicar no item desejado). Assim será adicionado o item escolhido ao inventário.

- Remover itens: Para remover itens devemos passar o rato em cima do item desejado (clicar no item para a janela de descrição fixar-se) e clicar no ícone x. Assim será removido do inventário o item escolhido.

#

#### Princípios _SOLID_

- Princípios _SOLID_ utilizados nesse projeto foram: _**Single Responsability Principle**_.  
  - O inventário ou a classe inventário apenas tem a responsabilidade de cuidar do inventário em si.  
   - _ItemUI_ trata das funções presentes no _UI_ do item respectivo.  
   -  _FileIO_ apenas trata dos ficheiros.
   -  _ItemAdder_ adiciona itens.  
  
Portanto concluímos assim que as funções só fazem a uma função que lhes foi dada e não varias coisas diferentes.

  

  
### Diagrama _UML_

## Referências 

### IAs generativas
  O uso de IAs generativas foi usado e neste tópico explicaremos como: 
- O _Chat Bing_ (_Chat GPT-4_) foi utilizado para tirar dúvidas e explicar itens da [documentação](https://learn.microsoft.com/en-us/dotnet/api/?view=netstandard-2.1) de forma mais clara e simples, erros, exemplos e também para obter de forma mais rápida _links_ com código útil com foi o caso particular do tópico [Remover linhas do ficheiro](https://stacktuts.com/how-to-delete-a-line-from-a-text-file-in-c).   
  Sem mencionar que um é um erro comum quando o nome de ficheiro não é válido ao utilzarmos o [_stream reader_](https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netstandard-2.1) onde pelo menos podemos dizer que foi a nossa experiência ao utilizar esta classe do [_C#_](https://learn.microsoft.com/en-us/dotnet/csharp/).

  
- Nenhum código fornecido por IAs generativas foi diretamente utilizado para a realização desse projeto como explicado acima, apenas a título de curiosidade, pesquisa, exemplos e explicação de tópicos da documentação.


### Consultas com docentes
Relativamente a consulta feita com professores, um professor foi consultado para ajudar em algumas questões. Este foi o professor Diogo Andrade onde auxiliou em 2 questões sendo essas respectivamente:

- [_UnauthorizedAccessException_](https://learn.microsoft.com/en-us/dotnet/api/system.unauthorizedaccessexception?view=netstandard-2.1). Este erro foi apresentado ao docente para poder obter-se alguma explicação do porque poderia estar a acontecer tal erro. Para resolver o problema foi sugerido pelo professor Diogo rever o código, verificar valor das variáveis e usar _Debug.log_ que indicassem exatamente o que acontecia com o código presente. Nenhum foi código foi fornecido pelo professor e erro resolveu-se utilizando a documentação [._NET STANDARD_ 2.1](https://learn.microsoft.com/en-us/dotnet/api/system.environment.specialfolder?view=netstandard-2.1#system-environment-specialfolder-desktopdirectory) onde verificou-se que há 2 tipos de ambientes de trabalho e de facto estavamos a usar o errado para além do facto de havia falhas no código de escritura.
  
- Gestão e criação de itens inventário. No que toca a criação do sistema de inventário consultou-se também o professor Diogo Andrade para saber qual a melhor de forma de podermos construir um sistema de inventário a partir de um dado ficheiro. O mesmo explicou que não existe nenhuma melhor de realizar sem ter em consideração o peso total do projeto em si. Novamente nenhum código foi fornecido por via de docentes da [Universidade Lusófona](https://www.ulusofona.pt/) ou qualuqer outro docente.  
  
  A Realização deste projeto consistiu essencialmente em pesquisa própria, conhecimento adquirido por trabalhos e ensino fornecido por proferessores em diversas unidades curriculares lecionadas na [licenciatura de Videojogos](https://www.ulusofona.pt/lisboa/licenciaturas/videojogos).
#

### Links de pesquisa utilizados para realização do projeto
* [Getters & Setters](https://www.w3schools.com/cs/cs_properties.php))
