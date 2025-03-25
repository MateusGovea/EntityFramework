using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {

        private readonly ScreenSoundContext context;

        public ArtistaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artista> Listar()      // Método de SELECT
        {
            return context.Artistas.ToList();     // Retornando a lista de artistas
        }

        public void Adicionar (Artista artista)   // Método de INSERT
        {
            // Conexão
            // Não é necessário, pois instanciamos a classe já possuindo um context

            // Adicionando o artista
            context.Artistas.Add(artista);
            context.SaveChanges();
        }

        public void Atualizar(Artista artista) // Método de UPDATE
        {
            context.Artistas.Update(artista);
            context.SaveChanges();
        }

        public void Deletar(Artista artista) // Método de DELETE
        {
            context.Artistas.Remove(artista);
            context.SaveChanges();
        }

        public Artista? RecuperarPeloNome(string nome)
        {
            return context.Artistas.FirstOrDefault(a => a.Equals(nome));
        }
    }
}
