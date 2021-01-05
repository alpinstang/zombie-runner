﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        print("attacking...");
        if (target == null) { return;  }
        Debug.Log("Smack!");
        target.GetComponent<PlayerHealth>().DecreaseHealth(20);
    }
}
