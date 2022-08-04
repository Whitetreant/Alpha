using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Enemy : MonoBehaviour, IPointerDownHandler
{
    public EnemyScriptable thisEnemy;
    public static event Action<Enemy> isTarget;
    public bool isEnemyTurn;
    public int maxHP;
    public int currentHP;
    public int currentShield;
    public Text showHP;
    public Text showShield;
    public Image showAction;
    public enum Pattern {Pattern1, Pattern2, Pattern3, Pattern4}
    public Pattern pattern;
    private void Awake(){
        Initialize();
        RefreshStatus();
    }

    public void EnemyAction(){
        if (GameManager.state == BattleState.ENEMYTURN && isEnemyTurn == true){
            DealDamage(3);
        }
    }
    
    public void Initialize(int amountShield=0){
        maxHP = thisEnemy.enemyMaxHP;
        currentHP = thisEnemy.enemyMaxHP;
        currentShield = amountShield;
    }

    public void DealDamage(int amount){
        GameObject[] allPlayer = GameObject.FindGameObjectsWithTag("Player");
        Character target = allPlayer[UnityEngine.Random.Range(0,allPlayer.Length)].GetComponent<Character>();
        target.TakeDamage(amount);
    }
    public void TakeDamage(int amount){
        currentHP -= amount;
        RefreshStatus();
    }

    public void RefreshStatus(){
        showHP.text = currentHP.ToString() + "/" + maxHP.ToString();
        showShield.text = currentShield.ToString();
    }


    public void OnPointerDown(PointerEventData eventData){
        // Debug.Log("Click: " + eventData.pointerPressRaycast.gameObject.transform.name);
        isTarget?.Invoke(this);
    }
}
