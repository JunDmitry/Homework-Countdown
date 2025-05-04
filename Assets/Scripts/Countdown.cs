using System;
using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField, Min(0.02f)] private float _delay = 0.02f;

    private WaitForSeconds _waitForNext;
    private WaitUntil _waitMouseClick;

    private int _iterationCount = 0;
    private bool _isClickedMouse = false;

    public event Action<int> Changed;

    private void Start()
    {
        _waitForNext = new(_delay);
        _waitMouseClick = new(() => _isClickedMouse);
        StartCoroutine(IterateCount());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isClickedMouse = _isClickedMouse == false;
    }

    private IEnumerator IterateCount()
    {
        while (enabled)
        {
            yield return _waitMouseClick;
            yield return _waitForNext;

            _iterationCount++;
            Changed?.Invoke(_iterationCount);
        }
    }
}