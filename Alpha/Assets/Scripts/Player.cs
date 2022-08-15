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

    public void DrawCard(){
        if (MyDeck.cardList.Count > 0 && GameManager.state == BattleState.PLAYERTURN){
            GameObject thisCard = Instantiate(cardPrefab, this.transform);
            string randCard = MyDeck.cardList[UnityEngine.Random.Range(0, MyDeck.cardList.Count)];
            
            ScriptHandler Handler = thisCard.GetComponent<ScriptHandler>();
            Handler.ScriptConstructor(randCard);
            MyDeck.cardList.Remove(randCard);
            // onHand += 1;
            onDeckChange?.Invoke();
        }
    }
}
