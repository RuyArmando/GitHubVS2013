# NHibernate: Persistência de dados com C#
> Porjeto de um Blog

Usando o **NHibernate** e realizando o mapeamento com o **Fluent NHibernate**

```csharp
// Program.cs
public class Program
{
    public static void Main()
    {
        Post post = new Post()
        {
            Id = 2,
            Titulo = "Meu primeiro post 12",
            Conteudo = "Conteudo do post 12",
            DataPublicacao = DateTime.Now,
            Publicado = true
        };

        PostDAO dao = new PostDAO();
        dao.Atualiza(post);
        Console.WriteLine("Atualizei: " + post.Id);

        post.Id = 0;
        dao.Adiciona(post);
        Console.WriteLine("Adicionei: " + post.Id);

        IList<Post> posts = dao.Lista();

        foreach (var pst in posts)
        {
            Console.WriteLine("encontrei: " + pst.Id + " - " + pst.Titulo);
        }

        Post p = dao.BuscaPorId(post.Id);

        if (p != null)
        {
            Console.WriteLine("removi: " + p.Id);
            dao.Remove(p);
        }

        Console.ReadKey();
    }
}
```
