using TMPro;
using UnityEngine;

public class CountdownView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Countdown _countdown;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
        _countdown.Changed += ChangeText;
    }

    private void OnDisable()
    {
        _countdown.Changed -= ChangeText;
    }

    private void ChangeText(int iterationCount)
    {
        _text.text = iterationCount.ToString("");
    }
}