using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    [SerializeField]private Animator animator;
    public void Move(Vector3 movement, bool running) 
    {
        animator.SetFloat("Velocity", movement.magnitude);
        animator.SetBool("Run", running);
    }
    public void Dance(bool dancing)
    {
        animator.SetBool("Dance", dancing);
    }
    public void Jump()
    {
        animator.SetBool("Jump", true);
        animator.SetBool("Jump", false);
    }
}
