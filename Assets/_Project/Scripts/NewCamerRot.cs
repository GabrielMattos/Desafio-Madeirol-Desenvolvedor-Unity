using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamerRot : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    private Vector3 previousPosition;
    private SceneController sceneController;

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {   
        CameraRotation();
        MouseWhellZoom();
    }

    private void CameraRotation()
    {
        if(sceneController.readyToRotateCamera)
        {
            if(Input.GetMouseButtonDown(0))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }

            if(Input.GetMouseButton(0))
            {
                Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);
                cam.transform.position = target.position;

                cam.transform.Rotate(new Vector3(1f, 0f, 0f), direction.y * 180f);
                cam.transform.Rotate(new Vector3(0f, 1f, 0f), -direction.x * 180f, Space.World);
                cam.transform.Translate(0f, 0f, -10f);
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
        }
    }

    private void MouseWhellZoom()
    {
        if(sceneController.readyToScroll)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (this.gameObject.GetComponent<Camera>().fieldOfView > 1)
                {
                    this.gameObject.GetComponent<Camera>().fieldOfView--;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (this.gameObject.GetComponent<Camera>().fieldOfView < 100)
                {
                    this.gameObject.GetComponent<Camera>().fieldOfView++;
                }
            }
        }
    }

    private void Initialize()
    {
        sceneController = FindObjectOfType<SceneController>();
    }
}
