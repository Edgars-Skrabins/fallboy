using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    [SerializeField] private int m_health;

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            TakeDamage(1000, false);
        }
    }

    public void TakeDamage(int _damage, bool _addScore)
    {
        m_health -= _damage;
        if (m_health <= 0)
        {
            Die(_addScore);
        }
    }

    private void Die(bool _addScore)
    {
        if (_addScore)
        {
            // Add score
        }

        Destroy(gameObject);
    }

}
