using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Ken
{
    public class HandEquipmentSlotUI : MonoBehaviour
    {
        public Image icon;
        WeaponItem weapon;

        public bool rightHandSlot1;
        public bool rightHandSlot2;
        public bool leftHandSlot1;
        public bool leftHandSlot2;

        public void AddItem (WeaponItem newWeapon)
        {
            weapon = newWeapon;
            icon.sprite = weapon.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearItem()
        {
            weapon = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }
    }
}