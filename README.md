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
## Objetos
Mudando o nível de acesso às propriedades da classe `Musica` para `public`:
```CSharp
// Musica.cs
class Musica
{
    public string nome;
    public string artista;
    public int duracao;
    public bool disponivel;
}
```

O programa principal vai imprimir o nome da música e do artista de duas músicas:
```CSharp
// Program.cs
Musica musica1 = new Musica();
musica1.nome = "Roxane";
musica1.artista = "The Police";

Console.WriteLine($"Nome: {musica1.nome}");
Console.WriteLine($"Artista: {musica1.artista}");

Musica musica2 = new Musica();
musica2.nome = "Vertigo";
musica2.artista = "U2";

Console.WriteLine($"Nome: {musica2.nome}");
Console.WriteLine($"Artista: {musica2.artista}");
```
