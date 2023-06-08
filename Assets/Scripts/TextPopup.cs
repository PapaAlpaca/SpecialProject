using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopup : MonoBehaviour
{
    [SerializeField] private GameObject textBox;

    private void Start()
    {
        StartCoroutine(seq());
    }

    public void setText(string caption, int len)
    {
        StartCoroutine(newText(caption, len));
    }

    IEnumerator seq()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<Image>().enabled = true;
        textBox.GetComponent<Text>().text = "Ugh, my head... What happened?";
        yield return new WaitForSeconds(3);
        this.GetComponent<Image>().enabled = false;
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        this.GetComponent<Image>().enabled = true;
        textBox.GetComponent<Text>().text = "I need to get out of here";
        yield return new WaitForSeconds(3);
        this.GetComponent<Image>().enabled = false;
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        StopCoroutine(seq());
    }

    IEnumerator newText(string text, int len)
    {
        StopCoroutine(seq());
        this.GetComponent<Image>().enabled = true;
        textBox.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(len);
        this.GetComponent<Image>().enabled = false;
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        StopCoroutine(newText(text, len));
    }
}
