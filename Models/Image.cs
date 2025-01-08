using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Image
{
    [Key]
    public int ID { get; init; }
    
    public string? Path { get; init; }
    public string? Title { get; init; }
    
    public int ResidentialPlotID { get; init; }
    
    [ForeignKey(nameof(ResidentialPlotID))]
    public ResidentialPlot ResidentialPlot { get; init; }
}