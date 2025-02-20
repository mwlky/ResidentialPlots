using System.ComponentModel.DataAnnotations;

namespace Models;

public class ResidentialPlot
{
    [Key]
    public int ID { get; set; }
    
    public string Name { get; set; }
    public string Location { get; set; }
    public string? Description { get; set; }

    public int Size { get; set; }
    public int Price { get; set; }

    public List<Image> Images { get; set; } = new();
}