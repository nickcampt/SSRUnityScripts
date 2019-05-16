using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set_bubbles : MonoBehaviour 
{
    public mg_transition_anim transition_Anim;
    public Sprite three, two, one;
    public Text bubble1, bubble2, bubble3;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        int mg = transition_Anim.get_mg();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (mg >= 0 && mg < 3)
        {
            spriteRenderer.sprite = three;
        }
        else if (mg >= 3 && mg < 6)
        {
            spriteRenderer.sprite = two;
            bubble1.enabled = false;
            bubble2.color = new Color(1, 1, 1);
        }
        else if (mg >= 6)
        {
            spriteRenderer.sprite = one;
            bubble1.enabled = false;
            bubble2.enabled = false;
            bubble3.color = new Color(1, 1, 1);
        }
    }
}
