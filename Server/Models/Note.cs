using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class Note 
{
    public long Id {get; set;}

    public string? Content {get; set;}

    [ForeignKey("TodoItem")]
    public int TodoItemId {get; set;}

    public TodoItem? TodoItem {get; set;} = null!;
}