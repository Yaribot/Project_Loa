using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string entityName;
    public int entityId;
    public int maxHealth;
    public int currentHealth;
    public GameObject Entity3dModel;
    public AudioSource AudioSource;

    public virtual void Attack() { }
    public virtual void Move() { }
    public virtual void Die() { }
}
