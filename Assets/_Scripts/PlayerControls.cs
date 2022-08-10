using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float movementMultiplier = 50f;
    [SerializeField] float movementXClamp = 10f;
    [SerializeField] float movementYClamp = 7f;
    [SerializeField] float positionPitchFactor = 2f;

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
        float clampedXPos = Mathf.Clamp(newXPos,-movementXClamp,movementXClamp);

        float yOffset = yThrow * movementMultiplier * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos,-movementYClamp,movementYClamp);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z);
    }
}
