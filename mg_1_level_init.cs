using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mg_1_level_init : MonoBehaviour 
{
    public const int EASY = 0, MEDIUM = 1, HARD = 2;

    public score_handler handler;
    public static int game_state;

    public PlayerController playerController;
    public platformController platformController;

    private void Start()
    {
        game_state = handler.getDifficulty();

        if (game_state == EASY)
        {
            platformController.platformOff();
            playerController.set_spawn_times(1, 10);
        }
        else if (game_state == MEDIUM)
        {
            platformController.platformOff();
            playerController.set_spawn_times(2, 2);
           
        }
        else if (game_state == HARD)
        {
            platformController.platformOn();
            playerController.set_spawn_times(2, 5);

        }
    }
}
