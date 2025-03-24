using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Player player = (Player)target;

        if(GUILayout.Button("Increase Health"))
        {
            player.Health.Value += 10;
        }
        if (GUILayout.Button("Decrease Health"))
        {
            player.Health.Value -= 10;
        }
    }
}
