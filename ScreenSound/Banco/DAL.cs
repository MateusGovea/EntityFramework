using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class DAL<T> where T : class
    {
        protected readonly ScreenSoundContext context;

        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()  // Método de SELECT
        {
            return context.Set<T>().ToList();
        }
        public void Adicionar(T objeto)  // Método de INSERT
        {
            // Conexão
            // Não é necessário, pois instanciamos a classe já possuindo um context

            // Adicionando o objeto
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void Atualizar(T objeto)  // Método de UPDATE
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
        public void Deletar(T objeto)  // Método de DELETE
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }
        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(a => a.Equals(condicao));
        }
    }
}
