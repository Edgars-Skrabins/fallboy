using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform m_followTarget;

    void LateUpdate()
    {
        transform.position = m_followTarget.position;
    }
}
