using Abp.Domain.Entities;

public class LifeAssured : Entity<long>
{
    public string FullName { get; set; }
    public string IdType { get; set; }
    public string IdNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string RelationshipToOwner { get; set; } // "Self", "Spouse", "Child", etc.
}