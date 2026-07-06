using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] private float movementSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlayer();
    }

    void MovingPlayer()
    {
       Vector2 direction = moveAction.ReadValue<Vector2>(); 
       transform.position += new Vector3(direction.x, 0, direction.y) * movementSpeed * Time.deltaTime;
    }
    
}