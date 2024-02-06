using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider overall, music, effects;
    public Text overallValue, musicValue, effectsValue;
    public GameObject settingsTab;
    private Animator _animator;
    public AudioClip click;
    public AudioSource audioSource;

    private void Start()
    {
        // Установка начальных значений слайдеров
        overall.value = PlayerPrefs.GetFloat("MasterVolume", 0f);
        music.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        effects.value = PlayerPrefs.GetFloat("EffectsVolume", 0f);

        // Установка начальных значений в AudioMixer
        audioMixer.SetFloat("MasterVolume", overall.value);
        audioMixer.SetFloat("MusicVolume", music.value);
        audioMixer.SetFloat("EffectsVolume", effects.value);

        _animator = settingsTab.GetComponent<Animator>();

        // Обновление текстовых полей с текущими значениями слайдеров
        UpdateSliderValues();
    }

    private void Update()
    {
        // Обновление текстовых полей с текущими значениями слайдеров
        UpdateSliderValues();

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(click);
        }
    }

    private void UpdateSliderValues()
    {
        overallValue.text = (overall.value + 80) + "%";
        musicValue.text = (music.value + 80) + "%";
        effectsValue.text = (effects.value + 80) + "%";
    }

    public void overallSoundChange()
    {
        audioMixer.SetFloat("MasterVolume", overall.value);
        PlayerPrefs.SetFloat("MasterVolume", overall.value);
    }

    public void musicSoundChange()
    {
        audioMixer.SetFloat("MusicVolume", music.value);
        PlayerPrefs.SetFloat("MusicVolume", music.value);
    }

    public void effectsSoundChange()
    {
        audioMixer.SetFloat("EffectsVolume", effects.value);
        PlayerPrefs.SetFloat("EffectsVolume", effects.value);
    }

    public void openCloseSettingsTab()
    {
        if (settingsTab.transform.position.y < 0)
        {
            _animator.SetBool("open", true);
            _animator.SetBool("close", false);
        }
        else
        {
            _animator.SetBool("close", true);
            _animator.SetBool("open", false);
        }
    }
}