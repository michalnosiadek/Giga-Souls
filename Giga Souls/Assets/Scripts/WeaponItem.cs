using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ken
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string Right_Hand_Idle;
        public string Left_Hand_Idle;

        [Header("One Handed Attack Animations")]
        // TODO: wyjebac underscore OhHeavyAttack
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Heavy_Attack_1;


    }
}