# Classe e método no C#
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

## Criando um método
Implementação do método vazio `ExibirFichaTecnica`:
```CSharp
// Musica.cs
class Musica
{
    // Resto do código

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Artista: {artista}");
        Console.WriteLine($"Duração: {duracao}");
        if (disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        }
        else
        {
            Console.WriteLine("Adquira o plano Plus+.");
        }
    }
}
```

Uso do método no programa principal:
```CSharp
// Program.cs
Musica musica1 = new Musica();
musica1.nome = "Roxane";
musica1.artista = "The Police";
musica1.duracao = 273;
musica1.disponivel = true;

Musica musica2 = new Musica();
musica2.nome = "Vertigo";
musica2.artista = "U2";
musica2.duracao = 367;
musica2.disponivel = false;

musica1.ExibirFichaTecnica();
musica2.ExibirFichaTecnica();
```
# Métodos de acesso e proprieades
## Atribuindo valores
Vamos proteger o atributo `disponivel` mudando o nível de acesso dele para private:
```CSharp
// Musica.cs
class Musica
{
    // Resto do código
    private bool disponivel;
    // Resto do código
}
```
> Isso vai quebrar o acesso a esse atributo no programa principal. Na próxima aula isso será corrigido.

## Centralizando acesso
A propriedade booleana `disponível` permanecerá privada, mas será acessada mediante os métodos `EscreveDisponivel` e `LeDisponivel`, implementados a seguir:

```CSharp
// Musica.cs
class Musica
{
    // Resto do código
    private bool disponivel;

    public void EscreveDisponivel(bool value)
    {
        disponivel = value;
    }

    public bool LeDisponivel()
    {
        return disponivel;
    }
    // Resto do código
}
```

A implementação do programa principal ficará assim:
```CSharp
// Program.cs
// Resto do código
musica1.EscreveDisponivel(true);
Console.WriteLine(musica1.LeDisponivel());

// Resto do código
musica2.EscreveDisponivel(false);
```
