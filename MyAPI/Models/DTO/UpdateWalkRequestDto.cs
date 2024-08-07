namespace MyAPI.Models.DTO {
  public class UpdateWalkRequestDto {
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthKm { get; set; }
    public string? WalkImageUrl { get; set; }
    public Guid RegionId { get; set; }
    public Guid DifficultyId { get; set; }
  }
}
