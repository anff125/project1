using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManagerUI : MonoBehaviour
{
    [SerializeField] private List<CardSO> cardList;
    [SerializeField] private List<Transform> cardContainerList;


    private void Awake()
    {
        foreach (var cardContainer in cardContainerList)
        {
            var cardManagerSingleUI = cardContainer.GetComponent<CardManagerSingleUI>();
            cardManagerSingleUI.SetCardSO(cardList[Random.Range(0, cardList.Count)]);
            cardContainer.GetComponent<Button>().onClick.AddListener(() =>
            {
                UseCard(cardManagerSingleUI);
            });
        }
    }

    private void UseCard(CardManagerSingleUI cardManagerSingleUI)
    {
        if (cardManagerSingleUI.CurrentCardCost > (int)Player.Instance.GetCurrentMana())
        {
            Debug.Log("Not enough mana");
            return;
        }
        Player.Instance.UseMana(cardManagerSingleUI.CurrentCardCost);
        
        cardManagerSingleUI.UseCard();
        
        cardManagerSingleUI.SetCardSO(cardList[Random.Range(0, cardList.Count)]);
    }


}