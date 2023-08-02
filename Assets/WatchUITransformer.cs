using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WatchUITransformer : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Transform wrist;
    [SerializeField] private float yOffset;

    [Space(10), Header("Reference")] 
    [SerializeField] private PointableMarker pointableMarker;
    [SerializeField] private ButtonGroupGenerator parentButtonUI;
    
    private Transform _player;
    private bool _isOn;
    private List<GameObject> _children;
    private Coroutine _coroutine;
    
    
    private void Start()
    {
        _player = PlayerManager.Instance.eyeTransform;
        _children = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _children.Add(transform.GetChild(i).gameObject);
        }

        pointableMarker.onToggle += ToggleState;
    }
    private void Update()
    {
        if(!_isOn) return;
        
        transform.LookAt(2 * transform.position - _player.position);
        transform.position = wrist.position + Vector3.up * yOffset;
    }

    public void ToggleState(bool isOn)
    {
        _isOn = isOn;
        foreach (var child in _children)
        {
            child.SetActive(_isOn);
        }
    }

    public void GenerateButtons()
    {
        if(_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(parentButtonUI.GenerateButtons());
    }
}
