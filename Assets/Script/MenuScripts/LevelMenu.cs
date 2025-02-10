using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;


    public void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("UnlockedLevel", 1);  // รีเซตเลเวลกลับไปที่ 1
        PlayerPrefs.Save();  // บันทึกการเปลี่ยนแปลง
        UpdateLevelButtons(1); // อัพเดต UI ให้เป็นค่าที่รีเซตแล้ว
        Debug.Log("ResetLevelsSuccess");
    }

    void UpdateUnlockLevel(int levelId)
    {
        int currentLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // ตรวจสอบว่าเลเวลถัดไปยังไม่ถูกปลดล็อค
        if (levelId == currentLevel + 1)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelId);
            PlayerPrefs.Save();  // บันทึกข้อมูล
        }
    }

    // ฟังก์ชันเพื่ออัพเดตสถานะของปุ่มใน UI
    void UpdateLevelButtons(int unlockedLevel)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i < unlockedLevel;  // ปรับปุ่มให้สามารถกดได้ตามระดับที่ปลดล็อค
            Debug.Log("UpdateLevelButtonsSuccess");
        }
    }

    void ButtonsToArray()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    public void CloseTab()
    {
        gameObject.SetActive(false);
    }
}
