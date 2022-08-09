using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float movementMultiplier = 50f;
    [SerializeField] float movementClamp = 10f;

    void Start()
    {
        
    }

    void OnEnable() {
        movement.Enable();
    }
    void OnDisable() {
        movement.Disable();
    }


    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;
        
        float xOffset = xThrow * movementMultiplier * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos,-movementClamp,movementClamp);

        float yOffset = yThrow * movementMultiplier * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;


        transform.localPosition = new Vector3(
            clampedXPos,
            newYPos,
            transform.localPosition.z);
    }
}
