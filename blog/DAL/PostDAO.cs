using blog.Infra;
using blog.Models;
using NHibernate;
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
                using (ISession session = NHibernateHelper.AbreSession())
                {
                    ITransaction tx = session.BeginTransaction();
                    session.Save(post);
                    tx.Commit();
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
                using (ISession session = NHibernateHelper.AbreSession())
                {
                    ITransaction tx = session.BeginTransaction();
                    session.Merge(post);
                    tx.Commit();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Remove(Post post)
        {
            try
            {
                using (ISession session = NHibernateHelper.AbreSession())
                {
                    ITransaction tx = session.BeginTransaction();
                    session.Delete(post);
                    tx.Commit();
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
                using (ISession session = NHibernateHelper.AbreSession())
                {
                    string hsql = "select p from Post p";
                    IQuery query = session.CreateQuery(hsql);
                    return query.List<Post>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Post BuscaPorId(int pId)
        {
            try
            {
                using (ISession session = NHibernateHelper.AbreSession())
                {
                    return session.Get<Post>(pId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
