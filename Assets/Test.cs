using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float a;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMoveY(a, 2f);
    }
}
