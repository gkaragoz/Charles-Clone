using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	void Update () {
        LookToFinger();
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
