using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ken
{
    public class Interactable : MonoBehaviour
    {
        public float radius = 0.6f;
        public string interactableText;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public virtual void Interact(PlayerManager playerManager)
        {
            //odapalane gdy gracz wchodzi w interakcje
            Debug.Log("Wszedles w interakcje z obiektem");
        }
    }
}