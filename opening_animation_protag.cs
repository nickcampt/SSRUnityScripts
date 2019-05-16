using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opening_animation_protag : MonoBehaviour {
	
    public GameObject gameicon; 
    public GameObject character;
    public GameObject text;
    public GameObject contText;
    bool moveUp = false;
    bool speak = false;
    float targetHeight = -0.4f; 
    float startHeight = -1.2f;
    float currentHeight;
    float startText = -460f;
    float finishText = 100f;
    float currentText;
    float lerpage = 0;
    float timer = 0;
	// Update is called once per frame

    void Start() {
        character.GetComponent<SpriteRenderer>().enabled = false;
        text.GetComponent<Text>().text = "";
        contText.SetActive(false);
    }

	void Update() {
		if (gameicon.GetComponent<logo_spin_animation>().getDone() == true) {
            moveUp = true;
            character.GetComponent<SpriteRenderer>().enabled = true;
            text.GetComponent<Text>().text = "'Can you help me open my locker? The combo is 30 - 35 - 45'";
        }
        if (moveUp == true) {
            currentHeight = Mathf.Lerp(startHeight, targetHeight, lerpage);
            currentText = Mathf.Lerp(startText, finishText, lerpage);
            var charTransform = character.GetComponent<Transform>();
            charTransform.position = new Vector3(charTransform.position.x, currentHeight, charTransform.position.z);
            var textTransform = text.GetComponent<RectTransform>();
            textTransform.position = new Vector3(textTransform.position.x, currentText, textTransform.position.z);
            lerpage += Time.deltaTime * 0.4f;
            if (lerpage >= 1) {
                moveUp = false;

            }
            timer+=Time.deltaTime;
            if (timer > 4) {
                contText.SetActive(true);
            }
        }

        if (Input.GetKey("space")) {
            Application.LoadLevel("opening_scene2");
        }


	}

}
