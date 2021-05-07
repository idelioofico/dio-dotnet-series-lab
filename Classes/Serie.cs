using System;
namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        // Propriedades
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }


        //Metodos
        public Serie(int id, Genero genero, string descricao, string titulo, int ano)
        {
            this.ID = id;
            this.Genero = genero;
            this.Descricao = descricao;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Excluido = false;
        }


        public override string ToString()
        {
            string retorno = "";
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Descrição" + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido:" + this.Excluido;

            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.ID;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }
    }




}
