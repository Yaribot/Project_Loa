using UnityEngine;

[CreateAssetMenu(fileName = "BoonData", menuName = "Scriptable Objects/BoonData")]
public class BoonData : ScriptableObject
{
    public string boonName;
    public string description;
    public Sprite icon;
    public int rarity; // 1 = common, 3 = rare
    // Apply effect to the player
    public void Apply(PlayerStats player) { /* your logic */ }
}
