using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int m_bulletDamage;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private LayerMask m_collisionLayers;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if( Physics.Raycast(m_firePoint.position, m_firePoint.forward,out RaycastHit hit, m_collisionLayers))
        {
            hit.collider.GetComponent<Cube>().TakeDamage(m_bulletDamage,false);
            Debug.Log(hit.collider);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(m_firePoint.position, m_firePoint.forward);
    }
}
