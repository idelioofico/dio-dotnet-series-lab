using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listaSeries();
                        break;
                    case "2":
                        inserirSerie();
                        break;
                    case "3":
                        ActualizaSerie();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        VisualizaSerie();
                        break;
                    case "6":
                        LimparTela();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series a seu dispor!!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Series");
            Console.WriteLine("3- Actualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void listaSeries()
        {
            Console.WriteLine("Lista de series");
            Console.WriteLine();
            var lista = repositorio.Lista();


            if (lista.Count == 0)
            {
                Console.Write("Nenhuma serie foi cadastrada ainda");
            }
            else
            {
                Console.WriteLine("---------------------------------");
                foreach (var item in lista)
                {
                    var excluido = item.retornaExcluido();
                    Console.WriteLine("{0}. {1} {2}",item.ID,item.Titulo,excluido?"*Excluido*":"");
                }
                Console.WriteLine("---------------------------------");
            }
        }

        private static void inserirSerie()
        {
            Console.WriteLine("Inserir genero");
            Console.WriteLine();

            foreach (var item in Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"{item}. {Enum.GetName(typeof(Genero), item)}");

            int.TryParse(colectaDados("Dentre as opções acima, selecione o gênero: "), out int genero);

            string titulo = colectaDados("Introduza o título: ");

            int.TryParse(colectaDados("Introduza o ano de lançamento: "), out int ano);

            string descricao = colectaDados("Introduza a descrição: ");

            var serie = new Serie(repositorio.ProximoId(), (Genero)genero, descricao, titulo, ano);

            repositorio.Insere(serie);
        }

        private static void ActualizaSerie()
        {
            Console.WriteLine("Actualizar Série");
            Console.WriteLine();
            Console.Write("Indique o codigo do registo que pretende actualizar: ");
            int.TryParse(Console.ReadLine(), out int id);

            var dados = repositorio.RetornaPorId(id);


            foreach (var item in Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"{item}. {Enum.GetName(typeof(Genero), item)}");

            int.TryParse(colectaDados("Dentre as opções acima, selecione o gênero: ", dados.Genero.ToString()), out int genero);

            string titulo = colectaDados("Introduza o título: ", dados.Titulo);

            int.TryParse(colectaDados("Introduza o ano de lançamento: ", dados.Ano.ToString()), out int ano);

            string descricao = colectaDados("Introduza a descrição: ", dados.Descricao);

            var serie = new Serie(dados.ID, (Genero)genero, descricao, titulo, ano);

            repositorio.Actualiza(dados.ID, serie);

        }
        //Coleta, verifica(vazios para insert ou update) dados de entrada
        private static string colectaDados(string texto, string campo = null)
        {
            Console.WriteLine(texto);
            string entrada = Console.ReadLine();


            while (string.IsNullOrEmpty(entrada))
            {
                if (string.IsNullOrEmpty(campo))
                {
                    entrada = Console.ReadLine();
                }
                else
                {
                    entrada = campo;
                }

            }

            return entrada;
        }
        private static void ExcluiSerie()
        {
            Console.WriteLine("Excluir série");
            Console.WriteLine();

            int.TryParse(colectaDados("Introduza o codigo da serie que deseja excluir: "), out int id);

            var data = repositorio.RetornaPorId(id);
            if (!data.Equals(null))
            {
                Console.Write("Tem a certeza?[s/n]: ");
                if (Console.ReadLine().ToUpper() == "S")
                    data.Exclui();
            }


        }

        private static void VisualizaSerie()
        {
            Console.WriteLine("Excluir série");
            Console.WriteLine();

            int.TryParse(colectaDados("Introduza o codigo da serie que deseja visualizar: "), out int id);
            var dados = repositorio.RetornaPorId(id);
            if (!dados.Equals(null))
            {
                Console.WriteLine(dados.ToString());
            }
        }

        private static void LimparTela()
        {
            Console.Clear();
        }

    }
}
