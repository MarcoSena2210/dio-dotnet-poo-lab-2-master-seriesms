using System.Security.Cryptography.X509Certificates;
using System;


namespace DIO.Series
{
  
    public class FilmeController 
    {
      
      	static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
		string entradaTitulo,entradaDescricao,entradaAutor,texto;

        public void inserirFilme()		
        {
			Console.WriteLine("Inserir novo filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			
			int entradaGenero = int.Parse(Console.ReadLine());
            //TODO: Validar a entrada 

			/** entradaTitulo */
			do{		
				Console.Write("Digite o Título do filme: ");
				entradaTitulo = Console.ReadLine();
			} while (isCampoStringObrigatorio(entradaTitulo));
			 /** entradaAno */
			do{
                Console.Write("Digite o Ano (apenas números) de Início do filme: ");
			    texto = Console.ReadLine();
         	} while (isCampoNotNumerio(texto));
			int entradaAno = int.Parse(texto);
		
			 /** entradaDescricao */
			do{		
				Console.Write("Digite a Descrição do Filme: ");
				entradaDescricao = Console.ReadLine();
			} while (isCampoStringObrigatorio(entradaDescricao));
			/** entradaAutor */
		    do{
				Console.Write("Digite o autor do Filme: ");
				entradaAutor = Console.ReadLine();
			} while (isCampoStringObrigatorio(entradaAutor));
	
			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										autor: entradaAutor);

			repositorioFilme.Insere(novoFilme);
		}

		public void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        public void AtualizarFilme(){
			
			Console.Write("Digite o id do filme: ");
			int indice = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());


	       /** entradaTitulo */
			do{		
				Console.Write("Digite o Título do filme: ");
				entradaTitulo = Console.ReadLine();
			} while (isCampoStringObrigatorio(entradaTitulo));
			 /** entradaAno */
			do{
                Console.Write("Digite o Ano (apenas números) de Início do filme: ");
			    texto = Console.ReadLine();
         	} while (isCampoNotNumerio(texto));
			int entradaAno = int.Parse(texto);
		
			 /** entradaDescricao */
			do{		
				Console.Write("Digite a Descrição do Filme: ");
				entradaDescricao = Console.ReadLine();
			} while (isCampoStringObrigatorio(entradaDescricao));
			/** entradaAutor */
		    do{
				Console.Write("Digite o autor do Filme: ");
				entradaAutor = Console.ReadLine();
			} while (isCampoStringObrigatorio(entradaAutor));

			Filme atualizaFilme = new Filme(id: indice,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										autor:entradaAutor);
			repositorioFilme.Atualiza(indice, atualizaFilme);
		}

        public void ExcluirFilme()
		{
			Console.Write("Digite o id da filme a ser excluído: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioFilme.Exclui(indiceFilme);
		}

        public void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioFilme.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

         /** Valida entrada texto obrigatorio */
		private static bool isCampoStringObrigatorio(string entrada){
  			bool retorno =false;		
			if(String.IsNullOrEmpty(entrada)) {
                retorno=true;
		     	Console.Write("O campo acima é obrigatório");
				Console.ReadLine(); 
			} 
			return retorno;
		} 
		
        /** Valida entrada numerica */
		private static bool isCampoNotNumerio(string entrada){
  			bool retorno =false;
		    double numero = 0;  		

            if (!double.TryParse(entrada, out numero)){
		        retorno=true;
                Console.WriteLine("Ano inválido,dados não numérico!");
			} 
			return retorno;
		} 
	
    }
}