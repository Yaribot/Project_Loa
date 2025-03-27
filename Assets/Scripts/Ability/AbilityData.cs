using Sirenix.OdinInspector;
using UnityEngine;

namespace Architecture.AbilitySystem
{
    [CreateAssetMenu(fileName = "AbilityData", menuName = "Scriptable Objects/AbilityData")]
    public class AbilityData : ScriptableObject
    {
        [VerticalGroup("row1/left")] public AnimationClip animationClip;
        [VerticalGroup("row1/left"), ReadOnly] public int animationHash;
        [VerticalGroup("row1/left")] public float duration;
        [PreviewField(50, ObjectFieldAlignment.Right), HideLabel]
        [HorizontalGroup("row1", 50), VerticalGroup("row1/right")] public Sprite icon;

        private void OnValidate()
        {
            animationHash = Animator.StringToHash(animationClip.name);
        }
    }
}
