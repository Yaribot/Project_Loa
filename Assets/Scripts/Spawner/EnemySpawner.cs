using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEntitySpawner
{
    public List<SpawnPoint> SpawnPositions { get; set; }
    public CharacterBuilder characterBuilder { get; set; } // Voir comment initialiser cette variable...
    public void CreateEntity(IEntity enemy ,string name,int Id ,int maxHealth, int currentHealth, GameObject Entity3dModel, AudioSource audioSource) // add parameters (name, health, etc...) or a enemy scriptableObject
    {        
        enemy.entityName = name;
        enemy.entityId = Id;
        enemy.maxHealth = maxHealth;
        enemy.currentHealth = currentHealth;
        enemy.Entity3dModel = Entity3dModel;
        enemy.AudioSource = audioSource;
        //CreateEnemy(enemy)
    }
    public void CreateEnemy(Vector3 position, Enemy enemy)
    {
        GameObject enemyObject = characterBuilder.EnemyBuilder();
        enemyObject.AddComponent<Enemy>();
        if(enemyObject.TryGetComponent<Enemy>(out Enemy enemyScript)) // Change with specific Enemy...
        {
            enemyScript.entityName = enemy.entityName;
            enemyScript.entityId = enemy.entityId;
            enemyScript.maxHealth = enemy.maxHealth; 
            enemyScript.currentHealth = enemy.currentHealth;
            enemyScript.Entity3dModel = enemy.Entity3dModel;
            enemyScript.AudioSource = enemy.AudioSource;
        }
        Instantiate(enemyObject, position, Quaternion.identity);
    }

    public Vector3 GetRandomSpawnPosition()
    {
        int randomKey = Random.Range(0, SpawnPositions.Count);
        // Don't forget to do "if (SpawnPositions[randomKey].IsOccupied)" On the script that call this function, to check the position is occupied; 
        return SpawnPositions[randomKey].PositionPoint;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
