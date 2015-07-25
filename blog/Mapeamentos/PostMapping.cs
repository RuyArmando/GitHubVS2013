using blog.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.Mapeamentos
{
    class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            Table("posts");
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo).Index("idx_titulo");
            Map(post => post.Conteudo).Not.Nullable();
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);
        }
    }
}
