using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCards:MonoBehaviour
{
    public GameObject prefabCard;

    public void AddOneCard()
    {
        Instantiate(prefabCard, transform);
    }
}
