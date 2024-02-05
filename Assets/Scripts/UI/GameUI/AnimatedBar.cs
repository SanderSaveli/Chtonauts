using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AnimatedBar : MonoBehaviour
{
    public int maxBarValue;
    public float currentBarValue { get; private set; } // Текущее значение шкалы
    protected float _currentBarValue; // Внутреннее значение шкалы, используемое для анимации

    public Image bar; // Ссылка на Image компонент, который будет использоваться для основной шкалы
    public Image substrateBar; // Ссылка на Image компонент, который будет использоваться для подложки шкалы
    public TMP_Text text; // Ссылка на TMP_Text компонент, который будет использоваться для отображения текста
    public float lerpSpeed; // Скорость интерполяции для анимации заполнения шкалы

    private void Start()
    {
        UpdateBarText(); // Обновляем текст шкалы
    }

    // Метод для обновления текста шкалы
    private void UpdateBarText()
    {
        text.text = currentBarValue.ToString("F0"); // Выводим текущее значение шкалы с округлением до целого числа
    }

    // Метод для изменения значения шкалы
    public void ChangeBarValue(float value)
    {
        if (value < 0) // Если значение отрицательное, уменьшаем шкалу
        {
            DecreaseBar(value);
        }
        else // Иначе, увеличиваем шкалу
        {
            IncreaseBar(value);
        }
        _currentBarValue += value; // Изменяем внутреннее значение шкалы
        currentBarValue = Mathf.Clamp(_currentBarValue, 0, maxBarValue); // Ограничиваем текущее значение между 0 и maxBarValue
        bar.fillAmount = currentBarValue / maxBarValue; // Обновляем заполнение основной шкалы
        UpdateBarText(); // Обновляем текст шкалы
    }

    // Метод, вызываемый в LateUpdate для плавного заполнения шкалы
    private void LateUpdate()
    {
        substrateBar.fillAmount = Mathf.Lerp(substrateBar.fillAmount, bar.fillAmount, Time.deltaTime * lerpSpeed);
    }

    // Абстрактный метод для уменьшения шкалы
    protected virtual void DecreaseBar(float value)
    {
        // Реализация анимации уменьшения шкалы
    }

    // Абстрактный метод для увеличения шкалы
    protected virtual void IncreaseBar(float value)
    {
        // Реализация анимации увеличения шкалы
    }
}