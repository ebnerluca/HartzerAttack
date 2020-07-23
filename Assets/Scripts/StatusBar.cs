using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider slider;
    public RectTransform statusBar;

    public RectTransform marker;

    //public float height = 20f;
    //public float width = 150f;

    private Vector2 baseOffsetMax;
    private Vector2 baseOffsetMin;

    /*private void Update()
    {
        statusBar.offsetMax = new Vector2(width, height/2);
        statusBar.offsetMin = new Vector2(0f, -height/2);
    }*/

    private void Awake()
    {
        baseOffsetMax = statusBar.offsetMax;
        baseOffsetMin = statusBar.offsetMin;

        if(gameObject.tag == "SpecialBar")
        {
            marker.gameObject.SetActive(true);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        statusBar.offsetMax = baseOffsetMax;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }

    public void SetMaxValue(float maxValue)
    {
        float scale = maxValue / slider.maxValue;
        float width = statusBar.offsetMax.x - statusBar.offsetMin.x;

        slider.maxValue = maxValue;
        statusBar.offsetMax = new Vector2(baseOffsetMin.x + width*scale, baseOffsetMax.y);
    }

    public void Initialize(float value, float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = value;
    }

    public void SetMarkerValue(float value)
    {
        float width = statusBar.offsetMax.x - statusBar.offsetMin.x;
        float maxValue = slider.maxValue;

        Vector3 temp = marker.localPosition;
        temp.x = (value / maxValue) * width - width/2f;

        marker.localPosition = temp;
    }
}
