using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Transform m_cubeTF;
    [SerializeField] private int m_health;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private Animation m_animation;

    private void Start()
    {
        m_audioSource.pitch = Random.Range(.9f, 1.25f);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            TakeDamage(1000, false);
        }

        if (_collider.CompareTag("Destroyer"))
        {
            PlayDeathAnimation();
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
            PlayerScore.I.AddScore(100);
        }
        m_cubeTF.parent = null;
        m_cubeTF.gameObject.SetActive(true);
        PlayDeathAnimation();
    }

    private void PlayDeathAnimation()
    {
        m_animation.Play("CubeShrink");
        Invoke(nameof(DestroyCube),2);
    }

    private void DestroyCube()
    {
        Destroy(gameObject);
    }

}
