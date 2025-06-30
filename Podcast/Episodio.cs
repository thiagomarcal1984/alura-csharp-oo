class Episodio
{
    private List<string> convidados = new(); // Note que o new() não informa a classe!
    public int Ordem { get; }
    public string Titulo { get; }
    public int Duracao { get; }
    public string Resumo => $"{Ordem}. {Titulo} ({Duracao} segs.) - {string.Join(", ", convidados)}";

    public Episodio(int ordem, string titulo, int duracao)
    {
        Ordem = ordem;
        Titulo = titulo;
        Duracao = duracao;
    }

    public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }
}
