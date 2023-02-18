using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class AutoAnchors : MonoBehaviour
{
    private RectTransform rectTransform = null;
    private Bounds parentBounds;
    private Vector2 parentSize = Vector2.zero;
    private Vector2 positionMin = Vector2.zero;
    private Vector2 positionMax = Vector2.zero;
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void SetAnchors()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        parentBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(transform.parent);
        parentSize = new Vector2(parentBounds.size.x, parentBounds.size.y);

        var anchorMin = rectTransform.anchorMin;
        positionMin = new Vector2(parentSize.x * anchorMin.x, parentSize.y * anchorMin.y);
        var anchorMax = rectTransform.anchorMax;
        positionMax = new Vector2(parentSize.x * anchorMax.x, parentSize.y * anchorMax.y);

        positionMin = positionMin + rectTransform.offsetMin;
        positionMax = positionMax + rectTransform.offsetMax;

        positionMin = new Vector2(positionMin.x / parentBounds.size.x, positionMin.y / parentBounds.size.y);
        positionMax = new Vector2(positionMax.x / parentBounds.size.x, positionMax.y / parentBounds.size.y);

        rectTransform.anchorMin = positionMin;
        rectTransform.anchorMax = positionMax;

        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}
