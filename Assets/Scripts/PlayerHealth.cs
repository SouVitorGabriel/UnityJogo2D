using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int valor = 1;
    void OnTriggerEnter2D(Collider2D other) 
    {
        ClawController cController = other.GetComponent<ClawController>();
        if(cController != null)
        {
            cController.updateHealth(valor);
            Debug.Log("UHUL CUREI " + valor);  
            Destroy(gameObject);      
        }
    }
}
