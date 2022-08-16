using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{
    //Contain Player action
    //onclick send data to play card
    public static event Action onDeckChange;
    public GameObject cardPrefab;
    public DeckManager MyDeck;
    public Graveyard MyGraveyard;

    public void DrawCard(){
        if (MyDeck.cardList.Count > 0 && GameManager.state == BattleState.PLAYERTURN){
            GameObject thisCard = Instantiate(cardPrefab, this.transform);
            string drawedCard = MyDeck.cardList[MyDeck.cardList.Count-1];
            
            ScriptHandler Handler = thisCard.GetComponent<ScriptHandler>();
            Handler.ScriptConstructor(drawedCard);

            MyDeck.cardList.RemoveAt(MyDeck.cardList.Count-1);
            // onHand += 1;
            onDeckChange?.Invoke();
        }
        else if(MyDeck.cardList.Count == 0 && GameManager.state == BattleState.PLAYERTURN){
            MyDeck.cardList = MyGraveyard.cardList;
            MyGraveyard.cardList = new List<string>();
            MyGraveyard.refreshCurrentCardInDeck();
            MyDeck.Shuffle();
            DrawCard();
        }
        else{
            Debug.LogError("this is bug from else");

        }
    }
}
