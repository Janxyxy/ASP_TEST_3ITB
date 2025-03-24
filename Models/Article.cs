using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_TEST_3ITB.Models
{
    public class ArticleDTO
    {
        public int Id { get; set; }

        [MaxLength(200), Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CurrentTimestamp { get; set; }
    }

    public class Article
    {
        public int Id { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [MaxLength(200), Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CurrentTimestamp { get; set; }

        // Default constructor
        public Article()
        {
        }

        // Constructor with ArticleDTO and User
        public Article(ArticleDTO articleDTO, User author)
        {
            Title = articleDTO.Title;
            Content = articleDTO.Content;
            Date = articleDTO.Date;
            Author = author;
            AuthorId = author.Id;
        }
    }

    public static class ArticleExtensions
    {
        public static ArticleDTO ToDTO(this Article article)
        {
            return new ArticleDTO
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                Date = article.Date,
                CurrentTimestamp = article.CurrentTimestamp
            };
        }

        public static Article ToEntity(this ArticleDTO articleDTO, User author)
        {
            return new Article
            {
                Title = articleDTO.Title,
                Content = articleDTO.Content,
                Date = articleDTO.Date,
                Author = author,
                AuthorId = author.Id
            };
        }
    }
}