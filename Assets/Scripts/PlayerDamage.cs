using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageNumb = 1;
    void OnTriggerEnter2D(Collider2D other) 
    {
        ClawController cController = other.GetComponent<ClawController>();
        if(cController != null)
        {
            cController.updateHealth(damageNumb * -1);
        }
    }
}
