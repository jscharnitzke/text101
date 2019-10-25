using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currentState;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = ScriptableObject.CreateInstance<Player>();

        currentState = startingState.init(this.player);
        updateStoryText(this.player);
    }

    // Update is called once per frame
    void Update()
    {
        manageState();
    }

    private void manageState()
    {
        State[] nextStates = currentState.getNextStates(this.player);

        if (Input.GetKeyDown(KeyCode.Alpha1) && nextStates.Length > 0)
        {
            currentState = nextStates[0].init(this.player);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length > 1)
        {
            currentState = nextStates[1].init(this.player);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length > 2)
        {
            currentState = nextStates[2].init(this.player);
        }

        updateStoryText(this.player);
    }

    private void updateStoryText(Player player)
    {
        textComponent.text = currentState.getStoryText(this.player);
    }
}
