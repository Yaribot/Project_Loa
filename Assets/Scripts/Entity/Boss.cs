using UnityEngine;

public abstract class Boss : MonoBehaviour, IEntity
{
    public string entityName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int entityId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int maxHealth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int currentHealth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject Entity3dModel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public AudioSource AudioSource { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public virtual void Attack() { }
    public virtual void Move() { }
    public virtual void Die() { }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
