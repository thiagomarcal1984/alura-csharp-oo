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
## Properties
As properties no dotnet são os atributos que possuem getters e setters:
```CSharp
// Musica.cs
class Musica
{
    // Resto do código
    public bool Disponivel { get; set; } 

    public void ExibirFichaTecnica()
    {
        // Resto do código
        if (Disponivel)
        {
            // Resto do código
        }
    }
}
```
> Propriedades são escritas em formato PascalCase.

Adaptações no programa principal:
```CSharp
// Program.cs
// Resto do código
musica1.Disponivel = true; 
Console.WriteLine(musica1.Disponivel);

// Resto do código
musica2.Disponivel = false;
// Resto do código
```

## Atributos e propriedades
Vamos trocar os atributos/campos (sem getters e setters e em camelCase) por propriedades (com getters e setters e em PascalCase):
```CSharp
// Musica
class Musica
{
    public string Nome { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    // Resto do código.
}
```
> As referências aos atributos foram trocadas pelas propriedades também no programa principal, mas isso será omitido.

> Foi acrescentado no `.gitignore` a regra para não versionar o diretório `.vs/`. É um diretório de cache do Visual Studio.

## Alterando o GET com lambda
Vamos criar uma propriedade somente leitura chamada `DescricaoResumida` na classe Musica:
```CSharp
class Musica
{
    public string Nome { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }

    public string DescricaoResumida
    {
        get
        {
            return $"A música {Nome} pertence à banda {Artista}";
        }
        // private set; // Não precisa escrever o setter.
    }
    // Outra forma de escrever uma propriedade sem setter é lambda/arrow function:
    // public string Descricao => $"Musica: {Nome}; Artista: {Artista}";
}
```
> Outra forma de escrever uma propriedade sem setter é lambda/arrow function:
> ```CSharp
> class Musica
> {
>     // Resto do código
>     public string Descricao => $"Musica: {Nome}; Artista: {Artista}";
> }
> ```

# Integrando classes e definindo relacionamentos
A classe `Album` será definida a seguir:
```CSharp
// Album.cs
class Album
{
    private List<Musica> musicas = new List<Musica>();
    public string Nome { get; set; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}: \n");
        musicas.ForEach(obj => Console.WriteLine($"Música: {obj.Nome}"));

        Console.WriteLine($"Para ouvir este álbum inteiro você precisa de {DuracaoTotal} segundos.");
    }
}
```
> Destques para as funções `musicas.Sum` e `musicas.ForEach`:
> ```CSharp
> class Album
> {
>     // Resto do código
>     public int DuracaoTotal => musicas.Sum(m => m.Duracao);
>     // Resto do código
> 
>     public void ExibirMusicasDoAlbum()
>     {
>         // Resto do código
>         musicas.ForEach(obj => Console.WriteLine($"Música: {obj.Nome}"));
>         // Resto do código
>     }
> }
> ```

Novo conteúdo do programa principal será: 
```CSharp
// Program.cs
Album albumDoQueen = new Album()
{
    Nome = "A night at the opera"
};

Musica musica1 = new Musica();
musica1.Nome = "Love of my life";
musica1.Duracao = 213;

Musica musica2 = new Musica();
musica2.Nome = "Bohemian Rhapsody";
musica2.Duracao = 354;

albumDoQueen.AdicionarMusica(musica1);
albumDoQueen.AdicionarMusica(musica2);

albumDoQueen.ExibirMusicasDoAlbum();
```
# Construtor de bandas
## Desenvolvendo a classe banda
Definição da classe `Banda`:
```CSharp
// Banda.cs
class Banda
{
    private List<Album> albums = new List<Album>();
    public string Nome { get; set; }

    public void AdicionarAlbum(Album album)
    {
        albums.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albums)
        {
            Console.WriteLine($"Album: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}
```
Novo código do programa principal:
```CSharp
// Program.cs
Album albumDoQueen = new Album()
{
    Nome = "A night at the opera"
};

Musica musica1 = new Musica();
musica1.Nome = "Love of my life";
musica1.Duracao = 213;

Musica musica2 = new Musica();
musica2.Nome = "Bohemian Rhapsody";
musica2.Duracao = 354;

albumDoQueen.AdicionarMusica(musica1);
albumDoQueen.AdicionarMusica(musica2);

Banda queen = new Banda();
queen.Nome = "Queen";
queen.AdicionarAlbum(albumDoQueen);
queen.ExibirDiscografia();
```
## Criando um construtor / Relacionamento entre as classes
Vamos criar um construtor de música que força a definição da banda que fez:
```CSharp
// Musica.cs
class Musica
{
    // Resto do código

    // A banda nunca poderá ser mudada, exceto ao construi-la.
    public Banda Artista { get; }

    public Musica(Banda artista)
    {
        Artista = artista;
    }
    // Resto do código
}
```
Mudanças no programa principal (uso do construtor de músicas):
```CSharp
// Program.cs
Album albumDoQueen = new Album()
{
    Nome = "A night at the opera"
};

Banda queen = new Banda();
queen.Nome = "Queen";

Musica musica1 = new Musica(queen);
// Resto do código
Musica musica2 = new Musica(queen);
// Resto do código
albumDoQueen.AdicionarMusica(musica1);
albumDoQueen.AdicionarMusica(musica2);

queen.AdicionarAlbum(albumDoQueen);
queen.ExibirDiscografia();
```
## Construtores para as classes
Vamos criar construtores com parâmetros para todas as classes e vamos determinar que a propriedade `Nome` de cada uma delas será somente leitura:

```CSharp
// Album.cs
class Album
{
    // Resto do código
    public string Nome { get; } // Propriedade somente leitura.
    public Album(string nome)
    {
        Nome = nome;
    }
    // Resto do código
}
```

```CSharp
// Banda.cs
class Banda
{
    // Resto do código
    public string Nome { get; } // Propriedade somente leitura.

    public Banda(string nome)
    {
        Nome = nome;
    }
    // Resto do código
}
```

```CSharp
// Musica.cs
class Musica
{
    public string Nome { get; } // Propriedade somente leitura.

    // A banda nunca poderá ser mudada, exceto ao construi-la.
    public Banda Artista { get; }

    // Resto do código

    public Musica(Banda artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }
    // Resto do código
    public void ExibirFichaTecnica()
    {
        // Resto do código
        
        // Antes Artista era string; agora é um objeto da classe Banda
        Console.WriteLine($"Artista: {Artista.Nome}");
        // Resto do código
    }
}
```

Implementação do programa principal:
```CSharp
// Program.cs
Album albumDoQueen = new Album("A night at the opera");

Banda queen = new Banda("Queen");

Musica musica1 = new Musica(queen, "Love of my life")
{
    Duracao = 213,
    Disponivel = true,
};

Musica musica2 = new Musica(queen, "Bohemian Rhapsody")
{
    Duracao = 354,
    Disponivel = false,
};

albumDoQueen.AdicionarMusica(musica1);
albumDoQueen.AdicionarMusica(musica2);
queen.AdicionarAlbum(albumDoQueen);

musica1.ExibirFichaTecnica();
musica2.ExibirFichaTecnica();
albumDoQueen.ExibirMusicasDoAlbum();

queen.ExibirDiscografia();
```
> Note como os construtores de música acrescentam atribuições das propriedades não exigidas no construtor: basta acrescentar cada propriedade (formato `Propriedade = valor`) dentro de chaves e separá-los com vírgulas.
