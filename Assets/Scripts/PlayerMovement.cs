using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float bottomBoundPadding;
    [SerializeField] float topBoundPadding;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        InitBounds();
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
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomBoundPadding, maxBounds.y - topBoundPadding);
        transform.position = newPos;
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
