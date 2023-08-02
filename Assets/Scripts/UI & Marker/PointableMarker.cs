using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointableMarker : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Color normalColor, hoverColor, pressedColor;
    [SerializeField] private float time;
    public Action<bool> onToggle;
    public UnityEvent onSelect, onUnselect;
    
    private Material _material;
    private bool _isOn;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _material.DOColor(normalColor, time);
    }

    public void OnHoverEnter()
    {
        _material.DOColor(hoverColor, time);
    }

    public void OnHoverExit()
    {
        _material.DOColor(normalColor, time);
    }

    public void OnSelectEnter()
    {
        _isOn = !_isOn;
        onToggle?.Invoke(_isOn);
        onSelect?.Invoke();
        _material.DOColor(pressedColor, time);
    }

    public void OnSelectExit()
    {
        _material.DOColor(hoverColor, time);
    }
}
