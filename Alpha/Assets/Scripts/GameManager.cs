using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{

    public GameObject fieldPos;
    public BattleState state;

    public GameObject[] playerPrefab;
    public GameObject[] enemyPrefab;
    
    void Start(){
        state = BattleState.PLAYERTURN;
        setupGame();
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
}
