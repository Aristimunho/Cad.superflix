using System;

namespace cad.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
			Console.WriteLine("  ▓▓▓▓▓ ▓  ▓ ▓▓▓▓ ▓▓ ▓▓▓▓▓      ");
			Console.WriteLine("  ▓     ▓  ▓ ▓  ▓ ▓  ▓   ▓      ");
			Console.WriteLine("  ▓▓▓▓▓ ▓  ▓ ▓  ▓ ▓▓ ▓▓▓▓▓      ");
			Console.WriteLine("      ▓ ▓▓▓▓ ▓▓▓▓ ▓  ▓  ▓       ");
			Console.WriteLine("  ▓▓▓▓▓ ▓▓▓▓ ▓    ▓▓ ▓  ▓       ");
			Console.WriteLine(" **********  FLIX  **********   ");
			Console.WriteLine();

			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Agradecemos a preferência até a próxima!!");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Dentro das opções qual o gênero?");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Qual o Título da Série? ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("E o ano de início da Série? ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Dê uma breve descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listando séries para você...");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Opa, não tempos nenhuma série no cadastro :(");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Você quer inserir uma nova série");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine();
			Console.Write("Digite o n° correspendente ao gênero escolhido: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Qual o Título da Série? ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("E o ano de início da Série? ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Dê uma breve descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
			Console.Write("Sua série foi adicionada com sucesso!");
		} 

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("   O que você deseja fazer? ");
			Console.WriteLine("╔════════════════════════════╗");
			Console.WriteLine("║(1) Listar séries           ║");
			Console.WriteLine("╠════════════════════════════╣ ");
			Console.WriteLine("║(2) Adicionar nova série    ║");
			Console.WriteLine("╠════════════════════════════╣ ");
			Console.WriteLine("║(3) Atualizar série         ║");
			Console.WriteLine("╠════════════════════════════╣ ");
			Console.WriteLine("║(4) Excluir série           ║");
			Console.WriteLine("╠════════════════════════════╣ ");
			Console.WriteLine("║(5) Ver série               ║");
			Console.WriteLine("╠════════════════════════════╣ ");
			Console.WriteLine("║(C) Limpar Tela             ║");
			Console.WriteLine("╠════════════════════════════╣ ");
			Console.WriteLine("║(X) Sair                    ║");
			Console.WriteLine("╚════════════════════════════╝ ");
			Console.WriteLine();


			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
