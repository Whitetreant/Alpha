using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //Contain Player action
    //onclick send data to play card
    public GameObject cardPrefab;
    public int maxMana;
    public int currentMana;
    public int maxHp;
    public int currentHp;

    public void drawCard(){
        if (GameManager.cardList.Count > 0){
            GameObject thisCard = Instantiate(cardPrefab, this.transform);
            ThisCard spawn = thisCard.GetComponent<ThisCard>();
            int randCard = GameManager.cardList[Random.Range(0, GameManager.cardList.Count)];
            spawn.isDraw(randCard);
            GameManager.cardList.Remove(randCard);
            // onHand += 1;
            return;
        }
    }
}
