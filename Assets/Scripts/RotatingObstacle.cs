using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{

    [Header("Rotating")]
    [SerializeField]
    Transform rotationCentre;
    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f;
    float posX, posY, angle = 0;

     
    

    // Update is called once per frame
    void Update()
    {
        posX = rotationCentre.position.x + Mathf.Cos(angle) * rotationRadius;// \ was *
        posY = rotationCentre.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0;
        }

    }
}
