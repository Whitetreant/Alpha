using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
   public CharacterScriptable thisCharacter;
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
      currentHP -= amount;
      RefreshStatus();
      Debug.LogWarning("Player take damage");
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
}