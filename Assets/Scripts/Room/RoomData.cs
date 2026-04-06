using UnityEngine;

public enum RoomType { Combat, Shop, Rest, Boss }

[CreateAssetMenu(fileName = "RoomData", menuName = "Scriptable Objects/RoomData")]
public class RoomData : ScriptableObject
{
    public string sceneName;      // the Unity scene to load
    public RoomType roomType;
    public int difficulty;        // 1–3
}
