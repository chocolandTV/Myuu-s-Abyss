using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;
    private void OnTriggerEnter(Collider other) {
        
        Debug.Log(" JUMPING");
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterController>().Move(Vector3.up * bounce);
        }
    }
}
