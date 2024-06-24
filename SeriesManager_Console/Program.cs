﻿using SeriesManager_Console;

Dictionary<string, Serie> SerieDict = new();


bool exit = false;

while (!exit)
{
    Console.WriteLine("Bem vindo ao Series Manager!\n");
    Console.WriteLine("Digite 1 para registrar uma série");
    Console.WriteLine("Digite 2 para registrar um episódio de série");
    Console.WriteLine("Digite 3 para mostrar todas as séries");
    Console.WriteLine("Digite 4 para mostrar os episódios de uma série");
    Console.WriteLine("Digite -1 para sair\n");

    Console.Write("Digite sua opção: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            SerieRegister();
            break;
        case 2:
            EpisodeRegister();
            break;
        case 3:
            SerieGet();
            break;
        case 4:
            EpisodeGet();
            break;
        case -1:
            Console.WriteLine("Até a próxima!");
            exit = true;
            break;
        default:
            Console.WriteLine("Escolha inválida");
            break;
    }
    Thread.Sleep(1500);
    Console.Clear();
}

void SerieRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de séries\n");
    Console.WriteLine("Digite o nome da série: ");
    string serieName = Console.ReadLine();
    Console.WriteLine("Digite o gênero da série");
    string genre = Console.ReadLine();
    Console.WriteLine("Faça uma breve descrição da série");
    string description = Console.ReadLine();
    Serie serie = new Serie(serieName, genre, description);
    SerieDict.Add(serieName, serie);
    Console.WriteLine($"Série {serieName} inserida!");
}
void EpisodeRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de episódio\n");
    Console.WriteLine("Digite o nome da série: ");
    string serieName = Console.ReadLine();
    if (SerieDict.ContainsKey(serieName))
    {
        Console.WriteLine($"Qual é o número e o nome do episódio da série {serieName}?");
        int episodeNumber = int.Parse(Console.ReadLine());
        string episodeName = Console.ReadLine();
        Serie serie = SerieDict[serieName];
        serie.AddEpisode(new Episode(episodeNumber, episodeName));
        Console.WriteLine($"O espisódio de número {episodeNumber} e nome {episodeName}" +
            $"foi registrado com sucesso!");
    }
    else
    {
        Console.WriteLine($"Série {serieName} não encontrada.");
    }
}

void SerieGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de episódios\n");
    Console.WriteLine("Digite o nome da série que pretende ver os episódios: ");
    string serieName = Console.ReadLine();
    if (SerieDict.ContainsKey(serieName))
    {
        Serie serie = SerieDict[serieName];
        serie.ShowEpisodes();
    }
    else
    {
        Console.WriteLine($"Série {serieName} não encontrada.");
    }
}

void EpisodeGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de séries\n");
    foreach (var seire in SerieDict.Values)
    {
        Console.WriteLine(seire);
    }
}





//using SeriesManager_Console;

//Serie s1 = new Serie("GoT", "Aventura", "Esta série passada na idade média, fala sobre a época da monarquia e como funcionava algumas tramas de poder, envolvendo fantasia, como dragões.");

//s1.AddEpisode(new Episode(1, "Pilot"));

//Console.WriteLine(s1);

//s1.ShowEpisodes();