using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu;
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

        for (int i = 0; i < buttonImage.Length; i++)
        {   
            buttonImage[i].gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonClosePanel());
        }
    }

    public void ButtonClosePanel()
    {
        panelMainMenu.gameObject.SetActive(false);   
        sceneController.GenerateObjectsInScene();
    }

    public void ButtonOpenPanel()
    {
        panelMainMenu.gameObject.SetActive(true);   
    }
}
