using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // MOVE VARIABLES
    [SerializeField]private float move_Speed = 1;
    private Vector2 move_Vector;
    private CharacterController characterController;

    // LOOKAT VARIABLES 
    [SerializeField] private float look_Sensitivity = 5f;
    private Vector2 look_Vector;
    private Vector3 look_rotation;

    // JUMP VARIABLES
    [SerializeField] private float jump_Height =10f;
    private float jump_gravity = 9.81f;
    private float jump_verticalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }
    //////////////////////////////////
    // INPUT SYSTEM FUNCTIONS START //
    //////////////////////////////////
    public void OnMove(InputAction.CallbackContext context)
    {   
        move_Vector = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look_Vector= context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(characterController.isGrounded && context.performed)
        {
            Jump();
        }
    }
    ////////////////////////////////
    // INPUT SYSTEM FUNCTIONS END //
    ////////////////////////////////
    private void Move()
    {
        jump_verticalVelocity -= jump_gravity * Time.deltaTime;

        if(characterController.isGrounded && jump_verticalVelocity < 0)
        {
            jump_verticalVelocity = -0.1f*jump_gravity*Time.deltaTime;
        }
        Vector3 move = transform.right * move_Vector.x + transform.forward*move_Vector.y + transform.up*jump_verticalVelocity;
        characterController.Move(move*move_Speed*Time.deltaTime);
    }
    private void Rotate()
    {
        look_rotation.y += look_Vector.x* look_Sensitivity * Time.deltaTime;
        transform.localEulerAngles = look_rotation;
    }
    private void Jump()
    {
        jump_verticalVelocity = Mathf.Sqrt(jump_Height * jump_gravity);
    }
}
