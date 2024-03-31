using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public static HealthScript instance { get; private set; }

    public Image mask;
    float originalsize;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        originalsize = mask.rectTransform.rect.width;
    }
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalsize * value);
    }
}
