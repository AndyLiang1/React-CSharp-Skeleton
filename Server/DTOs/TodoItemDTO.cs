namespace Server.Models;

public class TodoItemDTO 
{
    public long Id {get; set;}
    public string? Name {get; set;}

    public bool IsComplete {get; set;}

    public ICollection<Note> Notes {get; set;} = null!;
}