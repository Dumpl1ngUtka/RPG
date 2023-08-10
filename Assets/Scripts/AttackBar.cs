using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Color _defaultColor;

    public void FillAmount(float value)
    {
        _bar.fillAmount = value;
    }

    private void OnEnable()
    {
        _bar.color = _defaultColor;
    }
    public IEnumerator Finish(Color color)
    {
        var timer = 0f;
        var lerpSpeed = 5f;
        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            _bar.color = Color.Lerp(_bar.color, color, Time.deltaTime * lerpSpeed);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
