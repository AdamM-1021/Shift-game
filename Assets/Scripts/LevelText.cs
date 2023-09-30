using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{

    public TextMeshProUGUI text;
    public GameObject textBox;
    public string displayText;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        textBox.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "PlayObj")
        {
            StartCoroutine(textDisplay());
        }
    }

    IEnumerator textDisplay()
    {
        text.text = displayText;
        textBox.SetActive (true);

        yield return new WaitForSeconds(8);

        textBox.SetActive(false);
    }
}
