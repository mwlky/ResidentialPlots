using System.ComponentModel.DataAnnotations;

namespace Models;

public class ResidentialPlot
{
    [Key]
    public int ID { get; init; }
    
    public string? Name { get; init; }
    public string? Location { get; init; }
    public string? Description { get; init; }

    public int? Size { get; init; }
    public int? Price { get; init; }

    public List<Image> Images { get; init; } = new();
}