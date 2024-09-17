using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Transform HealthBar;
    [SerializeField] private Transform ManaBar;

    private IFillUI _healthBarIFillUI;
    private IFillUI _manaBarIFillUI;

    private void Awake()
    {
        _healthBarIFillUI = HealthBar.GetComponent<IFillUI>();
        _manaBarIFillUI = ManaBar.GetComponent<IFillUI>();
        _healthBarIFillUI.SetFillAmount(1f);
        _manaBarIFillUI.SetFillAmount(0f);
    }

    public void SetHealth(float value)
    {
        _healthBarIFillUI.SetFillAmount(value / 10);
    }

    public void SetMana(float value)
    {
        _manaBarIFillUI.SetFillAmount(value / 10);
    }
}