using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunGenerator : MonoBehaviour
{
    public static RunGenerator Instance;

    public RoomPool pool;
    public int doorsPerRoom = 2; // how many choices to offer

    private RoomData _currentRoom;
    private int _currentDifficulty = 1;
    private int _roomsCleared = 0;
    private int _bossThreshold = 8;

    private List<RoomData> _sequence = new();

    void Awake() => Instance = this;

    //public List<RoomData> GenerateRun()
    //{
    //    _sequence.Clear();

    //    for (int i = 0; i < runLength; i++)
    //    {
    //        // Every 3rd room is a shop or rest, others are combat
    //        if (i % 3 == 2)
    //            _sequence.Add(Random.value > 0.5f ? GetRandom(pool.shopRooms) : GetRandom(pool.restRooms));
    //        else
    //            _sequence.Add(GetRandom(pool.combatRooms));
    //    }

    //    _sequence.Add(pool.bossRoom); // always end with boss
    //    return _sequence;
    //}

    //RoomData GetRandom(List<RoomData> list) => list[Random.Range(0, list.Count)];

    // Call this when the player clears a room
    public List<RoomData> GetNextRoomChoices()
    {
        // Bump difficulty every 3 rooms
        if (_roomsCleared > 0 && _roomsCleared % 3 == 0)
            _currentDifficulty = Mathf.Min(_currentDifficulty + 1, 3);

        if (_roomsCleared >= _bossThreshold)
            return new List<RoomData> { pool.bossRoom };

        List<RoomData> choices = new List<RoomData>();
        List<RoomData> eligible = GetEligibleRooms(_currentDifficulty);

        // Remove current room so it can't appear as a next choice
        eligible.Remove(_currentRoom);

        for (int i = 0; i < doorsPerRoom && eligible.Count > 0; i++)
        {
            RoomData picked = eligible[Random.Range(0, eligible.Count)];
            choices.Add(picked);
            eligible.Remove(picked); // no duplicate doors
        }

        return choices;
    }

    private List<RoomData> GetEligibleRooms(int difficulty)
    {
        // Same difficulty or higher, all room types combined
        return pool.combatRooms
            .Concat(pool.shopRooms)
            .Concat(pool.restRooms)
            .Where(r => r.difficulty >= difficulty)
            .ToList();
    }

    // Call this when the player walks through a specific door
    public void OnPlayerChooseRoom(RoomData chosen)
    {
        _currentRoom = chosen;
        _roomsCleared++;
        FindFirstObjectByType<RoomManager>().LoadRoom(chosen);
    }
}
