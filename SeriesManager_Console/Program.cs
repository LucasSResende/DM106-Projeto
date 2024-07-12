using SerieManager.Shared.Data.BD;
using SeriesManager_Console;


var SerieDAL = new DAL<Serie> (new SerieManagerContext());

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
    string serieGenre = Console.ReadLine();
    Console.WriteLine("Faça uma breve descrição da série");
    string serieDescription = Console.ReadLine();
    Serie serie = new Serie(serieName, serieGenre, serieDescription);
    SerieDAL.Create(serie);
    Console.WriteLine($"Série {serieName} inserida!");
}
void EpisodeRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de episódio\n");
    Console.WriteLine("Digite o nome da série: ");
    string serieName = Console.ReadLine();
    var targetSerie = SerieDAL.ReadBy(s => s.serieName.Equals(serieName));
    if (targetSerie is not null)
    {
        Console.WriteLine($"Qual é o número e o nome do episódio da série {serieName}?");
        int episodeNumber = int.Parse(Console.ReadLine());
        string episodeName = Console.ReadLine();
        targetSerie.AddEpisode(new Episode(episodeNumber, episodeName));
        SerieDAL.Update(targetSerie);
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
    Console.WriteLine("Listagem de séries\n");
    foreach (var serie in SerieDAL.Read())
    {
        Console.WriteLine(serie);
    }
    Console.ReadKey();
}

void EpisodeGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de episódios\n");
    Console.WriteLine("Entre com a série que deseja ver os episódios: ");
    string serieName = Console.ReadLine();
    var targetSerie = SerieDAL.ReadBy(s => s.serieName.Equals(serieName));
    if (targetSerie is not null)
    {
        targetSerie.ShowEpisodes();
    }
    else Console.WriteLine($"Série {serieName} não encontrada.");
    Console.ReadKey();


}
