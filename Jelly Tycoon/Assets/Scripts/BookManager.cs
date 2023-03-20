using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public Jelly jelly;

    public GameObject bookPanel;
    public Image[] jelly_Of_Book;
    public Text[] jellyName_Of_Book;

    public static bool[] jelly_unlock_list;
    int unlock_List_Length;

    // �̱��� ����
    public static BookManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }
  

        // �迭 ����
        jelly_unlock_list = new bool[5]; // �迭 �ȿ� ���ڴ� ���� ������ ����.

        jelly_unlock_list[0] = true; // û���� ���� �ر�

        // ���� �ҷ�����
        unlock_List_Length = PlayerPrefs.GetInt("Upgrade");

        for (int i = 0; i <= unlock_List_Length; i++)
        {
            jelly_unlock_list[i] = true;
        }

        UpdateBook();
    }

    // ������ ���� �ݴ� �޼ҵ�
    public void OpenBookPanel()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        bookPanel.SetActive(true);
    }
    public void CloseBookPanel()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        bookPanel.SetActive(false);
    }

    // �����Ŵ��������� ������ ��� ��Ȳ�� ����

    public void UpdateBook()
    {
        // ��� ��Ȳ�� üũ�ϰ� �̹����� �ؽ�Ʈ�� ����
        for (int i = 0; i < jelly_unlock_list.Length; i++)
        {
            if (jelly_unlock_list[i])
            {
                jelly_Of_Book[i].color = Color.white;
                jellyName_Of_Book[i].text = jelly.jelly_namelist[i];
            }
        }
    }
}
