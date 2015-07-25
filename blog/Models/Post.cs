using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.Models
{
    class Post
    {
        public Post()
        {

        }

        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual DateTime? DataPublicacao { get; set; }
        public virtual bool Publicado { get; set; }
    }
}
