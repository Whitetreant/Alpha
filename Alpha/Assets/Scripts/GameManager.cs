using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    public static List<int> cardList = new List<int>();

    public GameObject fieldPos;
    public BattleState state;

    public GameObject[] playerPrefab;
    public GameObject[] enemyPrefab;
    public GameObject deckPrefab;
    public Text currentCard;
    
    void Start(){
        state = BattleState.PLAYERTURN;
        setupGame();
        addCardtoPlayerStartDeck();
        currentCard = deckPrefab.GetComponentInChildren(typeof(Text)) as Text;
    }

    void Update(){
        currentCard.text = cardList.Count.ToString();
    }
    
    public void endTurn(){
        if (state != BattleState.ENEMYTURN){
            state = BattleState.ENEMYTURN;
            print("Turn End");
        }
    }

    public void setupGame(){
        Instantiate(playerPrefab[0], fieldPos.transform.GetChild(Random.Range(0, 9)).gameObject.transform);

        print("Finish setup");
    }

    public void playerTurn(){
        
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
}
