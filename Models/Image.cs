using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Image
{
    [Key]
    public int ID { get; set; }
    
    public string? Path { get; set; }
    public string? Title { get; set; }
    
    public int ResidentialPlotID { get; set; }
    
    [ForeignKey(nameof(ResidentialPlotID))]
    public ResidentialPlot ResidentialPlot { get; set; }
}