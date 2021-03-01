using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu, panelIn;
    [SerializeField] private Button buttonOpenMenu;
    public Image[] buttonImage;
    private SceneController sceneController;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        sceneController = FindObjectOfType<SceneController>();
        buttonOpenMenu.onClick.AddListener(() => ButtonOpenMenu());
        panelIn.gameObject.SetActive(false);

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
    }
}
