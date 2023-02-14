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
        public string RightHandIdle;
        public string LeftHandIdle;

        [Header("One Handed Attack Animations")]
        // TODO: wyjebac underscore OhHeavyAttack
        public string OhLightAttack;
        public string OhLightAttack1;
        public string OhHeavyAttack;

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;

    }
}