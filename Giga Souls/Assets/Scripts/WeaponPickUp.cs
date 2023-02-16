using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ken
{
    public class WeaponPickUp : Interactable
    {
        public WeaponItem weapon;
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            // podnieś przedmiot i dodaj go to ekwipunku gracza
            PickUpItem(playerManager);
        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerInventory playerInventory;
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;

            playerInventory = playerManager.GetComponent<PlayerInventory>();
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();


            playerLocomotion.rigidbody.velocity = Vector3.zero; // powstrzymuje gracza przed ruszaniem sie, kiedy podnosi przedmiot
            animatorHandler.PlayTargetAnimation("Pick Up Item", true); //odpala sie animacja podnoszenia przedmiotu
            playerInventory.weaponsInventory.Add(weapon);
            Destroy(gameObject);

        }
    }
}