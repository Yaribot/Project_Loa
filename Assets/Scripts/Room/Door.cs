using UnityEngine;

public class Door : MonoBehaviour
{
    private RoomData _assignedRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Assign(RoomData room)
    {
        _assignedRoom = room;
        ShowRoomType();
    }

    public void ShowRoomType() 
    {
        switch (_assignedRoom.roomType)
        {
            case RoomType.Combat:
                NextRoomIconReveal();
                break;
            case RoomType.Shop:
                NextRoomIconReveal();
                break;
            case RoomType.Rest:
                NextRoomIconReveal();
                break;
            case RoomType.Boss:
                NextRoomIconReveal();
                break;
        } 
    }

    private void NextRoomIconReveal()
    {
        // Animation or VFX here...
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            RunGenerator.Instance.OnPlayerChooseRoom(_assignedRoom);
    }
}
