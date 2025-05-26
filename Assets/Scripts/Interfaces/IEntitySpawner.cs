using System.Collections.Generic;
using UnityEngine;

public interface IEntitySpawner
{
    public List<Vector3> SpawnPositions { get; set; }
    void CreateEntity(IEntity entity ,string name,int Id, int maxHealth, int currentHealth, GameObject Entity3dModel, AudioSource AudioSource);
}
