Episodio ep1 = new(5, "Índios", 360);
ep1.AdicionarConvidados("Bruno Bogossian");
ep1.AdicionarConvidados("Vítor Lacombe");

Episodio ep2 = new(2, "Fábrica", 720);
ep2.AdicionarConvidados("Tomé Granneman");

Podcast cafe = new("Magê Flores", "Café da manhã");

cafe.AdicionarEpisodio(ep1);
cafe.AdicionarEpisodio(ep2);

cafe.ExibirDetalhes();
