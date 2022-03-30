﻿namespace ClassLibrary.Classes;

public class Job
{
    public Job(Guid id, string title, string description, DateTime deadline, Category category, Address location, Guid clientId)
    {
        Id = id;
        Title = title;
        Description = description;
        Deadline = deadline;
        Category = category;
        Location = location;
        ClientId = clientId;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Deadline { get; set; }
    
    public Category Category { get; set; }
    
    public Address Location { get; set; }
    
    public Guid ClientId { get; set; }
}