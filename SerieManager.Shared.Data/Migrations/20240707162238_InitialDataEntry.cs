using Microsoft.EntityFrameworkCore.Migrations;

namespace SerieManager.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Serie", new string[] { "serieName", "serieGenre", "serieDescription" }, new object[] { "Game of Thrones", "Fantasia, Ficção cinetífica mágica", "Sete famílias nobres lutam pelo controle da mítica \r\nterra de Westeros. Intrigas políticas e sexuais não faltam. \r\nAs famílias primárias são as famílias Stark, Lannister e Baratheon. \r\nRobert Baratheon, rei de Westeros, pede a seu velho amigo Eddard \r\nStark para servir como seu principal conselheiro. Eddard, \r\nsuspeitando que seu antecessor havia sido abraçado, aceita para \r\nque ele possa investigar mais. Acontece que mais de uma família \r\nestá tramando para assumir o trono. A família da rainha, os \r\nLannisters, pode estar tramando um plano incestuoso para assumir \r\no controle. Do outro lado do mar, os últimos membros sobreviventes \r\nda família governante anteriormente deposta, os Targaryens, também \r\nestão planejando um retorno ao poder. O conflito entre essas famílias \r\ne outras, incluindo os Greyjoys, os Tullys, os Arryns e os Tyrells, \r\nleva à guerra. Enquanto isso, no norte, um mal antigo desperta. \r\nEm meio à guerra e à confusão política, uma irmandade de desajustados, \r\nA Patrulha da Noite, é tudo o que está entre os reinos dos homens e os \r\nhorrores além." });
            migrationBuilder.InsertData("Serie", new string[] { "serieName", "serieGenre", "serieDescription" }, new object[] { "Star Wars: Tales of the Empire", "Mistério, Ficção cinetífica", "Uma viagem ao temível Império Galáctico através dos \r\nolhos de dois guerreiros em caminhos divergentes, ambientados \r\ndurante diferentes épocas. Depois de perder tudo, a jovem Morgan \r\nElsbeth navega pelo mundo imperial em expansão em direção a um \r\ncaminho de vingança, enquanto a ex-Jedi Barriss Offee faz o que \r\nprecisa para sobreviver a uma galáxia em rápida mudança. As \r\nescolhas que fizerem definirão seus destinos." });
            migrationBuilder.InsertData("Serie", new string[] { "serieName", "serieGenre", "serieDescription" }, new object[] { "The Queens Gambit", "Drama", "Abandonada e confiada a um orfanato de Kentucky no final da \r\ndécada de 1950, a jovem Beth Harmon descobre um talento surpreendente \r\npara o xadrez enquanto desenvolve um vício em tranquilizantes fornecidos \r\npelo estado como sedativo para as crianças. Assombrada por seus demônios \r\npessoais e alimentada por um coquetel de narcóticos e obsessão, Beth se \r\ntransforma em uma pária impressionantemente habilidosa e glamourosa enquanto \r\ndeterminada a conquistar os limites tradicionais estabelecidos no mundo \r\ndominado por homens do xadrez competitivo." });
            migrationBuilder.InsertData("Serie", new string[] { "serieName", "serieGenre", "serieDescription" }, new object[] { "WandaVision", "Romance, Drama", "Wanda Maximoff e Visão estão vivendo a vida suburbana ideal na \r\ncidade de Westview, tentando esconder seus poderes. Mas, à medida que \r\ncomeçam a entrar em novas décadas e se deparam com tropos televisivos, \r\no casal suspeita que as coisas não são como parecem." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Hero");
        }
    }
}
