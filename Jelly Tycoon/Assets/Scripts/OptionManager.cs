using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Slider bgmBar;
    public Slider sfxBar;

    public GameObject optionPanel;
    public GameObject sound_OptionPanel;

    private void Start()
    {
        // ���� �� ���� �ִٸ�
        if (PlayerPrefs.HasKey("bgmVolume") && PlayerPrefs.HasKey("sfxVolume"))
        {
            // ������ �ҷ�����
            bgmBar.value = PlayerPrefs.GetFloat("bgmVolume");
            sfxBar.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            // �⺻��
            bgmBar.value = 0.5f;
            sfxBar.value = 0.5f;
        }
    }

    // ���� ����
    public void Set_BGM_Volum(float volume)
    {
        SoundManager.instance.bgm_Player.volume = volume;
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }

    public void Set_SFX_Volum(float volume)
    {
        SoundManager.instance.sfx_Player.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    // ���� ����
    public void OpenOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        optionPanel.gameObject.SetActive(true);
    }

    // ���� �ݱ�
    public void CloseOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        optionPanel.gameObject.SetActive(false);
    }

    // ���� ���� ����
    public void OpenSoundOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        sound_OptionPanel.gameObject.SetActive(true);
    }

    // ���� ���� �ݱ�
    public void CloseSoundOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        sound_OptionPanel.gameObject.SetActive(false);
    }

    // ���� ����
    public void Quit()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Application.Quit();
    }
}
