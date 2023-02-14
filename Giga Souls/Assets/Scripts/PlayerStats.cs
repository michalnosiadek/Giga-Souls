using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ken
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public int maxStamina;
        public int currentStamina;

        public HealthBar healthbar;
        public StaminaBar staminaBar;
        AnimatorHandler animatorHandler;

        private void Awake()
        {
            staminaBar = FindObjectOfType<StaminaBar>
            animatorHandler = GetComponentInChildren<AnimatorHandler>();    
        }

        private void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            healthbar.SetCurrentHealth(currentHealth);

            maxStamina = SetMaxStaminaFromStaminahLevel();
            currentStamina = maxStamina;    
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminahLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }


        public void TakeDamage(int damage) //dmg metoda na dmg
        {
            currentHealth = currentHealth - damage;

            healthbar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead", true);
                //ded
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            // Set bar
        }
    }
}