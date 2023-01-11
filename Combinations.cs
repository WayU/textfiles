using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Combinations : MonoBehaviour
{

    public Text text;
    
    // Interval time between input presses
    public float interval = 0.2f;

    // List of possible correct combination sequences
    List<int[]> correctSequences = new List<int[]>();

    // Current combination sequence
    List<int> currentSequence = new List<int>();

    // Timer for interval
    float timer;

    void Start()
    {
        // Add correct sequences to the list
        correctSequences.Add(new int[] { 1, 2, 3 });
        correctSequences.Add(new int[] { 2, 1, 4 });
        correctSequences.Add(new int[] { 3, 2, 1 });
        correctSequences.Add(new int[] { 1, 2, 3, 4 });
    }

    void Update()
    {
        // Decrement timer
        timer -= Time.deltaTime;


        // Check if timer has run out
        if (timer <= 0)
        {
            // Check if current sequence matches any correct sequence
            int matches = 0;
            for (int i = 0; i < correctSequences.Count; i++)
            {
                int[] correctSequence = correctSequences[i];

                if (currentSequence.Count >= correctSequence.Length)
                {
                    bool match = true;
                    for (int j = 0; j < correctSequence.Length; j++)
                    {
                        if (currentSequence[j] != correctSequence[j])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        // Activated desired outcome
                        text.text ="Correct combination " + (i+1) + " entered!";
                        currentSequence.Clear();
                        matches++;
                    }
                }
            }
            if(matches == 0 && timer == 0.01f)
            {
                text.text ="Incorrect Combination";
                currentSequence.Clear();
            }
            // Reset current sequence and timer
            currentSequence.Clear();
            timer = 0;
        }
    }

    public void Up()
    {
        currentSequence.Add(1);
        timer = interval;
    }

    public void Down()
    {
        currentSequence.Add(2);
        timer = interval;
    }

    public void Left()
    {
        currentSequence.Add(3);
        timer = interval;
    }

    public void Right()
    {
        currentSequence.Add(4);
        timer = interval;
    }

}
