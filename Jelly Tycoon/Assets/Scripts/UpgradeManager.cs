using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Jelly jelly; // ���� ��ũ��Ʈ

    public Text level_text; // ��ȭ���� �ؽ�Ʈ
    public Text upgradeLevel_text; // �������� �ؽ�Ʈ
    public Text jelatinProbLevel_text; // ����ƾ ȹ�� Ȯ�� ���� �ؽ�Ʈ
    public Text jelatinAmountLevel_text; // ����ƾ ȹ�淮 ���� �ؽ�Ʈ

    public Image jelly_Image; // ���� �̹���
    public Image jelly_UnlockImage; // �ر� �˾� â ���� �̹���
    public Text jelly_Name; // �ر� �˾� â ���� �̸�
    public Text jelly_Gold_Amount; // �ش� ������ Ŭ�� �� ����帮�� ��带 ��Ÿ���� �ؽ�Ʈ

    public Text jelly_LevelUp_PriceText; // ���� ��ȭ ���� �ؽ�Ʈ
    public Text jelly_Upgrade_PriceText; // ���� ���� ���� �ؽ�Ʈ
    public Text jelatinProb_LevelUp_PriceText; // ����ƾ ȹ�� Ȯ�� ���� �ؽ�Ʈ
    public Text jelatinAmount_LevelUp_PriceText; // ����ƾ ȹ�淮 ���� �ؽ�Ʈ

    public Text market_item_1; // ���� 1�� ��ǰ ���� ���� �ؽ�Ʈ
    public Text market_item_2; // ���� 2�� ��ǰ ���� ���� �ؽ�Ʈ
    public Text market_item_3; // ���� 3�� ��ǰ ���� ���� �ؽ�Ʈ
    public Text market_item_4; // ���� 4�� ��ǰ ���� ���� �ؽ�Ʈ
    public Text market_item_5; // ���� 5�� ��ǰ ���� ���� �ؽ�Ʈ

    public Button market_Buy_Btn_1; //���� 1�� ��ǰ ���� ��ư
    public Button market_Buy_Btn_2; //���� 2�� ��ǰ ���� ��ư
    public Button market_Buy_Btn_3; //���� 3�� ��ǰ ���� ��ư
    public Button market_Buy_Btn_4; //���� 4�� ��ǰ ���� ��ư
    public Button market_Buy_Btn_5; //���� 5�� ��ǰ ���� ��ư

    public Button jelly_LevelUp_Btn; // ���� ǰ�� ���׷��̵� ��ư
    public Button jelly_Upgrade_Btn; // ���� ���� ���׷��̵� ��ư
    public Button jelatinProb_Btn; // ����ƾ ȹ�� Ȯ�� ���׷��̵� ��ư
    public Button jelatinAmount_Btn; // ����ƾ ȹ�淮 ���׷��̵� ��ư

    public GameObject plate; // ���� 1�� ��ǰ: ����
    public GameObject window; // ���� 2�� ��ǰ: â��
    public GameObject clock; // ���� 3�� ��ǰ: �ð�
    public GameObject ice; // ���� 4�� ��ǰ: ���� ��ġ
    public GameObject jelly_Doll; // ���� 5�� ��ǰ: ���� ����

    public Image deco_UnlockImage; // ���� ȹ�� �˾� â ���� �̹���
    public Text deco_Name; // ���� ȹ�� �˾� â ���� �̸�
    public Text deco_Info; // ���� ȹ�� �˾� â ���� ����
    public Text deco_State_Info; // ���� ȹ�� �˾� â ���� �ɷ� ����

    public bool isBuy_Plate; // ���ø� ���� ���ΰ�?
    public bool isBuy_Window; // â���� ���� ���ΰ�?
    public bool isBuy_Clock; // �ð踦 ���� ���ΰ�?
    public bool isBuy_Ice; // ���� ��ġ�� ���� ���ΰ�?
    public bool isBuy_Jelly_Doll; // ���� ������ ���� ���ΰ�?

    public GameObject deco_UnlockPanel; // ���� ȹ�� �˾�â
    public GameObject unlockPanel; // �ر� �˾�â
    public GameObject marketPanel; // ���� â
    public GameObject rewardAD_Panel; // �����層�� �г�

    private void Awake()
    {

        // ������ �ҷ�����
        jelly.level = PlayerPrefs.GetInt("Level");
        jelly.jelly_Class = PlayerPrefs.GetInt("Upgrade");
        jelly.jelatin_Prob_Level = PlayerPrefs.GetInt("Prob_Level");
        jelly.get_Jelatin_Amount_Level = PlayerPrefs.GetInt("Amount_Level");

        jelly.jelatin_Prob = PlayerPrefs.GetInt("Prob");
        jelly.get_Jelatin_Amount = PlayerPrefs.GetInt("Amount");
        jelly.deco_Get_Gold_Amount = PlayerPrefs.GetFloat("Deco_Get_Gold_Amount");

        isBuy_Plate = System.Convert.ToBoolean(PlayerPrefs.GetInt("Plate"));
        isBuy_Window = System.Convert.ToBoolean(PlayerPrefs.GetInt("Window"));
        isBuy_Clock = System.Convert.ToBoolean(PlayerPrefs.GetInt("Clock"));
        isBuy_Ice = System.Convert.ToBoolean(PlayerPrefs.GetInt("Ice"));
        isBuy_Jelly_Doll = System.Convert.ToBoolean(PlayerPrefs.GetInt("JellyDoll"));


        plate.SetActive(isBuy_Plate);
        window.SetActive(isBuy_Window);
        clock.SetActive(isBuy_Clock);
        ice.SetActive(isBuy_Ice);
        jelly_Doll.SetActive(isBuy_Jelly_Doll);

        jelly_Image.sprite = jelly.jelly_spritelist[jelly.jelly_Class];
        jelly_Name.text = jelly.jelly_namelist[jelly.jelly_Class]; // ���� �̸� ����


        // ���׷��̵� ����

        // ���� ǰ��
        if (jelly.level == jelly.jelly_LevelUp_pricelist.Length) // ���� ǰ�� ���� �ִ� �����̶��
        {
            jelly_LevelUp_Btn.interactable = false;
            jelly_LevelUp_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelly_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelly_LevelUp_pricelist[(int)jelly.level]); // ��ȭ ���� ����
        }

        // ���� ����
        if (jelly.jelly_Class == jelly.jelly_Upgrade_pricelist.Length) // ���� ���� ���� �ִ� �����̶��
        {
            jelly_Upgrade_Btn.interactable = false;
            jelly_Upgrade_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelly_Upgrade_PriceText.text = string.Format("{0:n0}", jelly.jelly_Upgrade_pricelist[jelly.jelly_Class]); // ���� ���� ����
        }

        // ����ƾ ȹ�� Ȯ��
        if (jelly.jelatin_Prob_Level == jelly.jelatinProb_LevelUp_pricelist.Length) // ����ƾ ȹ�� Ȯ�� ���� �ִ� �����̶��
        {
            jelatinProb_Btn.interactable = false;
            jelatinProb_LevelUp_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelatinProb_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level]); // ��ȭ ���� ����
        }

        // ����ƾ ȹ�淮
        if (jelly.get_Jelatin_Amount_Level == jelly.jelatinAmount_LevelUp_pricelist.Length) // ����ƾ ȹ�淮 ���� �ִ� �����̶��
        {
            jelatinAmount_Btn.interactable = false;
            jelatinAmount_LevelUp_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelatinAmount_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level]); // ��ȭ ���� ����
        }


        // ���� ���� ����
        if (isBuy_Plate)
        {
            market_Buy_Btn_1.interactable = false;
            market_item_1.text = "���� �Ϸ�";
        }
        else
        {
            market_item_1.text = string.Format("{0:n0}", jelly.market_item_pricelist[0]); // ���� 1�� ��ǰ ���� ����
        }

        // â��
        if (isBuy_Window)
        {
            market_Buy_Btn_2.interactable = false;
            market_item_2.text = "���� �Ϸ�";
        }
        else
        {

            market_item_2.text = string.Format("{0:n0}", jelly.market_item_pricelist[1]); // ���� 2�� ��ǰ ���� ����
        }

        // �ð�
        if (isBuy_Clock)
        {
            market_Buy_Btn_3.interactable = false;
            market_item_3.text = "���� �Ϸ�";
        }
        else
        {

            market_item_3.text = string.Format("{0:n0}", jelly.market_item_pricelist[2]); // ���� 3�� ��ǰ ���� ����
        }

        // ���� ��ġ
        if (isBuy_Ice)
        {
            market_Buy_Btn_4.interactable = false;
            market_item_4.text = "���� �Ϸ�";
        }
        else
        {

            market_item_4.text = string.Format("{0:n0}", jelly.market_item_pricelist[3]); // ���� 4�� ��ǰ ���� ����
        }

        // ���� ����
        if (isBuy_Jelly_Doll)
        {
            market_Buy_Btn_5.interactable = false;
            market_item_5.text = "���� �Ϸ�";
        }
        else
        {

            market_item_5.text = string.Format("{0:n0}", jelly.market_item_pricelist[4]); // ���� 5�� ��ǰ ���� ����
        }


        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }


    // ���� ǰ��
    public void JellyLevelUp()
    {
        if (jelly.gm.gold < jelly.jelly_LevelUp_pricelist[(int)jelly.level])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.gold -= jelly.jelly_LevelUp_pricelist[(int)jelly.level]; // ����
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����

        jelly.level += 1;
        SoundManager.instance.PlaySound("BuyItem");
        PlayerPrefs.SetInt("Level", (int)jelly.level); // ��ȭ ���� ����

        if (jelly.level == jelly.jelly_LevelUp_pricelist.Length) // ���� ǰ�� ���� �ִ� �����̶��
        {
            jelly_LevelUp_Btn.interactable = false;
            jelly_LevelUp_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelly_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelly_LevelUp_pricelist[(int)jelly.level]); // ��ȭ ���� ����
        }

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // ���� ����
    public void UpgradeJelly()
    {
        if (jelly.gm.jelatin < jelly.jelly_Upgrade_pricelist[jelly.jelly_Class])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.jelatin -= jelly.jelly_Upgrade_pricelist[jelly.jelly_Class]; // ����
        PlayerPrefs.SetFloat("Jelatin", jelly.gm.jelatin); // ����ƾ ����

        jelly.jelly_Class += 1;
        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("UpgradeJelly");

        // ����
        BookManager.jelly_unlock_list[jelly.jelly_Class] = true; // �ش� ���� ���� �ر�
        BookManager.instance.UpdateBook();

        PlayerPrefs.SetInt("Upgrade", jelly.jelly_Class); // ���� ���� ����

        jelly_Image.sprite = jelly.jelly_spritelist[jelly.jelly_Class]; // ���� �̹��� ����
        jelly_UnlockImage.sprite = jelly.jelly_spritelist[jelly.jelly_Class]; // �ر� �˾� â ���� �̹��� ����
        jelly_Gold_Amount.text = string.Format("{0:n0}", "���� " + jelly.get_Gold_Amount[jelly.jelly_Class] + "��"); // ���� ���� ��(����) �ؽ�Ʈ ����
        jelly_Name.text = jelly.jelly_namelist[jelly.jelly_Class]; // ���� �̸� ����

        if (jelly.jelly_Class == jelly.jelly_Upgrade_pricelist.Length) // ���� ���� ���� �ִ� �����̶��
        {
            jelly_Upgrade_Btn.interactable = false;
            jelly_Upgrade_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelly_Upgrade_PriceText.text = string.Format("{0:n0}", jelly.jelly_Upgrade_pricelist[jelly.jelly_Class]); // ���� ���� ����
        }

        unlockPanel.gameObject.SetActive(true);

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // ����ƾ ȹ�� Ȯ��
    public void JelatinProb_LevelUp()
    {
        if (jelly.gm.gold < jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.gold -= jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level]; // ����
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����

        jelly.jelatin_Prob += 1; // ����ƾ ȹ�� Ȯ�� +1
        jelly.jelatin_Prob_Level += 1; // ���� +1
        SoundManager.instance.PlaySound("BuyItem"); // ȿ���� ���

        PlayerPrefs.SetInt("Prob_Level", jelly.jelatin_Prob_Level); // ��ȭ ���� ����
        PlayerPrefs.SetInt("Prob", jelly.jelatin_Prob); // ����ƾ ȹ�� Ȯ�� ����

        if (jelly.jelatin_Prob_Level == jelly.jelatinProb_LevelUp_pricelist.Length) // ����ƾ ȹ�� Ȯ�� ���� �ִ� �����̶��
        {
            jelatinProb_Btn.interactable = false;
            jelatinProb_LevelUp_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelatinProb_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level]); // ��ȭ ���� ����
        }

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // ����ƾ ȹ�淮
    public void JelatinAmount_LevelUp()
    {
        if (jelly.gm.jelatin < jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.jelatin -= jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level]; // ����
        PlayerPrefs.SetFloat("Jelatin", jelly.gm.jelatin); // ����ƾ ����

        jelly.get_Jelatin_Amount += 1; // ����ƾ ȹ�淮����
        jelly.get_Jelatin_Amount_Level += 1; // ���� +1

        SoundManager.instance.PlaySound("BuyItem"); // ȿ���� ���

        PlayerPrefs.SetInt("Amount_Level", jelly.get_Jelatin_Amount_Level); // ��ȭ ���� ����
        PlayerPrefs.SetInt("Amount", jelly.get_Jelatin_Amount); // ����ƾ ȹ�淮 ����

        if (jelly.get_Jelatin_Amount_Level == jelly.jelatinAmount_LevelUp_pricelist.Length) // ����ƾ ȹ�淮 ���� �ִ� �����̶��
        {
            jelatinAmount_Btn.interactable = false;
            jelatinAmount_LevelUp_PriceText.text = "�ִ� ����";
        }
        else
        {
            jelatinAmount_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level]); // ��ȭ ���� ����
        }

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // �ؽ�Ʈ ������
    private void TextRenewal()
    {
        level_text.text = "���� " + ((jelly.level / 10) + (jelly.deco_Get_Gold_Amount / 10) + 1) + "��";
        upgradeLevel_text.text = (jelly.jelly_Class + 1) + "�ܰ� ";
        jelatinProbLevel_text.text = "Ȯ�� " + (jelly.jelatin_Prob + 1) + "%";
        jelatinAmountLevel_text.text = "ȹ�� " + (jelly.get_Jelatin_Amount + 1) + "��";
    }

    // ���� �˾� â �ݱ�
    public void ClosePopUp()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        unlockPanel.gameObject.SetActive(false);
    }

    // ���� �˾� â ����
    public void OpenMarket()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        marketPanel.gameObject.SetActive(true);
    }

    // ���� �˾� â �ݱ�
    public void CloseMarket()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        marketPanel.gameObject.SetActive(false);
    }

    // ������ ���� â ����
    public void OpenReward_Tap()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        rewardAD_Panel.gameObject.SetActive(true);
    }

    // ������ ���� â �ݱ�
    public void CloseReward_Tap()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        rewardAD_Panel.gameObject.SetActive(false);
    }

    // 1�� ������ ���� ����
    public void BuyItem1()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[0])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[0]; // ����

        isBuy_Plate = true; // ���ø� �����ߴ°�? true
        plate.gameObject.SetActive(true);

        jelly.deco_Get_Gold_Amount += 5; // ���� +0.5��

        PlayerPrefs.SetFloat("Deco_Get_Gold_Amount", jelly.deco_Get_Gold_Amount); // ���ڷ� ���� ��� ���� ����
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����
        PlayerPrefs.SetInt("Plate", System.Convert.ToInt16(isBuy_Plate)); // ���� bool �� ����

        deco_UnlockImage.sprite = jelly.deco_spritelist[0]; // ���� ȹ�� �˾� â �̹��� ����
        deco_Name.text = jelly.deco_namelist[0]; // ���� ȹ�� �˾� â �̸� ����
        deco_Info.text = jelly.deco_infolist[0]; // ���� ȹ�� �˾� â ���� ����
        deco_State_Info.text = jelly.deco_state_infolist[0]; // ���� ȹ�� �˾� â ���� �ɷ� ���� ����

        market_Buy_Btn_1.interactable = false;
        market_item_1.text = "���� �Ϸ�";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // 2�� ������ â�� ����
    public void BuyItem2()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[1])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[1]; // ����

        isBuy_Window = true; // â���� �����ߴ°�? true
        window.gameObject.SetActive(true);

        jelly.deco_Get_Gold_Amount += 5; // ���� +0.5��

        PlayerPrefs.SetFloat("Deco_Get_Gold_Amount", jelly.deco_Get_Gold_Amount); // ���ڷ� ���� ��� ���� ����
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����
        PlayerPrefs.SetInt("Window", System.Convert.ToInt16(isBuy_Window)); // ���� bool �� ����

        deco_UnlockImage.sprite = jelly.deco_spritelist[1]; // ���� ȹ�� �˾� â �̹��� ����
        deco_Name.text = jelly.deco_namelist[1]; // ���� ȹ�� �˾� â �̸� ����
        deco_Info.text = jelly.deco_infolist[1]; // ���� ȹ�� �˾� â ���� ����
        deco_State_Info.text = jelly.deco_state_infolist[1]; // ���� ȹ�� �˾� â ���� �ɷ� ���� ����

        market_Buy_Btn_2.interactable = false;
        market_item_2.text = "���� �Ϸ�";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // 3�� ������ �ð� ����
    public void BuyItem3()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[2])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[2]; // ����

        isBuy_Clock = true; // �ð踦 �����ߴ°�? true
        clock.gameObject.SetActive(true);

        jelly.jelatin_Prob += 5; // ����ƾ ȹ�� Ȯ�� 5% ����
        PlayerPrefs.SetInt("Prob", jelly.jelatin_Prob); // ����ƾ ȹ�� Ȯ�� ����

        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����
        PlayerPrefs.SetInt("Clock", System.Convert.ToInt16(isBuy_Clock)); // ���� bool �� ����

        deco_UnlockImage.sprite = jelly.deco_spritelist[2]; // ���� ȹ�� �˾� â �̹��� ����
        deco_Name.text = jelly.deco_namelist[2]; // ���� ȹ�� �˾� â �̸� ����
        deco_Info.text = jelly.deco_infolist[2]; // ���� ȹ�� �˾� â ���� ����
        deco_State_Info.text = jelly.deco_state_infolist[2]; // ���� ȹ�� �˾� â ���� �ɷ� ���� ����

        market_Buy_Btn_3.interactable = false;
        market_item_3.text = "���� �Ϸ�";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // 4�� ������ ���� ��ġ ����
    public void BuyItem4()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[3])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[3]; // ����

        isBuy_Ice = true; // ���� ��ġ�� �����ߴ°�? true
        ice.gameObject.SetActive(true);

        jelly.deco_Get_Gold_Amount += 5; // ���� +0.5��

        PlayerPrefs.SetFloat("Deco_Get_Gold_Amount", jelly.deco_Get_Gold_Amount); // ���ڷ� ���� ��� ���� ����
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����
        PlayerPrefs.SetInt("Ice", System.Convert.ToInt16(isBuy_Ice)); // ���� bool �� ����

        deco_UnlockImage.sprite = jelly.deco_spritelist[3]; // ���� ȹ�� �˾� â �̹��� ����
        deco_Name.text = jelly.deco_namelist[3]; // ���� ȹ�� �˾� â �̸� ����
        deco_Info.text = jelly.deco_infolist[3]; // ���� ȹ�� �˾� â ���� ����
        deco_State_Info.text = jelly.deco_state_infolist[3]; // ���� ȹ�� �˾� â ���� �ɷ� ���� ����

        market_Buy_Btn_4.interactable = false;
        market_item_4.text = "���� �Ϸ�";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }

    // 5�� ������ ���� ���� ����
    public void BuyItem5()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[4])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[4]; // ����

        isBuy_Jelly_Doll = true; // ���� ������ �����ߴ°�? true
        jelly_Doll.gameObject.SetActive(true);

        jelly.get_Jelatin_Amount += 5; // ���� ȹ�淮 5�� ����

        PlayerPrefs.SetInt("Amount", jelly.get_Jelatin_Amount); // ����ƾ ȹ�淮 ����
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // ��� ����
        PlayerPrefs.SetInt("JellyDoll", System.Convert.ToInt16(isBuy_Jelly_Doll)); // ���� bool �� ����

        deco_UnlockImage.sprite = jelly.deco_spritelist[4]; // ���� ȹ�� �˾� â �̹��� ����
        deco_Name.text = jelly.deco_namelist[4]; // ���� ȹ�� �˾� â �̸� ����
        deco_Info.text = jelly.deco_infolist[4]; // ���� ȹ�� �˾� â ���� ����
        deco_State_Info.text = jelly.deco_state_infolist[4]; // ���� ȹ�� �˾� â ���� �ɷ� ���� ����

        market_Buy_Btn_5.interactable = false;
        market_item_5.text = "���� �Ϸ�";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // ���׷��̵� �޴� �Ϻ� �ؽ�Ʈ ������
    }
}
