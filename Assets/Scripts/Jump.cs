using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Jumping : MonoBehaviour
{
    
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float maxJumpHeight = 3f;
    [SerializeField] private float groundRadius = 0.3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private CharacterController characterController;
    private float _velocity;
    private Vector3 _moveDirection;
    private bool _isGrounded;
  
    private void Awake()
          {
          characterController = GetComponent<CharacterController>();
         }
          private void FixedUpdate()
         {
           _isGrounded = IsOnTheGround();

         if (_isGrounded && _velocity < 0)
             {
               _velocity = -2;
             }
        Move(_moveDirection);
        DoGravity();
         }

    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) 
        {
           Jump(); 
        }
      
        
    }
    private bool IsOnTheGround()
    {
        bool result = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        return result;
    }

    private void Move(Vector3 direction)
    {
      
    }
     private void Jump()
    {
       _velocity = Mathf.Sqrt(maxJumpHeight*-2*gravity);
    }
    private void DoGravity()
    {
        _velocity += gravity * Time.fixedDeltaTime;
        characterController.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
}
}
    

