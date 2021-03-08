using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashManager : MonoBehaviour
{
    public Text orb_Text, key_Text, skill_text;

    public IEnumerator FlashText_Orb()
    {
        //orb_Text.fontStyle = FontStyle.Bold;
        orb_Text.fontSize = 50;

        yield return new WaitForSeconds(1f);

        //orb_Text.fontStyle = FontStyle.Normal;
        orb_Text.fontSize = 35;
    }

    public IEnumerator FlashText_Key()
    {
        //orb_Text.fontStyle = FontStyle.Bold;
        key_Text.fontSize = 50;

        yield return new WaitForSeconds(3f);

        //orb_Text.fontStyle = FontStyle.Normal;
        key_Text.fontSize = 35;
    }

    public IEnumerator FlashText_Skill()
    {
        //orb_Text.fontStyle = FontStyle.Bold;
        skill_text.fontSize = 50;

        yield return new WaitForSeconds(10f);

        //orb_Text.fontStyle = FontStyle.Normal;
        skill_text.fontSize = 35;
    }
}
