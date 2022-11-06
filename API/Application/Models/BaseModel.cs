using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class BaseModel
{
    [Key]
    public long Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
}