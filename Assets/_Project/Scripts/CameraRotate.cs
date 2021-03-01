using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform focusPoint;
    private Vector3 cameraOffset;
    [Range(0.01f, 1.0f)][SerializeField] private float smoothFactor = 0.5f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private bool lookAtPoint = false, rotateAroundPoint = true;


    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - focusPoint.position;
    }

    private void LateUpdate() 
    {
        if(rotateAroundPoint)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = camTurnAngle * cameraOffset;
        }   

        Vector3 newPosition = focusPoint.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if(lookAtPoint || rotateAroundPoint)
        {
            transform.LookAt(focusPoint);
        }
    }
}
