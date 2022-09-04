using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public class SpeechLine 
    {
        public int id;
        public string line;
        public int nextLineId;

        public SpeechLine(int _id, string _line, int _nextLineId)
        {
            id = _id;
            line = _line;
            nextLineId = _nextLineId;
        }
    }

    public SpeechLine[] lines = {
        new SpeechLine(1, "Thank goodness, you are here!", 2),
        new SpeechLine(2, "I've been trapped behind this firey wall.", 3),
        new SpeechLine(3, "I need you to collect four passwords to take it down.", 4),
        new SpeechLine(4, "Please help me, hero.", -1),
        new SpeechLine(5, "Don't lose hope!", -1),
        new SpeechLine(6, "You are so close!", -1),
        new SpeechLine(7, "I believe in you!", -1),
        new SpeechLine(8, "Hero, please don't give up.", -1),
        new SpeechLine(9, "Good job, hero, I knew you could do it!", -1),
        new SpeechLine(10, "Hero, I am impressed. Two passwords is not an easy task!", -1),
        new SpeechLine(11, "Almost there, hero. Just one more to go!", -1)
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
