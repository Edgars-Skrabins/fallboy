using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int m_bulletDamage = 1;
    [SerializeField] private LayerMask m_collisionLayers;
    [SerializeField] private Transform m_firePoint;

    [SerializeField] private AudioClip m_shotAudioClip;

    private AudioSource m_audioSource;
    private Animator m_anim;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (!GameController.Instance.m_gameStarted || GameController.Instance.m_gamePaused) return;

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
            hit.collider.GetComponent<Cube>().TakeDamage(m_bulletDamage,true);
        }
        PlayShotFiredSFX();
    }

    private void PlayShotFiredSFX()
    {
        m_audioSource.pitch = Random.Range(.9f, 1.25f);
        m_audioSource.PlayOneShot(m_shotAudioClip);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Finish"))
        {
            GameController.Instance.CameraShake();
            GameController.Instance.GameOver();
        }
    }

}
