using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0.02f)] private float _delay = 0.02f;

    private WaitForSeconds _waitForNext;

    private int _iterationCount = 0;
    private Coroutine _iterationCoroutine;

    public event Action<int> Changed;

    private void Start()
    {
        _waitForNext = new(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_iterationCoroutine != null)
        {
            StopCoroutine(_iterationCoroutine);
            _iterationCoroutine = null;
        }
        else
        {
            _iterationCoroutine = StartCoroutine(IncreaseCount());
        }
    }

    private IEnumerator IncreaseCount()
    {
        while (enabled)
        {
            yield return _waitForNext;

            _iterationCount++;
            Changed?.Invoke(_iterationCount);
        }
    }
}