class Album
{
    private List<Musica> musicas = new List<Musica>();
    public string Nome { get; } // Propriedade somente leitura.
    public Album(string nome)
    {
        Nome = nome;
    }
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
