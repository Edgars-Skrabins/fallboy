using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int m_bulletDamage = 1;
    [SerializeField] private LayerMask m_collisionLayers;
    [SerializeField] private Transform m_firePoint;
    [SerializeField] private float m_lineDuration = 0.1f;
    private Animator m_anim;
    private LineRenderer m_line;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_line = gameObject.AddComponent<LineRenderer>();
        m_line.positionCount = 2;
        m_line.startWidth = 0.05f;
        m_line.endWidth = 0.05f;
        m_line.enabled = false;
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
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        m_anim.SetTrigger("Shoot");
        if ( Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_collisionLayers))
        {
            GameController.Instance.CameraShake();
            hit.collider.GetComponent<Cube>().TakeDamage(m_bulletDamage,false);
            StartCoroutine(ShowLineCo(m_firePoint.position, hit.point));
            Debug.Log(hit.collider);
        }
        else
        {
            StartCoroutine(ShowLineCo(m_firePoint.position, m_firePoint.position + m_firePoint.forward * 1000f));
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Finish"))
        {
            GameController.Instance.CameraShake();
            GameController.Instance.GameOver();
        }
    }

    private IEnumerator ShowLineCo(Vector3 start, Vector3 end)
    {
        m_line.SetPosition(0, start);
        m_line.SetPosition(1, end);
        m_line.enabled = true;

        yield return new WaitForSeconds(m_lineDuration);

        m_line.enabled = false;
    }
}
