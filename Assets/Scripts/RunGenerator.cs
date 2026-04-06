using System.Collections.Generic;
using UnityEngine;

public class RunGenerator : MonoBehaviour
{
    public RoomPool pool;
    public int runLength = 8; // rooms before the boss

    private List<RoomData> _sequence = new();

    public List<RoomData> GenerateRun()
    {
        _sequence.Clear();

        for (int i = 0; i < runLength; i++)
        {
            // Every 3rd room is a shop or rest, others are combat
            if (i % 3 == 2)
                _sequence.Add(Random.value > 0.5f ? GetRandom(pool.shopRooms) : GetRandom(pool.restRooms));
            else
                _sequence.Add(GetRandom(pool.combatRooms));
        }

        _sequence.Add(pool.bossRoom); // always end with boss
        return _sequence;
    }

    RoomData GetRandom(List<RoomData> list) => list[Random.Range(0, list.Count)];
}
