using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public class SpeechLine 
    {
        public string line;
        public int nextLineId;

        public SpeechLine(string _line, int _nextLineId)
        {
            line = _line;
            nextLineId = _nextLineId;
        }
    }

    public Text text;
    private bool speaking = false;

    public Dictionary<int, SpeechLine> lines = new Dictionary<int, SpeechLine>() {
        {1, new SpeechLine("Thank goodness, you are here!", 2)},
        {2, new SpeechLine("I've been trapped behind this firey wall.", 3)},
        {3, new SpeechLine("I need you to collect four passwords to take it down.", 4)},
        {4, new SpeechLine("Please help me, hero.", -1)},
        {5, new SpeechLine("Don't lose hope!", -1)},
        {6, new SpeechLine("You are so close!", -1)},
        {7, new SpeechLine("I believe in you!", -1)},
        {8, new SpeechLine("Hero, please don't give up.", -1)},
        {9, new SpeechLine("Good job, hero, I knew you could do it!", -1)},
        {10, new SpeechLine("Hero, I am impressed. Two passwords is not an easy task!", -1)},
        {11, new SpeechLine("Almost there, hero. Just one more to go!", -1)}
    };

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        text.text = "";
    }

    void Update()
    {
        if (speaking)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void TriggerStartingDialogue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(SpeakLine(1));
    }

    public void TriggerEncouragementDialogue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(SpeakLine(Random.Range(5,8)));
    }

    private IEnumerator WaitThenStart(int id)
    {
        yield return new WaitForSeconds(.5f);
        speaking = true;
        StartCoroutine(SpeakLine(id));
    }

    private IEnumerator SpeakLine(int id)
    {
        text.text = lines[id].line;
        yield return new WaitForSeconds(3);
        if (lines[id].nextLineId > 0)
        {
            StartCoroutine(SpeakLine(lines[id].nextLineId));
        }
        else
        {
            text.text = "";
            speaking = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
