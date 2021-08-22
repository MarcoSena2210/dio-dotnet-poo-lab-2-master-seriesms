using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();

		static FilmeController filmeController = new FilmeController();

		
        static void Main(string[] args)
        {
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
					case "6":
					    filmeController.ListarFilmes();
						break;
					case "7":
						filmeController.inserirFilme();
						break;	
					case "8":
						filmeController.AtualizarFilme();
						break;
					case "9":
						filmeController.ExcluirFilme();
						break;
					case "10":
					    filmeController.VisualizarFilme();
						break;

					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
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

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
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
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
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
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

				
			string entradaTitulo = "";
			do
			{
				Console.Write("Digite o Título da Série: ");
				entradaTitulo = Console.ReadLine();
				
						
				if(String.IsNullOrEmpty(entradaTitulo)){
					Console.Write("O campo é obrigatório");
				} 	
							
							
			} while (String.IsNullOrEmpty(entradaTitulo));


			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}


        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("    |++++++++++++++++++++++++++++++++++++++++++++++++++++++++||||");
			Console.WriteLine("   |++++++++++++++++++++++++++++++++++++++++++++++++++++++++|||||");
		    Console.WriteLine("  |++++++++++++++++++++++++++++++++++++++++++++++++++++++++||||||");
			Console.WriteLine(" |++++++++++++++++++++++++++++++++++++++++++++++++++++++++|||||||");
			Console.WriteLine("|          SERIES           |         FILMES            ||||||||");
			Console.WriteLine("| 1- Listar séries          | 6- Listar filmes          |||||||");
			Console.WriteLine("| 2- Inserir nova série     | 7- Inserir novo filme     ||||||");
			Console.WriteLine("| 3- Atualizar série        | 8- Atualizar filme        |||||");
			Console.WriteLine("| 4- Excluir série          | 9- Excluir filme          ||||");
			Console.WriteLine("| 5- Visualizar série       | 10- Visualizar filme      |||");
			Console.WriteLine("|                           |                           ||");
			Console.WriteLine("|__________ SERIES _________|_________ FILMES __________|");
			Console.WriteLine("|                                                       |");
			Console.WriteLine("|  C- Limpar Tela              X- Sair                  |");
			Console.WriteLine("|                                                       |");
			Console.WriteLine("|*******************************************************|");
			Console.WriteLine();
	        Console.WriteLine("Informe a opção desejada:");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

    }
}
