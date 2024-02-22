namespace Server.Models;

public class TodoItem 
{
    public int Id {get; set;}

    public string? Name {get; set;}

    public bool IsComplete {get; set;}

    public string? Secret {get; set;}

    public ICollection<Note> Notes {get;} = new List<Note>();


}