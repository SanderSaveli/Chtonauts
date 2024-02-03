using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AnimatedBar : MonoBehaviour
{
    public int maxBarValue;
    public float currentBarValue { get; }
    protected float _currentBarValue;

    public Image bar;
    public Image substrateBar;
    public TMP_Text text;
    public float lerpSpeed;

    public void ChangeBarValue(float value)
    {
        if (value < 0)
        {
            DecreaseBar(value);
        }
        else
        {
            IncreaseBar(value);
        }
        _currentBarValue += value;
        bar.fillAmount = _currentBarValue / maxBarValue;
        text.text = _currentBarValue.ToString();
    }

    private void LateUpdate()
    {
        substrateBar.fillAmount = Mathf.Lerp(substrateBar.fillAmount, bar.fillAmount, Time.deltaTime * lerpSpeed);
    }

    protected void DecreaseBar(float value)
    {
        //for animation
    }

    protected void IncreaseBar(float value)
    {
        //for animation
    }
}
