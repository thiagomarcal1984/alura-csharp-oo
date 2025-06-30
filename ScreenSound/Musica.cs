class Musica
{
    public string Nome { get; } // Propriedade somente leitura.

    // A banda nunca poderá ser mudada, exceto ao construi-la.
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }

    public Musica(Banda artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }

    public string DescricaoResumida
    {
        // Outra forma de escrever uma propriedade sem setter é lambda/arrow function:
        // public string Descricao => $"Musica: {Nome}; Artista: {Artista}";
        get
        {
            return $"A música {Nome} pertence à banda {Artista}";
        }
        // private set; // Não precisa escrever o setter.
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        }
        else
        {
            Console.WriteLine("Adquira o plano Plus+.");
        }
    }
}
