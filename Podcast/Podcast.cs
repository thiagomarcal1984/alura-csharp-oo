class Podcast
{
    private List<Episodio> episodios = new();
    public string Host { get; }
    public string Nome { get; }
    public int TotalEpisodios => episodios.Count;

    public Podcast(string host, string nome)
    {
        Host = host;
        Nome = nome;
    }

    public void AdicionarEpisodio(Episodio episodio)
    {
        episodios.Add(episodio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast {Nome} apresentado por {Host}");
        Console.WriteLine("\nLista de Episódios");
        foreach (Episodio ep in episodios.OrderBy(ep => ep.Ordem))
        {
            Console.WriteLine(ep.Resumo);
        }
        Console.WriteLine($"Este podcast possui {TotalEpisodios} episódios.\n");
        Console.WriteLine($"Duração total: {episodios.Sum(ep => ep.Duracao)} segundos.");
    }
}
