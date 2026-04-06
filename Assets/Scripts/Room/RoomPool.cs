using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomPool", menuName = "Scriptable Objects/RoomPool")]
public class RoomPool : ScriptableObject
{
    public List<RoomData> combatRooms;
    public List<RoomData> shopRooms;
    public List<RoomData> restRooms;
    public RoomData bossRoom;
}
