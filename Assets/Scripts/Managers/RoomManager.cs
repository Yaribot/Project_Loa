using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    private string _currentRoomScene;

    public IEnumerator LoadRoom(RoomData room)
    {
        // Unload previous room
        if(_currentRoomScene != null)
        {
            yield return SceneManager.UnloadSceneAsync(_currentRoomScene);

            // Load new room on top of the persistent scene
            yield return SceneManager.LoadSceneAsync(room.sceneName, LoadSceneMode.Additive);

            _currentRoomScene = room.sceneName;

            // Tell the room to populate itself
            FindObjectOfType<RoomPopulator>()?.Populate(room);
        }
    }
}
