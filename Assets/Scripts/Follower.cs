using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform  m_followTarget;
    [SerializeField] private Vector3 m_offset;

    void LateUpdate()
    {
        transform.position = m_followTarget.position + m_offset;
    }
}
