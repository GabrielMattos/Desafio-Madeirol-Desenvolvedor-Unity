using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu;
    public Image[] buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonImage.Length; i++)
        {   
            buttonImage[i].gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonClosePanel());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClosePanel()
    {
        panelMainMenu.gameObject.SetActive(false);   
    }

    public void ButtonOpenPanel()
    {
        panelMainMenu.gameObject.SetActive(true);   
    }
}
