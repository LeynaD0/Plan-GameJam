using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSelected : MonoBehaviour
{
    public bool firstButton = false;
    public Color _defColor, _selectedColor;

    private void OnEnable()
    {
        if (firstButton)
        {
            OnSelected();
        }
    }
    public void OnSelected()
    {
        LeanTween.scale(gameObject, Vector3.one * 1.25f, 0.0f);
        LeanTween.scale(gameObject, Vector3.one, 0.6f).setEaseInOutQuint().setLoopPingPong();
    }

    // Update is called once per frame
    public void OnDiselect()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one, 0.0f);
    }
    public void ChangeColorSelected(TextMeshProUGUI text)
    {
        text.color = _selectedColor;
    }
    public void ChangeColorDiselected(TextMeshProUGUI text)
    {
        text.color = _defColor;
    }
    public void OnDisable()
    {
        OnDiselect();
    }
}
