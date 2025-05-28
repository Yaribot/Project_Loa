using UnityEngine;

public class CharacterBuilder
{
    public GameObject EnemyBuilder()
    {
        GameObject enemyobject = new GameObject();
        GameObject model = new GameObject();
        GameObject vfx = new GameObject();
        model.transform.SetParent(enemyobject.transform);
        vfx.transform.SetParent(enemyobject.transform);
        model.name = "3Dmodel";
        vfx.name = "VFX";
        return enemyobject;
    }
}
