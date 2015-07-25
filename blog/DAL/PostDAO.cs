using blog.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace blog.DAL
{
    class PostDAO
    {

        public void Adiciona(Post post)
        {
            try
            {
                using (IDbConnection conexao = ConnectionFactory.CriarConexao())
                {
                    using (IDbCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText = "INSERT INTO posts (titulo, conteudo, dataPublicacao, publicado)" +
                            " VALUES (@titulo, @conteudo, @dataPublicacao, @publicado)";

                        IDbDataParameter paramTitulo = comando.CreateParameter();
                        paramTitulo.ParameterName = "titulo";
                        paramTitulo.Value = post.Titulo;
                        comando.Parameters.Add(paramTitulo);

                        IDbDataParameter paramConteudo = comando.CreateParameter();
                        paramConteudo.ParameterName = "conteudo";
                        paramConteudo.Value = post.Conteudo;
                        comando.Parameters.Add(paramConteudo);

                        IDbDataParameter paramData = comando.CreateParameter();
                        paramData.ParameterName = "dataPublicacao";
                        paramData.Value = post.DataPublicacao;
                        comando.Parameters.Add(paramData);

                        IDbDataParameter paramPublicado = comando.CreateParameter();
                        paramPublicado.ParameterName = "publicado";
                        paramPublicado.Value = post.Publicado;
                        comando.Parameters.Add(paramPublicado);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Atualiza(Post post)
        {
            try
            {
                using (IDbConnection conexao = ConnectionFactory.CriarConexao())
                {
                    using (IDbCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText = "UPDATE posts SET titulo = @titulo " +
                            ", conteudo = @conteudo " +
                            ", dataPublicacao = @dataPublicacao " +
                            ", publicado = @publicado" +
                            " WHERE id = @id";

                        IDbDataParameter paramId = comando.CreateParameter();
                        paramId.ParameterName = "id";
                        paramId.Value = post.Id;
                        comando.Parameters.Add(paramId);

                        IDbDataParameter paramTitulo = comando.CreateParameter();
                        paramTitulo.ParameterName = "titulo";
                        paramTitulo.Value = post.Titulo;
                        comando.Parameters.Add(paramTitulo);

                        IDbDataParameter paramConteudo = comando.CreateParameter();
                        paramConteudo.ParameterName = "conteudo";
                        paramConteudo.Value = post.Conteudo;
                        comando.Parameters.Add(paramConteudo);

                        IDbDataParameter paramData = comando.CreateParameter();
                        paramData.ParameterName = "dataPublicacao";
                        paramData.Value = post.DataPublicacao;
                        comando.Parameters.Add(paramData);

                        IDbDataParameter paramPublicado = comando.CreateParameter();
                        paramPublicado.ParameterName = "publicado";
                        paramPublicado.Value = post.Publicado;
                        comando.Parameters.Add(paramPublicado);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Post> Lista()
        {

            try
            {
                using (IDbConnection conexao = ConnectionFactory.CriarConexao())
                {
                    using (IDbCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM posts";

                        IDataReader leitor = comando.ExecuteReader();
                        IList<Post> posts = new List<Post>();

                        while (leitor.Read())
                        {
                            Post post = new Post();

                            post.Id = Convert.ToInt32(leitor["id"]);
                            post.Titulo = Convert.ToString(leitor["conteudo"]);
                            post.Conteudo = Convert.ToString(leitor["conteudo"]);

                            if (!Convert.IsDBNull(leitor["dataPublicacao"]))
                            {
                                post.DataPublicacao = Convert.ToDateTime(leitor["dataPublicacao"]);
                            }

                            posts.Add(post);
                        }

                        leitor.Close();
                        return posts;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Post> BuscaPorId(int pId)
        {

            try
            {
                using (IDbConnection conexao = ConnectionFactory.CriarConexao())
                {
                    using (IDbCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM posts WHERE id = @id";

                        IDbDataParameter paramId = comando.CreateParameter();
                        paramId.ParameterName = "id";
                        paramId.Value = pId;
                        comando.Parameters.Add(paramId);

                        IDataReader leitor = comando.ExecuteReader();
                        IList<Post> posts = new List<Post>();

                        while (leitor.Read())
                        {
                            Post post = new Post();

                            post.Id = Convert.ToInt32(leitor["id"]);
                            post.Titulo = Convert.ToString(leitor["conteudo"]);
                            post.Conteudo = Convert.ToString(leitor["conteudo"]);

                            if (!Convert.IsDBNull(leitor["dataPublicacao"]))
                            {
                                post.DataPublicacao = Convert.ToDateTime(leitor["dataPublicacao"]);
                            }

                            posts.Add(post);
                        }

                        leitor.Close();
                        return posts;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
