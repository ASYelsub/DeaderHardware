using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextToAnimation : MonoBehaviour
{

    public TextAsset animFile;
    public TextMeshPro textBox;

    string[] animStrings;
    public bool glitchIt;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshPro>();
        animStrings = animFile.text.Split('~');
    }

    int frame;
    int currentFR;

    public float glitchProb;

    private void FixedUpdate()
    {
        frame++;

        if (frame % 2 == 0)
        {
            currentFR++;
            textBox.alignment = TextAlignmentOptions.BottomLeft;
            textBox.fontStyle = FontStyles.Normal;
            if (odds(glitchProb)) { textBox.alignment = TextAlignmentOptions.Justified; textBox.fontStyle = FontStyles.Underline; }
        }
        if (currentFR == animStrings.Length)
        {
            currentFR = 0;
        }

        textBox.text = animStrings[currentFR];
    }

    bool odds(float prob)
    {
        float rnd = Random.Range(0,1f);
        return prob >= rnd;
    }
}
