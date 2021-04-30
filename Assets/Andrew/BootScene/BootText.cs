using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BootText : MonoBehaviour
{

    public bool performingAction;

    public int actionToPerform;
    public float actionLength;
    public string actionString;

    public TextMeshPro consoleText;

    public string displayString;

    public bool isCredits;

    void Start()
    {
        consoleText = GetComponent<TextMeshPro>();
        title = consoleText.text;
        PerformAction(-1);
        if (!isCredits)
        {
            StartCoroutine(bootScreenSequence());
        }
        else
        {
            StartCoroutine(creditSequence());
        }
        moveToNextLevel = false;
    }

    public string title;
    public string TitleText;
    public string[] emotes;

    IEnumerator creditSequence()
    {
        yield return new WaitForSeconds(2);
        consoleText.alignment = TextAlignmentOptions.Center;
        PerformAction(0, "[END OF DEMO]\n", .075f);
        yield return new WaitForSeconds(2);
        PerformAction(2, "", 2f);
        yield return new WaitForSeconds(2.2f);
        PerformAction(-1);
        yield return new WaitForSeconds(.1f);
        consoleText.alignment = TextAlignmentOptions.BottomLeft;

        yield return new WaitForSeconds(.1f);
        //displayString = title;
        PerformAction(0,title,0);
        //TitleText = title;
        yield return new WaitForSeconds(4f);
        PerformAction(0, "\n=====================================================================================================\n", 0);
        yield return new WaitForSeconds(1.5f);

        PerformAction(1,"\n[CREDITS]\n\n");
        yield return new WaitForSeconds(.1f);

        PerformAction(1, $"\n[{"Name"}] {emotes[0]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        PerformAction(1, $"\n[{"Name"}] {emotes[1]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        PerformAction(1, $"\n[{"Name"}] {emotes[2]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        PerformAction(1, $"\n[{"Name"}] {emotes[3]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        PerformAction(1, $"\n[{"Name"}] {emotes[4]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        PerformAction(1, $"\n[{"Name"}] {emotes[5]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        PerformAction(1, $"\n[{"Name"}] {emotes[6]}\n");
        PerformAction(0, "  -Contribution 1\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 2\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 3\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "  -Contribution 4\n");
        yield return new WaitForSeconds(.5f);

        yield return new WaitForSeconds(2.2f);
        PerformAction(-1);
        yield return new WaitForSeconds(.1f);
        consoleText.alignment = TextAlignmentOptions.Center;
        PerformAction(0, "[THANKS FOR PLAYING]",.09f);
        yield return new WaitForSeconds(4f);

        moveToNextLevel = true;
    }

    IEnumerator bootScreenSequence()
    {
        yield return new WaitForSeconds(1);
        PerformAction(0, "<b>VIV RECOVERY TOOL, Viv-tech, Inc. 2001</b>\n\n");
        yield return new WaitForSeconds(.6f);
        PerformAction(1,"<b>[INITIATING SAFE-BOOT SEQUENCE]</b>\n\n");
        PerformAction(1,"System user name: "+Application.persistentDataPath.Split('/')[2]+"\n");
        yield return new WaitForSeconds(.5f);
        PerformAction(0, "Seeking: x://Tool_emulation/developerkey/root_sys.viv/\n",0);
        yield return new WaitForSeconds(1);
        PerformAction(1,"Loading");
        PerformAction(2, "", 2);
        yield return new WaitForSeconds(2.2f);
        PerformAction(1,"/<color=yellow>FILE FOUND</color>\n\n");
        PerformAction(0,"repair tool added, gathering hardware information...\n\n");
        yield return new WaitForSeconds(1);
        PerformAction(0, "<size=8>[*****</size>",.25f);
        yield return new WaitForSeconds(3);
        PerformAction(0, "<size=8>***]</size>",.5f);
        yield return new WaitForSeconds(4);
        PerformAction(1, "\n");
        PerformAction(0, "SYSTEM INFORMATION COLLECTED.\n \n");
        yield return new WaitForSeconds(1f);
        PerformAction(1, "SYSTEM MEMORY: 4.89/6gb \n");
        PerformAction(1, "AVAILABLE MEMORY: 2gb \n");
        PerformAction(1, $"MODEL NUMBER: DH-{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}\n");
        PerformAction(1, "---------------------------------------~\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1,"\n[Disc Drive]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}",.05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=yellow>(ACTIVE)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1, "\n[Fan]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}", .05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=red>(DEAD/NOT FOUND)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1, "\n[Input Port - 0]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}", .05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=yellow>(ACTIVE)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1, "\n[Input Port - 1]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}", .05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=red>(DEAD/NOT FOUND)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1, "\n[Input Port - 2]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}", .05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=yellow>(ACTIVE)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1, "\n[Input Port - 3]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}", .05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=yellow>(ACTIVE)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(.1f);
        PerformAction(1, "\n[External Memory Port]:\n");
        PerformAction(0, $"0x000{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}{Random.Range(0, 9)}", .05f);
        yield return new WaitForSeconds(.75f);
        PerformAction(1, " <color=red>(DEAD/NOT FOUND)\n</color>");
        PerformAction(1, "--\n");

        yield return new WaitForSeconds(1f);
        PerformAction(0, "\nGENERATING CURSORY DIAGNOSIS");
        yield return new WaitForSeconds(.2f);
        PerformAction(2, "", 4f);
        yield return new WaitForSeconds(5);
        PerformAction(1, " (<color=yellow>COMPLETE</color>)");
        PerformAction(0, "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", .07f);
        yield return new WaitForSeconds(4);

        PerformAction(0,"\nSAFE TO BOOT, HARDWARE/SOFTWARE ISSUES FOUND.",.05f);
        yield return new WaitForSeconds(3);
        moveToNextLevel = true;
    }

    bool moveToNextLevel;
    public int Scene_int = -1;
    public string Scene_str = "-";

    void Update()
    {
        consoleText.SetText(TitleText + displayString + loadString);
        if (moveToNextLevel)
        {
            consoleText.color = Color.Lerp(consoleText.color, new Color(0,0,0,-.1f), Time.deltaTime);
            if (consoleText.color.a <= 0)
            {
                ChangeScene(Scene_int,Scene_str);
            }
        }
    }

    void ChangeScene(int scene_int=-1,string scene_str="-")
    {
        if (scene_int != -1)
        {
            SceneManager.LoadScene(scene_int);
        }
        else if (scene_str != "-")
        {
            SceneManager.LoadScene(scene_str);
        }
        else
        {
            print("NO VALID SCENE ASSIGNED...");
        }
    }

    int frames;

    void FixedUpdate()
    {
        frames++;
        if (ellipseLoading)
        {
            loadTimer_ += Time.deltaTime;

            if (frames % 10 == 0)
            {
                loadString = "";
                dotCount++;
                for (int i = 0; i < dotCount; i++)
                {
                    loadString+=".";
                }
                if (dotCount == 3) { dotCount = 0; }
            }

            if (loadTimer_ >= loadTime_)
            {
                loadString = "";
                ellipseLoading = false;
                performingAction = false;
                //print("hi");
            }
        }
    }

    void PerformAction(int act, string txt = "", float loadTime = 0)
    {
        switch (act)
        {
            case -1: //clear
                displayString = "";
                break;
            case 0: //type text
                typeOutText(txt,loadTime);
                break;
            case 1: //add text
                addText(txt);
                break;
            case 2: //loading dots
                EllipseLoad(loadTime);
                break;
            default:
                break;
        }
        performingAction = true;
    }

    int charInt;

    void addText(string txt)
    {
        displayString += txt;
    }

    void typeOutText(string txt,float spd)
    {
        charInt = 0;
        StartCoroutine(textTyper(txt,spd));
    }

    IEnumerator textTyper(string txt,float spd)
    {
        if (txt[charInt].ToString() == "<")
        {
            while (true)
            {
                displayString += txt[charInt].ToString();
                charInt++;
                if (txt[charInt].ToString() == ">") { break; }
            }
        }

        displayString += txt[charInt].ToString();
        charInt++;
        yield return new WaitForSeconds(spd);
        if (charInt == txt.Length)
        {
            performingAction = false;
        }
        else
        {
            StartCoroutine(textTyper(txt,spd));
        }
    }

    bool ellipseLoading;
    float loadTime_;
    float loadTimer_;
    int dotCount;
    string loadString;

    void EllipseLoad(float loadTime)
    {
        loadString = "";
        dotCount = 0;
        ellipseLoading = true;
        loadTime_ = loadTime;
        loadTimer_ = 0;
    }
}
