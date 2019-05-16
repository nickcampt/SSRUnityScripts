using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mg_3_level_init : MonoBehaviour 
{
    public const int EASY = 0, MEDIUM = 1, HARD = 2;

    public score_handler handler;
    public static int game_state;

    public GameObject laser2, laser3, laser4;

    private void Start()
    {
        game_state = handler.getDifficulty();

        if (game_state == EASY)
        {
            // nothing
        }
        else if (game_state == MEDIUM)
        {
            laser2.SetActive(true);
        }
        else if (game_state == HARD)
        {
            laser2.SetActive(true);
            laser3.SetActive(true);
            //laser4.SetActive(true);
        }

        if (game_state != HARD)
        {
            handler.increaseDifficulty();
        }
    }
}
