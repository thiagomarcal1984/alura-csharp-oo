# Criando o primeiro programa
## Preparando o ambiente

Vá para o diretório raiz e crie a solução com o seguinte comando:

```bash
dotnet new solution -n ScreenSound
```
Vamos criar um novo projeto de console com o nome `ScreenSound` e acrescentá-lo à solução `ScreenSound`:

```bash
dotnet new console -n ScreenSound
dotnet solution add ScreenSound
```
Para rodar o projeto, execute o seguinte comando na raiz da solução:

```bash
dotnet run --project ScreenSound
```

## Criando uma classe
Definição da classe `Musica`, que vai ficar no arquivo `Musica.cs`:
```CSharp
class Musica
{
    string nome;
    string artista;
    int duracao;
    bool disponivel;
}
```
