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
    
    void Start(){
        state = BattleState.PLAYERTURN;
        setupGame();
    }
    
    public void endTurn(){
        if (state != BattleState.ENEMYTURN){
            state = BattleState.ENEMYTURN;
            GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in allEnemy){
                Enemy setFlag = enemy.GetComponent<Enemy>();
                setFlag.isEnemyTurn = true;
                setFlag.EnemyAction();
            }
            print("Turn End");
        }
    }

    public void setupGame(){
        //Fix spawn character in same spot
        Instantiate(playerPrefab[0], fieldPos.transform.GetChild(Random.Range(0, 9)).gameObject.transform);
        Instantiate(enemyPrefab[0], enemyPos[Random.Range(0, 3)].transform.gameObject.transform);
        print("Finish setup");
    }

    public void playerTurn(){
        
    }
}
