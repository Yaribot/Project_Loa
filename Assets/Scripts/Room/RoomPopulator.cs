using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomPopulator : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public Transform boonSpawnPoint;

    [Header("Pools")]
    public List<Enemy> enemyPool;
    public List<BoonData> boonPool;

    public void Populate(RoomData room)
    {
        SpawnEnemies(room.difficulty);
    }

    private void SpawnEnemies(int difficulty)
    {
        var eligible = enemyPool.Where(e => e.difficulty <=  difficulty).ToList();

        foreach (var point in enemySpawnPoints)
        {
            var enemy = eligible[Random.Range(0, eligible.Count)];
            Instantiate(enemy.Entity3dModel, point.position, Quaternion.identity); // might change with a pooling system instead...
        }
    }

    private void SpawnBoon()
    {
        // Pick 3 random boons and let the player choose one
        //var offered = boonPool.OrderBy(_ => Random.value).Take(3).ToList();

        List<BoonData> available = new List<BoonData>(boonPool); // copy so we can remove
        List<BoonData> offered = new List<BoonData>();

        int picks = Mathf.Min(3, available.Count); // safety: don't pick more than pool has

        for (int i = 0; i < picks; i++)
        {
            BoonData picked = PickWeighted(available);
            offered.Add(picked);
            available.Remove(picked); // remove so it can't be picked again
        }

        // Show UI letting player pick from offered boons
        //BoonSelectionUI.Show(offered);

        // The boon has to be stored in a RunData Script (simple class or ScriptableObject that persist across rooms)
    }

    private BoonData PickWeighted(List<BoonData> pool)
    {
        int totalWeight = pool.Sum(b => b.rarity == 1 ? 60 : b.rarity == 2 ? 30 : 10);
        int roll = Random.Range(0, totalWeight);
        int cumulative = 0;
        foreach (var boon in pool)
        {
            int weight = boon.rarity == 1 ? 60 : boon.rarity == 2 ? 30 : 10;
            cumulative += weight;
            if (roll < cumulative) return boon;
        }
        return pool[0];
    }
}
