using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    public bool reverse;

    private void Start()
    {
        player = PlayerManager.Instance.eyeTransform;
    }

    private void Update()
    {
        if (reverse) transform.LookAt(player.position);
        else transform.LookAt(2 * transform.position - player.position);
    }
}
