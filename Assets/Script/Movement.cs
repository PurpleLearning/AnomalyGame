using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction detectionAction;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private string anomalyTag = "Correct";
    [SerializeField] private string normalTag = "Normal";
    
    private bool isNearAnomaly = false;
    private bool isNearNormal = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        detectionAction = playerInput.actions.FindAction("Detection");
        
        moveAction.Enable();
        detectionAction.Enable();
    }

    void Update()
    {
        MovingPlayer();

        if (detectionAction.WasPressedThisFrame())
        {
            CheckForAnomaly();
        }
    }

    void MovingPlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>(); 
        transform.position += new Vector3(direction.x, 0, direction.y) * movementSpeed * Time.deltaTime;
    }

    void CheckForAnomaly()
    {
        if (isNearAnomaly)
        {
            Debug.Log("Anomaly found");
        }
        else if (isNearNormal)
        {
            Debug.Log("No Anomaly");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(anomalyTag))
        {
            isNearAnomaly = true;
            Debug.Log("Cam guess");
        }
        else if (other.CompareTag(normalTag))
        {
            isNearNormal = true;
            Debug.Log("Cam guess");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(anomalyTag))
        {
            isNearAnomaly = false;
            Debug.Log("Can't Guess");
        }
        else if (other.CompareTag(normalTag))
        {
            isNearNormal = false;
            Debug.Log("Can't Guess");
        }
    }
}