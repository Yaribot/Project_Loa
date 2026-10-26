using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //public UnityEvent StartRun;
    [SerializeField]
    private RunGenerator _runGenerator;
    [SerializeField]
    private RoomManager _roomManager;
    public UnityEvent PlayerEnteringDoor;

    private List<RoomData> _runSequence;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartRun.Invoke();
        StartRun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRun()
    {
        //_runSequence = _runGenerator.GenerateRun();
    }

    public void LoadingLevel()
    {
        //_roomManager.LoadRoom(_runSequence) 
        // select a room... maybe between 3 or less available room;
    }

    //private void OfferNextLevelChoice()
    //{
    //    List<RoomData> available = new List<RoomData>(_runSequence);
    //    List<RoomData> offered = new List<RoomData>();

    //    int picks = Mathf.Min(1, available.Count); // safety: don't pick more than pool has

    //    for (int i = 0; i < picks; i++)
    //    {
    //        RoomData picked = PickNextLevel(available);
    //        offered.Add(picked);
    //        available.Remove(picked); // remove so it can't be picked again
    //    }
    //}

    //private RoomData PickNextLevel(List<RoomData>pool) // Check the result, wanted behavior : pick a room around the same difficulty or higer than the current room...
    //{
    //    int totalWeight = pool.Sum(b => b.difficulty == 1 ? 60 : b.difficulty == 2 ? 30 : 10);
    //    int roll = Random.Range(0, totalWeight);
    //    int cumulative = 0;
    //    foreach (var roon in pool)
    //    {
    //        int weight = roon.difficulty == 1 ? 60 : roon.difficulty == 2 ? 30 : 10;
    //        cumulative += weight;
    //        if (roll < cumulative) return roon;
    //    }
    //    return pool[0];
    //}
}
