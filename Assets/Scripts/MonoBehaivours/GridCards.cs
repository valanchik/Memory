using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCards:MonoBehaviour
{
    public GameObject prefabCard;
    private Sprite[] sprites;
    private GridLayoutGroup gridLayoutGroup;
    private List<Card> cardsList = new List<Card>();


    public void Start()
    {
        sprites = Resources.LoadAll<Sprite>($"1");
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public void AddOneCard(int index, int value)
    {
        var go = Instantiate(prefabCard, transform);
        var card = go.GetComponent<Card>();
        card.Index = index;
        card.Value = value;
        var img = GetImageByValue(card.Value);
        card.Front.GetComponent<Image>().sprite = img;
        cardsList.Add(card);
    }

    public List<Card> GetCardList()
    {
        return cardsList;
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
        cardsList.Clear();
    }

    public void SetColumnCount(int count)
    {
        gridLayoutGroup.constraintCount = count;
        AutoGridSize();
    }

    public void AutoGridSize()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return;
        
        int colCount = gridLayoutGroup.constraintCount;
        int rowCount = Mathf.CeilToInt((float) childCount / colCount);
        
        var rect = GetComponent<RectTransform>().rect;
        
        float newWidth = rect.width - (gridLayoutGroup.spacing.x * (colCount - 1)) - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right;
        float newHeight = rect.width - (gridLayoutGroup.spacing.y * (rowCount - 1)) - gridLayoutGroup.padding.top - gridLayoutGroup.padding.bottom;
        Vector2 gridSize = new Vector2(newWidth, newHeight);
        Vector2 gridSizePerCell = new Vector2(gridSize.x / colCount, gridSize.y / rowCount);

        Vector2 child = transform.GetChild(0).GetComponent<Card>().GetImageSizePerPixel();
        float aspectRatio = child.y / child.x;
        Vector2 perCell = new Vector2(gridSizePerCell.x, gridSizePerCell.x * aspectRatio);
        
        gridLayoutGroup.cellSize = perCell;
    }

    public int MaxRowsInRect(Card fromCard, int maxCols)
    {
        if (gridLayoutGroup.transform.childCount == 0)
        {
            return 0;
        }
        
        var rect = GetComponent<RectTransform>().rect;
        
        var firstChild = fromCard.GetImageSizePerPixel();
        float firstChildAspectRatio = firstChild.y / firstChild.x;
        
        float gridWidth = rect.width - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right
                          - (gridLayoutGroup.spacing.x * (gridLayoutGroup.constraintCount - 1));
        
        float gridHeight = rect.height - gridLayoutGroup.padding.top - gridLayoutGroup.padding.bottom;
        float cellHeight = gridWidth / maxCols * firstChildAspectRatio;
        int maxRows = Mathf.FloorToInt(gridHeight / (cellHeight + gridLayoutGroup.spacing.y));

        return maxRows;
    }

    
}
