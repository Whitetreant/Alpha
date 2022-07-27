using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeckManager : MonoBehaviour
{
    public static List<int> cardList = new List<int>();

    public Text currentCardInDeck;

    private void OnEnable(){
        Player.onDeckChange += refreshCurrentCardInDeck;
    }
    void Start()
    {
        addCardtoPlayerStartDeck();
        refreshCurrentCardInDeck();
    }

    public void addCardtoPlayerStartDeck(){
        cardList.Add(3);
        cardList.Add(0);
        cardList.Add(0);
        cardList.Add(0);
        cardList.Add(1);
        cardList.Add(1);
        cardList.Add(1);
        cardList.Add(2);

    }

    public void refreshCurrentCardInDeck(){
        currentCardInDeck.text = cardList.Count.ToString();
    }

    private void OnDisable(){
        Player.onDeckChange -= refreshCurrentCardInDeck;
    }
}
