using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            playerManager.itemInteractableGameObject.GetComponentInChildren<Text>().text = weapon.itemName;
            playerManager.itemInteractableGameObject.GetComponentInChildren<RawImage>().texture = weapon.itemIcon.texture;
            playerManager.itemInteractableGameObject.SetActive(true);
            Destroy(gameObject);

        }
    }
}