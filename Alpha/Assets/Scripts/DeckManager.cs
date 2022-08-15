using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeckManager : MonoBehaviour
{
    public List<string> cardList = new List<string>();
    public List<string> listCardInDeck;
    public string container;
    public Text currentCardInDeck;

    private void OnEnable(){
        Player.onDeckChange += refreshCurrentCardInDeck;
    }
    void Start()
    {
        addCardtoPlayerStartDeck();
        refreshCurrentCardInDeck();
    }

    void Update(){
        listCardInDeck = cardList;
    }

    public void addCardtoPlayerStartDeck(){
        cardList.Add("Fury");
        cardList.Add("Smash");
        cardList.Add("Smash");
        cardList.Add("Smash");
        cardList.Add("Endure");
        cardList.Add("Endure");
        cardList.Add("Endure");
        cardList.Add("Slash");
        

    }

    public void Shuffle(){
        for(int i = 0; i < cardList.Count; i++){
            container = cardList[i];
            int randomIndex = Random.Range(i, cardList.Count);
            cardList[i] = cardList[randomIndex];
            cardList[randomIndex] = container;
        }
    }

    public void refreshCurrentCardInDeck(){
        currentCardInDeck.text = cardList.Count.ToString();
    }

    private void OnDisable(){
        Player.onDeckChange -= refreshCurrentCardInDeck;
    }
}
