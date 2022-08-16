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
    public List<GameObject> currentCharacter;

    public Player PlayerHand;
    public DeckManager MyDeck;
    void Start(){
        state = BattleState.PLAYERTURN;
        setupGame();
        PlayerStartTurn();
    }

    public void PlayerStartTurn(){
        for(int i = 0; i <4; i++){
            PlayerHand.DrawCard();
        }
        foreach(GameObject character in currentCharacter){
            character.GetComponent<Character>().RefillMana();
            character.GetComponent<Character>().ResetShield();
        }
    }
    
    public void PlayerEndTurn(){
        if (state == BattleState.PLAYERTURN){
            ThisCard[] CardinHand;
            CardinHand = PlayerHand.gameObject.GetComponentsInChildren<ThisCard>();
            foreach(ThisCard Carded in CardinHand){
                Debug.LogWarning(Carded.name);
                Carded.Discard();
            }
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
        currentCharacter.Add(Instantiate(playerPrefab[0], fieldPos.transform.GetChild(Random.Range(0, 9)).gameObject.transform));
        for (int i = 1; i < 3; i++){
            SpawnEnemy();
        }
        MyDeck.addCardtoPlayerStartDeck();
        print("Finish setup");
    }

    public void SpawnEnemy(){
        Instantiate(enemyPrefab[0], enemyPos[Random.Range(0, 3)].transform.gameObject.transform);
    }
}
