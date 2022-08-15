using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{

    public GameObject fieldPos;
    public GameObject[] enemyPos;
    public static BattleState state;

    public GameObject[] playerPrefab;
    public GameObject[] enemyPrefab;

    public Player PlayerHand;
    void Start(){
        state = BattleState.PLAYERTURN;
        setupGame();
        PlayerStartTurn();
    }

    public void PlayerStartTurn(){
        // for(int i = 0; i <5; i++){
        //     PlayerHand.DrawCard();
        // }
    }
    
    public void PlayerEndTurn(){
        if (state == BattleState.PLAYERTURN){
            print("Turn End");
            state = BattleState.ENEMYTURN;
            EnemyStartTurn();
            
            
        }
    }

    public void EnemyStartTurn(){
        EnemyTurn();
    }

    public void EnemyTurn(){
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in allEnemy){
            Enemy setFlag = enemy.GetComponent<Enemy>();
            setFlag.isEnemyTurn = true;
            setFlag.EnemyAction();
        }
        EnemyEndTurn();
    }

    public void EnemyEndTurn(){
        state = BattleState.PLAYERTURN;
        PlayerStartTurn();
    }

    public void setupGame(){
        //Fix spawn character in same spot
        Instantiate(playerPrefab[0], fieldPos.transform.GetChild(Random.Range(0, 9)).gameObject.transform);
        for (int i = 1; i < 3; i++){
            SpawnEnemy();
        }
        print("Finish setup");
    }

    public void SpawnEnemy(){
        Instantiate(enemyPrefab[0], enemyPos[Random.Range(0, 3)].transform.gameObject.transform);
    }
    public void playerTurn(){
        
    }
}
