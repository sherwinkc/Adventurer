using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashManager : MonoBehaviour
{
    public Text orb_Text, key_Text, skill_text;
    public GameObject flashingSuperImage;

    private void Awake()
    {
        flashingSuperImage.SetActive(false);
    }

    public IEnumerator FlashText_Orb()
    {

        orb_Text.fontSize = 50;

        yield return new WaitForSeconds(1f);

        orb_Text.fontSize = 35;
    }

    public IEnumerator FlashText_Key()
    {
        key_Text.fontSize = 50;

        yield return new WaitForSeconds(3f);

        key_Text.fontSize = 35;
    }

    public IEnumerator FlashText_Skill()
    {
        skill_text.fontSize = 50;

        flashingSuperImage.SetActive(true);

        yield return new WaitForSeconds(10f);

        skill_text.fontSize = 35;

        flashingSuperImage.SetActive(false);
    }
}
