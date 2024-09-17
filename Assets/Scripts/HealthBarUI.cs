using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour, IFillUI
{
    [SerializeField] private Image _fillImage;


    public void SetFillAmount(float value)
    {
        _fillImage.fillAmount = value;
    }
}