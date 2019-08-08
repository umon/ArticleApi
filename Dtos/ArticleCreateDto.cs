using System.ComponentModel.DataAnnotations;

namespace ArticleApi.Dtos
{
    public class ArticleCreateDto
    {
        [Required(ErrorMessage = "Makale başlığı belirtmelisiniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Makale içeriği boş bırakılamaz")]
        public string Content { get; set; }
        public string Author { get; set; }
    }
}