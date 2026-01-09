using UnityEngine;
[RequireComponent (typeof(AnimationBehaviour))]

public class MoveBehaviour : MonoBehaviour
{
    private CharacterController _cC;
    private AnimationBehaviour _aB;
    private Vector3 velocity;
    [SerializeField] private float speed = 4;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Transform aimCameraPosition;
    [SerializeField] private float steerSpeed = 10;
    [SerializeField] private float gravity = -2;
    [SerializeField] private float jumpForce = 2;
    private void Awake()
    {
        _cC = GetComponent<CharacterController>();
        _aB = GetComponent<AnimationBehaviour>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if(_cC.isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        velocity.y += gravity * Time.deltaTime;
        _cC.Move(velocity * Time.deltaTime);
        if (!_cC.isGrounded)
        {
            _aB.Fall();
        }
        else
        {
            _aB.OnGround();
        }
    }
    public void MoveCharacter(Vector3 direction, bool run, bool aiming)
    {
        Vector3 forward = cameraPosition.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = cameraPosition.right;
        right.y = 0;
        right.Normalize();
        Vector3 aimForward = aimCameraPosition.forward;
        aimForward.y = 0;
        aimForward.Normalize();
        Vector3 movement = direction.x * right + direction.z * forward;
        if (aiming)
        {
            Quaternion rotation = Quaternion.LookRotation(aimForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, steerSpeed * Time.deltaTime);
        }
        else
        {
            if (movement.sqrMagnitude > 0.001)
            {
                Quaternion rotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, steerSpeed * Time.deltaTime);
            }
        }
        if(!run)
            Walk(movement);
        else
            Run(movement);
        _aB.Move(movement, run);
    }
    private void Walk(Vector3 movement)
    {
        _cC.Move(movement * speed * Time.deltaTime);
    }
    private void Run(Vector3 movement)
    {
        _cC.Move(movement * speed * sprintMultiplier * Time.deltaTime);
    }
    public void Jump()
    {
        if (_cC.isGrounded)
        {
            velocity.y = jumpForce;
            _aB.Jump();
        }
    }
}
