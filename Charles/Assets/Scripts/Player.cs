using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Movement Variables")]
    [SerializeField] private Vector3 lastPosition;      // Stores last touch position
    [SerializeField] private Vector3 deltaMovement;     // Stores delta quantity between first and last touch positions

	void Update () {
        LookToFinger();
        Move();
	}

    void Move()
    {
        // Get first click position
        if (Input.GetMouseButtonDown(0))
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            // Get current position when button pressed
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate distance or delta between current position and last position
            deltaMovement = currentPosition - lastPosition;

            // Check touch position is different from the last one? If yes, make movement
            if (lastPosition != currentPosition)
            {
                // Final: Implement movement
                transform.position += (deltaMovement * 2);
            }

            // Store lastPosition so that I can check it again next frame for position changed or not?
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Clear deltaMovement when button up
            if (Input.GetMouseButtonUp(0))
                lastPosition = Vector3.zero;
        }
    }

    void LookToFinger()
    {
        // Get mouse position
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(targetPosition.y - transform.position.y, 
            targetPosition.x - transform.position.x);
        
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        
        // Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90); //Minus 90 for the offset
    }
}
