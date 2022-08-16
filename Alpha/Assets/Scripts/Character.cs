using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Character : MonoBehaviour, IPointerDownHandler
{
   public CharacterScriptable thisCharacter;
   public static event Action<Character> isTarget;
   public bool activePlayer;
   public int currentMaxHP;
	public int currentHP;
   public int currentShield;
   public int power;
   public int maxMP;
   public int currentMP;
   public Text showCurrentHP;
   public Text showCurrentShield;
   public Text showCurrentMP;

   private void Awake(){
      Initialize();
      RefreshStatus();
      // showCurrentMP = GameObject.FindGameObjectWithTag("CurrentMana").GetComponent<Text>();
      
      
   }
   public void Initialize(int amountShield=0){
      activePlayer = true;
      currentMaxHP = thisCharacter.characterMaxHP;
      currentHP = thisCharacter.characterMaxHP;
      currentShield = amountShield;
      maxMP = thisCharacter.characterMaxMP;
      currentMP = thisCharacter.characterMaxMP;
      showCurrentMP = GameObject.FindGameObjectWithTag("CurrentMana").GetComponent<Text>();
   }

   public void TakeDamage(int amount){
      if (amount > currentShield){
         amount -= currentShield;
         currentHP -= amount;
      }
      else if (amount <= currentShield){
         currentShield -= amount;
      }
      RefreshStatus();
   }

   public void GetShield(int amount){
      currentShield += amount;
      RefreshStatus();
   }

   public void RefillMana(){
      currentMP = maxMP;
      RefreshStatus();
   }

   public void ResetShield(){
      currentShield = 0;
      RefreshStatus();
   }

   public void PlayCard(int amount){
      currentMP -= amount;
      RefreshStatus();
   }
   
   private void RefreshStatus(){
      showCurrentHP.text = currentHP.ToString();
      showCurrentShield.text = currentShield.ToString();
      showCurrentMP.text = currentMP.ToString();
   }

   public void OnPointerDown(PointerEventData eventData){
        // Debug.Log("Click: " + eventData.pointerPressRaycast.gameObject.transform.name);
        isTarget?.Invoke(this);
    }

}