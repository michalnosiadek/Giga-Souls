using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ken
{
    public class EquipmentWindowUI : MonoBehaviour
    {
        public bool RightHandSlot1Selected;
        public bool RightHandSlot2Selected;
        public bool LeftHandSlot1Selected;
        public bool LeftHandSlot2Selected;

        HandEquipmentSlotUI[] handEquipmentSlotUI;

        private void Start()
        {
            handEquipmentSlotUI = GetComponentsInChildren<HandEquipmentSlotUI>();
        }

        public void LoadWeaponsOnEquipmentScreen(PlayerInventory playerInventory)
        {
            for (int i = 0; i < handEquipmentSlotUI.Length; i++)
            {
                if (handEquipmentSlotUI[i].rightHandSlot1)
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponInRightHandSlots[0]);
                }
                else if (handEquipmentSlotUI[i].rightHandSlot2)
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponInRightHandSlots[1]);
                }
                else if (handEquipmentSlotUI[i].leftHandSlot1)
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponInLeftHandSlots[0]);
                }
                else
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponInLeftHandSlots[1]);              
                }
            }
        }

        public void SelectRightHandSlot1()
        {
            RightHandSlot1Selected = true;
        }

        public void SelectRightHandSlot2() 
        {
            RightHandSlot2Selected = true;
        }

        public void SelectLeftHandSlot1()
        {
            LeftHandSlot1Selected = true;
        }

        public void SelectLeftHandSlot2()
        {
            LeftHandSlot2Selected = true;
        }
    }
}