using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsOccupied { get; set; }
    public Vector3 PositionPoint { get; private set; }
    private void Awake()
    {
        PositionPoint = transform.position;
    }
}
