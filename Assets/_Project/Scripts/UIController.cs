using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu, panelIn;
    [SerializeField] private Button buttonOpenMenu, buttonChangeCamera;
    public Image[] buttonImage;
    private SceneController sceneController;
    private ObjectPooler objectPooler;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        sceneController = FindObjectOfType<SceneController>();
        buttonOpenMenu.onClick.AddListener(() => ButtonOpenMenu());
        buttonChangeCamera.onClick.AddListener(() => ButtonChangeCamera());
        panelIn.gameObject.SetActive(false);
        objectPooler = ObjectPooler.Instance;

        for (int i = 0; i < buttonImage.Length; i++)
        {   
            buttonImage[i].gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonCloseMenu());
        }
    }

    public void ButtonCloseMenu()
    {
        panelMainMenu.gameObject.SetActive(false); 
        panelIn.gameObject.SetActive(true); 
        sceneController.readyToRotateCamera = true; 
        sceneController.GenerateObjectsInScene();
    }

    public void ButtonOpenMenu()
    {
        panelMainMenu.gameObject.SetActive(true);
        panelIn.gameObject.SetActive(false);
        sceneController.readyToRotateCamera = false;

        for (int i = 0; i < sceneController.parentObjects.transform.childCount; i++)
        {
            sceneController.parentObjects.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ButtonChangeCamera()
    {
        if(sceneController.readyToRotateCamera)
        {
            sceneController.readyToRotateCamera = false;
            Camera.main.GetComponent<NewCamerRot>().enabled = false;
            Camera.main.GetComponent<SimpleCameraController>().enabled = true;
        }

        else
        {
            sceneController.readyToRotateCamera = true;
            Camera.main.GetComponent<NewCamerRot>().enabled = true;
            Camera.main.GetComponent<SimpleCameraController>().enabled = false;
        }
    }
}
