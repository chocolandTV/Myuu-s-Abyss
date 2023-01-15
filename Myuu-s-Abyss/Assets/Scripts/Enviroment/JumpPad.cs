using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;
    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log(" JUMPING");
            CharacterController c = other.gameObject.GetComponent<CharacterController>();
            c.SimpleMove(Vector3.up * bounce);
        }
    }
}
