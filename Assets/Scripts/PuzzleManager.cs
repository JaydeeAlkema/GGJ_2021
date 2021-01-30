using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    [SerializeField] private int totalAmountOfPuzzles = 3;
    [SerializeField] private int totalPuzzleCompleted = 0;

    [SerializeField] private List<FlipButton> flipButtons = new List<FlipButton>();

    [SerializeField] private int timer = 250;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (timer > 0)
        {
            timer--;
        } 
        else
        {
            timer = 250;
            SlowUpdate();
        }
    }

    void SlowUpdate()
    {
        CheckFlipPuzzle();
    }

    private void CheckFlipPuzzle()
    {
        int amount = 0;
        for (int i = 0; i < flipButtons.Count; i++)
        {
            if (!flipButtons[i].Flipped)
            {
                amount += 1;
            }
        }
        if (amount == flipButtons.Count)
        {
            Debug.Log("Puzzle done");
        }
    }
}
