using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_gears : MonoBehaviour 
{
    public Transform prefab;
    public move_gear gear;
    public int collisions = 0;
    public bool changed = false;
    public static int gear_cap;

    private static int gear_count = 1;

    //private int mod_val = 3;

    public void Update()
    {
        if (changed && collisions % 2 == 0 && gear_count < gear_cap)
        {
            generate_gear();
            //mod_val *= 2;
        }
    }

    public void generate_gear()
    {
        Instantiate(prefab, new Vector2(-1.71f, 0), Quaternion.identity);
        collisions = 0;
        changed = false;
        gear_count++;
    }

    public void decrease_gear_count()
    {
        gear_count--;
    }

    public int get_gear_count()
    {
        return gear_count;
    }
}
