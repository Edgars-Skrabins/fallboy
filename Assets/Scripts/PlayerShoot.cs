using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int m_bulletDamage = 1;
    [SerializeField] private LayerMask m_collisionLayers;
    private Animator m_anim;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameController.Instance.gameStarted == false) return;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if ( Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity, m_collisionLayers))
        {
            hit.collider.GetComponent<Cube>().TakeDamage(m_bulletDamage,false);
            Debug.Log(hit.collider);
        }

        m_anim.SetTrigger("Shoot");
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Finish"))
        {
            GameController.Instance.GameOver();
        }
    }
}
