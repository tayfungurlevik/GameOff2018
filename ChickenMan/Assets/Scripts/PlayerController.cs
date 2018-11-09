using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private CharacterController characterController;
    private Animator animator;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        var mouseHorizontal = Input.GetAxis("Mouse X")+ Input.GetAxis("HorizontalXboxRightStick"); 
        
        transform.Rotate(Vector3.up  * mouseHorizontal * turnSpeed*Time.deltaTime);
        Vector3 moveVector = transform.forward * vertical + transform.right * horizontal;
        animator.SetFloat("Speed", moveVector.magnitude);
        characterController.SimpleMove(moveVector * speed );
        
    }
}
