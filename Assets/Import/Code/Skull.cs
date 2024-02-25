using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skull : MonoBehaviour
{

    public Image image;

    public Sprite sprite;
    public Sprite sprite2;
    public Sprite sprite3;

    public int Gems = 0;

    public static Skull instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Skull dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (Gems == 1)
        {
            image.sprite = sprite;
        }
        else if (Gems == 2)
        {
            image.sprite = sprite2;
        }
        else if (Gems == 3)
        {
            image.sprite = sprite3;
        }
    }

}