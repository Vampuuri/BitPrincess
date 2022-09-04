using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private bool carriesPassword = false;
    public bool lockLevels = false;
    private string currentLevel = "MainGame";
    private bool introTextSeen = false;

    private List<string> allLevels = new List<string>
        { "Level1", "Level2", "Level3", "Level4"};
    private List<string> levels = new List<string>
        { "Level1", "Level2", "Level3", "Level4"};
    public List<string> destroyChains = new List<string> {};

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PasswordDelivered()
    {
        if (carriesPassword)
        {
            carriesPassword = false;
            lockLevels = false;

            for (int i = 0; i < allLevels.Count; i++)
            {
                if (!levels.Contains(allLevels[i]) && !destroyChains.Contains(allLevels[i]))
                {
                    destroyChains.Add(allLevels[i]);
                }
            }

            GameObject[] levelPortals = GameObject.FindGameObjectsWithTag("LevelEntrance");
            for (int i = 0; i < levelPortals.Length; i++)
            {
                levelPortals[i].GetComponent<LevelSelection>().activate();
            }

            GameObject[] chains = GameObject.FindGameObjectsWithTag("Chain");
            for (int i = 0; i < chains.Length; i++)
            {
                chains[i].GetComponent<ChainDesrtoyable>().CheckDestroy(destroyChains);
            }

            GameObject speechBubble = GameObject.FindGameObjectWithTag("SpeechBubble");
            speechBubble.GetComponent<SpeechBubble>().TriggerPasswordDialogue(allLevels.Count - levels.Count);
        }
    }

    public void RemoveCurrentLevel()
    {
        if (levels.Contains(currentLevel))
        {
            levels.Remove(currentLevel);
        }
    }

    public void RemoveLevel(string level)
    {
        if (levels.Contains(level))
        {
            levels.Remove(level);
        }
    }

    public List<string> GetLevels()
    {
        return levels;
    }

    void OnLevelWasLoaded(int level) {
        if (level == 1)
        {
            if (!introTextSeen)
            {
                introTextSeen = true;
                StartCoroutine(TriggerStartingDialogueAfterAMoment());
            }
            else if (!carriesPassword)
            {
                StartCoroutine(TriggerEncouragementDialogueAfterAMoment());
            }
        }
    }

    private IEnumerator TriggerStartingDialogueAfterAMoment()
    {
        yield return new WaitForSeconds(.5f);
        GameObject speechBubble = GameObject.FindGameObjectWithTag("SpeechBubble");
        speechBubble.GetComponent<SpeechBubble>().TriggerStartingDialogue();
    }

    private IEnumerator TriggerEncouragementDialogueAfterAMoment()
    {
        yield return new WaitForSeconds(.5f);
        GameObject speechBubble = GameObject.FindGameObjectWithTag("SpeechBubble");
        speechBubble.GetComponent<SpeechBubble>().TriggerEncouragementDialogue();
    }

    public void SetCurrentLevel(string _level)
    {
        currentLevel = _level;
    }

    public bool IsCarryingPassword()
    {
        return carriesPassword;
    }

    public void SetCarriesPassword(bool value)
    {
        carriesPassword = value;
    }
}
