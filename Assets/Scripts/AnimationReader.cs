using UnityEngine;

public class AnimationReader : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] InputReader input;

    private void Update()
    {
        MoveInputReading(input.Direction);
    }

    public void MoveInputReading(Vector2 direction)
    {
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
}
