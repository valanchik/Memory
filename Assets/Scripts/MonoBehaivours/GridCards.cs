using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GridCards:MonoBehaviour
{
    public GameObject prefabCard;
    private Sprite[] sprites;

    public void Start()
    {
        sprites = Resources.LoadAll<Sprite>($"1");
    }

    public void AddOneCard(int index, int value)
    {
        var go = Instantiate(prefabCard, transform);
        var card = go.GetComponent<Card>();
        card.Index = index;
        card.Value = value;
        var img = GetImageByValue(card.Value);
        card.Front.GetComponent<Image>().sprite = img;
    }

    private Sprite GetImageByValue(int value)
    {

        return sprites[value];
    }

    public void Clear()
    {
        var listCards = GameObject.FindGameObjectsWithTag("Card");
        foreach (var card in listCards)
        {
            Destroy(card);
        }
    }
}
