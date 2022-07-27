using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Enemy : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public static event Action<Enemy> isTarget;
    public string enemyName;
    public int maxHP;
    public int currentHP;
    public Text showHP;
    public enum Pattern {Pattern1, Pattern2, Pattern3, Pattern4}

    public void setHP(int amount){
        maxHP = amount;
        currentHP = amount;
    }
    public void takeDamage(int amount){
        currentHP -= amount;
    }

    void Update(){
        showHP.text = currentHP.ToString() + "/" + maxHP.ToString();
    }

    public void OnPointerDown(PointerEventData eventData){
        print("Click: " + eventData.pointerPressRaycast.gameObject.transform.name);
        isTarget?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData){
        takeDamage(1);
    }
}
