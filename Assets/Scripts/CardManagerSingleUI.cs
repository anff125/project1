using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardManagerSingleUI : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI cardNameText;

    public int CurrentCardCost { get; private set; }
    private ICardUsage _cardUsage;
    private Transform _cardPrefab;
    public void SetCardSO(CardSO cardSO)
    {
        CurrentCardCost = cardSO.cost;
        cardImage.sprite = cardSO.sprite;
        cardNameText.text = cardSO.name;
        _cardPrefab = cardSO.prefab;
        _cardUsage = cardSO.prefab.GetComponent<ICardUsage>();
    }

    public void UseCard()
    {
        Instantiate(_cardPrefab, Player.Instance.transform.position + Vector3.up, Player.Instance.transform.rotation);
        _cardUsage.Use();
    }


}