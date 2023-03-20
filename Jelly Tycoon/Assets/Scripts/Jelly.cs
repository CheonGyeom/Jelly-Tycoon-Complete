using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jelly : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameManager gm;
    public UpgradeManager um;

    public float level; // ���� ��ȭ ����
    public int jelly_Class; // ���� ���� ����
    public int jelatin_Prob_Level; // ����ƾ ȹ�� Ȯ�� ����
    public int jelatin_Prob; // ����ƾ ȹ�� Ȯ��
    public int get_Jelatin_Amount_Level; // ����ƾ ȹ�淮 ����
    public int get_Jelatin_Amount; // ����ƾ ȹ�淮

    public float deco_Get_Gold_Amount; // ���ڷ� ���� ��� ����

    public int[] get_Gold_Amount; // ���� ������ ���� ��� ȹ�淮 �迭

    public Sprite[] jelly_spritelist; // ���� ��������Ʈ �迭
    public string[] jelly_namelist; // ���� �̸� �迭
    public Sprite[] deco_spritelist; // ���� ��������Ʈ �迭
    public string[] deco_namelist; // ���� �̸� �迭
    public string[] deco_infolist; // ���� ���� �迭
    public string[] deco_state_infolist; // ���� �ɷ� ���� �迭
    public int[] jelly_LevelUp_pricelist; // ��ȭ ���� �迭
    public int[] jelly_Upgrade_pricelist; // ���� ���� �迭
    public int[] jelatinProb_LevelUp_pricelist; // ����ƾ ȹ�� Ȯ�� ���� �迭
    public int[] jelatinAmount_LevelUp_pricelist; // ����ƾ ȹ�淮 ���� �迭
    public int[] market_item_pricelist; // ���� ��ǰ ���� �迭

    public float anim_size; // Ŭ�� �ִϸ��̼� ������


    public void OnPointerDown(PointerEventData data)
    {
        transform.localScale = new Vector3(anim_size + 0.05f, anim_size + 0.05f, 1);
    }

    public void OnPointerUp(PointerEventData data)
    {
        // ��� ȹ��
        gm.gold += ((level / 10) + (deco_Get_Gold_Amount / 10) + 1) * get_Gold_Amount[jelly_Class]; // ����������

        // ���� ����
        int rand = Random.Range(1, 101);

        // ������ ����ƾ ȹ�� Ȯ������ �۰ų� ������
        if (rand <= jelatin_Prob + 1)
        {
            // ����ƾ ȹ��
            gm.jelatin += ((get_Jelatin_Amount + 1));

            // ȿ���� ���
            SoundManager.instance.PlaySound("Get_Jelatin");
        }
        else
        {
            // ȿ���� ���
            SoundManager.instance.PlaySound("jellyTouch");
        }

        PlayerPrefs.SetFloat("Gold", gm.gold); // ��� ����
        PlayerPrefs.SetFloat("Jelatin", gm.jelatin); // ����ƾ ����

        transform.localScale = new Vector3(anim_size, anim_size, 1);
    }
}
