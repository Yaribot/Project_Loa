using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<Door> doors;

    public void ActivateDoors(List<RoomData> choices)
    {
        for (int i = 0; i < doors.Count; i++)
        {
            if (i < choices.Count)
            {
                doors[i].gameObject.SetActive(true);
                doors[i].Assign(choices[i]);
            }
            else
            {
                doors[i].gameObject.SetActive(false); // hide unused doors
            }
        }
    }
}
