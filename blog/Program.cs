using blog.DAL;
using blog.Models;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace blog
{
    class Program
    {
        static void Main(string[] args)
        {
            //Post post = new Post()
            //{
            //    Id = 2,
            //    Titulo="Meu primeiro post 12",
            //    Conteudo="Conteudo do post 12",
            //    DataPublicacao = DateTime.Now,
            //    Publicado = true
            //};

            //PostDAO dao = new PostDAO();
            //dao.Atualiza(post);

            //IList<Post> posts = dao.BuscaPorId(2);

            //foreach (var pst in posts)
            //{
            //    Console.WriteLine(pst.Titulo);
            //}

            Configuration cfg = new Configuration();
            cfg.Configure();

            ISessionFactory factory = Fluently.Configure(cfg)
                .Mappings(x =>
                {
                    x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                }).BuildSessionFactory();

            using (ISession session = factory.OpenSession())
            {
                Post post = new Post()
                {
                    Titulo="Meu primeiro post NHibernate",
                    Conteudo = "Conteudo do post NHibernate",
                    DataPublicacao = null,
                    Publicado = true
                };

                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();
            }

        }
    }
}
