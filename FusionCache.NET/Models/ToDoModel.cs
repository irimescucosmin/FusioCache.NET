namespace FusionCache.NET.Models;

public class ToDoModel
{
    public required int UserId { get; set; }
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required bool Completed { get; set; }
}