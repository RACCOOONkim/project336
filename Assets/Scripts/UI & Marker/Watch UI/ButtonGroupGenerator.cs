using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonGroupGenerator : MonoBehaviour
{
    [SerializeField] private Transform buttonGroup;
    [SerializeField, Range(0f, 0.5f)] private float intervalTime;
    [SerializeField, Range(0f, 0.5f)] private float floatingTime;
    [SerializeField, Range(0f, 0.5f)] private float floatingDistance;
    [SerializeField] private Ease ease;
    
    private Transform[] _buttons;
    private Image[] _images;
    private Vector3[] _defaultLocalPositions;

    private void Awake()
    {
        _buttons = new Transform[3];
        _images = new Image[3];
        _defaultLocalPositions = new Vector3[3];
        
        for (int i = buttonGroup.childCount - 1; i >= 0; i--)
        {
            _buttons[i] = buttonGroup.GetChild(i);
            _images[i] = buttonGroup.GetChild(i).GetComponent<Image>();
            _defaultLocalPositions[i] = buttonGroup.GetChild(i).localPosition;
        }
    }

    private void Initiate()
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.SetActive(false);
            _buttons[i].DOKill();
            _images[i].DOFade(0f, 0f);
            _images[i].DOKill();
        }
    }

    public IEnumerator GenerateButtons()
    {
        var waitForSeconds = new WaitForSeconds(intervalTime);
        Initiate();
        
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.SetActive(true);
            _buttons[i].localPosition = _defaultLocalPositions[i] - new Vector3(0f, floatingDistance, 0f);
            _buttons[i].DOLocalMoveY(_defaultLocalPositions[i].y, floatingTime).SetEase(ease);
            _images[i].DOFade(1f, floatingTime).SetEase(ease);
            yield return waitForSeconds;
        }
    }
}
