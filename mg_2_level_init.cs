using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mg_2_level_init : MonoBehaviour 
{
    public const int EASY = 0, MEDIUM = 1, HARD = 2;

    public score_handler handler;
    public static int game_state;

    public make_gears make_gears;

    private void Start()
    {
        game_state = handler.getDifficulty();

        if (game_state == EASY)
        {
            make_gears.gear_cap = 1;
        }
        else if (game_state == MEDIUM)
        {
            make_gears.gear_cap = 2;
        }
        else if (game_state == HARD)
        {
            make_gears.gear_cap = 4;
        }
    }
}
