using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    Vector3 moveVector;
    [SerializeField] float moveSpeed = 20f;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        moveVector.z = 0;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
}
