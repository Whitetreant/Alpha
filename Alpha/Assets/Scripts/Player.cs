using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Player : MonoBehaviour
{
    //Contain Player action
    //onclick send data to play card
    public static event Action onDeckChange;
    public GameObject cardPrefab;
    public int maxMana;
    public int currentMana;
    public int maxHp;
    public int currentHp;

    public void drawCard(){
        if (DeckManager.cardList.Count > 0){
            GameObject thisCard = Instantiate(cardPrefab, this.transform);
            ThisCard spawn = thisCard.GetComponent<ThisCard>();
            int randCard = DeckManager.cardList[UnityEngine.Random.Range(0, DeckManager.cardList.Count)];
            spawn.isDraw(randCard);
            DeckManager.cardList.Remove(randCard);
            onDeckChange?.Invoke();
            // onHand += 1;
            
        }
    }
}
