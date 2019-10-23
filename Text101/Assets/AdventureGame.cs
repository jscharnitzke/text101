using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        updateStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        manageState();
    }

    private void manageState()
    {
        State[] nextStates = currentState.getNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1) && nextStates.Length > 0)
        {
            currentState = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length > 1)
        {
            currentState = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length > 2)
        {
            currentState = nextStates[2];
        }

        updateStoryText();
    }

    private void updateStoryText()
    {
        textComponent.text = currentState.getStoryText();
    }
}
