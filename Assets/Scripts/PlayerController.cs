using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftPos;
    [SerializeField] float rightPos;
    [SerializeField] float upPos;
    [SerializeField] float downPos;


    InputAction moveAction;

    Vector3 moveVector;
    Vector2 minimumBound;
    Vector2 maximumBound;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        IniBound();
    }

    void IniBound()
    {
        Camera mainCamera = Camera.main;
        minimumBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maximumBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));

    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minimumBound.x + leftPos, maximumBound.x - rightPos);
        newPos.y = Mathf.Clamp(newPos.y, minimumBound.y + downPos, maximumBound.y - upPos);

        transform.position += moveVector * moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }
}
