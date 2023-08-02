using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    public Transform playerTransform;
    public Transform eyeTransform;

    private PathDrawer _pathDrawer;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        _pathDrawer = GetComponent<PathDrawer>();
    }

    public void StopDrawingPath()
    {
        _pathDrawer.StopDrawingPath();
    }

    public void StartDrawingPath()
    {
        _pathDrawer.StartDrawingPath();
    }

    public void SetNextSection(Transform pivot)
    {
        _pathDrawer.SetNextSection(pivot);
    }
}
