using UnityEngine;

public interface IEntity
{
    public string entityName { get; set; }
    public int entityId { get; set; }
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public GameObject Entity3dModel { get; set; }
    public AudioSource AudioSource { get; set; }
}
