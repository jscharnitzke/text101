using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Text101/State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string storyText;
    [SerializeField] string optionText;
    [SerializeField] string condition;
    [SerializeField] string reward;
    [SerializeField] string consumedItem;
    [SerializeField] State[] nextStates;

    private Player player;

    public State init(Player player)
    {
        if (!string.IsNullOrEmpty(reward))
        {
            player.addToInventory(reward);
        }

        if (!string.IsNullOrEmpty(consumedItem))
        {
            player.removeFromInventory(consumedItem);
        }

        return this;
    }

    public string getCondition()
    {
        return condition;
    }

    public string getStoryText(Player player)
    {
        this.player = player;
        return buildDisplayText(player);
    }

    public string getOptionText()
    {
        return optionText;
    }

    public bool conditionIsMet(Player player)
    {
        return string.IsNullOrEmpty(condition) || player.inventoryContains(condition);
    }

    public State[] getNextStates(Player player)
    {
        return nextStates.Where(state => state.conditionIsMet(player)).ToArray();
    }

    private string buildDisplayText(Player player)
    {
        string displayText = storyText;

        if (this.nextStates.Length > 0)
        {
            displayText += "\n\nWhat do you do?\n";
        }

        int optionNumber = 1;

        foreach (State state in nextStates)
        {
            if (!state.conditionIsMet(player))
            {
                continue;
            }

            displayText += $"{optionNumber++}) {state.getOptionText()}\n";
        }

        return displayText;
    }
}
