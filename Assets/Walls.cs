using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private Transform m_playerTF;

    private void Update()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        transform.position = m_playerTF.position;
    }
}
