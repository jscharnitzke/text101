using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string storyText;
    [SerializeField] string optionText;
    [SerializeField] State[] nextStates;

    public string getStoryText()
    {
        return buildDisplayText();
    }

    public string getOptionText()
    {
        return optionText;
    }

    public State[] getNextStates()
    {
        return nextStates;
    }

    private string buildDisplayText()
    {
        string displayText = storyText + "\n\nWhat do you do?\n";

        for (int i = 0; i < nextStates.Length; i++)
        {
            displayText += $"{i + 1}) {nextStates[i].getOptionText()}\n";
        }

        return displayText;
    }
}
