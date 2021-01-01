using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRadiusGizmo : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        var chaseRadius = GetComponent<EnemyAI>().chaseRange;
        // Display the radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
