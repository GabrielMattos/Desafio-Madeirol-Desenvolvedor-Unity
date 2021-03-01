using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebData : MonoBehaviour
{   
    [Serializable]
    public struct ImagesData
    {
        public int fotoId;
        public string nomeArquivoFoto;
        public string nomeArquivoFotoThumb;
    }

    [SerializeField] private ImagesData[] allData;

    [SerializeField] private Image testeImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetImages());
    }

    private IEnumerator GetImages()
    {
        string url = "http://35.194.86.108:621/api/Foto/ListarFotoPublicaTag?Tag=quarto%20casal";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.chunkedTransfer = false;
        yield return request.SendWebRequest();

        if(request.isNetworkError)
        {
            //erro
        }

        else
        {
            if(request.isDone)
            {
                allData = JsonHelper.GetArray<ImagesData>(request.downloadHandler.text);
                StartCoroutine(GetThumbs());
            }
        }
    }

    private IEnumerator GetThumbs()
    {
        WWW w = new WWW(allData[0].nomeArquivoFotoThumb);
        yield return w;

        if(w.error != null)
        {

        }

        else
        {
            if(w.isDone)
            {
                Texture2D tx = w.texture;
                testeImage.sprite = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), Vector2.zero, 10f);
            }
        }

        // for (int i = 0; i < allData.Length; i++)
        // {
        //     WWW w = new WWW(allData[i].nomeArquivoFotoThumb);
        //     yield return w;

        //     if(w.error != null)
        //     {

        //     }

        //     else
        //     {
        //         if(w.isDone)
        //         {
        //             Texture2D tx = w.texture;
        //             testeImage.sprite = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), Vector2.zero, 10f);
        //         }
        //     }
        // }
    }
}
