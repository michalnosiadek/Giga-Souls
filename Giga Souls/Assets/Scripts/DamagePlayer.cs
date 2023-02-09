using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ken
{
    public class DamagePlayer : MonoBehaviour
    {
        public int damage = 25;

        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();    
            
            //jesli gracz wchodzi w interakcje z obiektem to gracz dostaje dmg
            if(playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }

    }
}