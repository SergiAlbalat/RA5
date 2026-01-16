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
        animator.SetTrigger("Jump");
    }
    public void Fall()
    {
        animator.SetBool("Falling", true);
    }
    public void OnGround()
    {
        animator.SetBool("Falling", false);
    }
    public void Aim(bool aiming)
    {
        animator.SetBool("Aiming", aiming);
    }
    public void Shoot(bool shooting)
    {
        animator.SetBool("Shooting", shooting);
    }
}
