using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Typewriter : MonoBehaviour
{
    public Text uiText, uiText2, uiText3, uiText4, uiText5, uiText6, uiText7, uiText8;
    public float delay = 0.05f;
    public float waitDelay = 3f;
    public GameObject button;
    public AudioSource source;
    public AudioClip clip;

    private string fullText, fullText2, fullText3, fullText4, fullText5, fullText6, fullText7, fullText8;
    private string currentText = "";
    

    void Start()
    {
        fullText = uiText.text;
        fullText2 = uiText2.text;
        fullText3 = uiText3.text;
        fullText4 = uiText4.text;
        fullText5 = uiText5.text;
        fullText6 = uiText6.text;
        fullText7 = uiText7.text;
        fullText8 = uiText8.text;
        uiText.text = "";
        uiText2.text = "";
        uiText3.text = "";
        uiText4.text = "";
        uiText5.text = "";
        uiText6.text = "";
        uiText7.text = "";
        uiText8.text = "";
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            uiText.text = currentText;
            yield return new WaitForSeconds(delay);
            
        }

        yield return new WaitForSeconds(waitDelay);
        uiText.text = "";
        currentText = "";

        for (int i = 0; i <= fullText2.Length; i++)
        {
            currentText = fullText2.Substring(0, i);
            uiText2.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);
        uiText2.text = "";
        currentText = "";

        for (int i = 0; i <= fullText3.Length; i++)
        {
            currentText = fullText3.Substring(0, i);
            uiText3.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);
        uiText3.text = "";
        currentText = "";

        for (int i = 0; i <= fullText4.Length; i++)
        {
            currentText = fullText4.Substring(0, i);
            uiText4.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);
        uiText4.text = "";
        currentText = "";

        for (int i = 0; i <= fullText5.Length; i++)
        {
            currentText = fullText5.Substring(0, i);
            uiText5.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);
        uiText5.text = "";
        currentText = "";

        for (int i = 0; i <= fullText6.Length; i++)
        {
            currentText = fullText6.Substring(0, i);
            uiText6.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);
        uiText6.text = "";
        currentText = "";

        for (int i = 0; i <= fullText7.Length; i++)
        {
            currentText = fullText7.Substring(0, i);
            uiText7.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);
        uiText7.text = "";
        currentText = "";

        //PLAY BABY SOUNDS
        yield return new WaitForSeconds(waitDelay);

        for (int i = 0; i <= fullText8.Length; i++)
        {
            currentText = fullText8.Substring(0, i);
            uiText8.text = currentText;
            yield return new WaitForSeconds(delay);

        }

        yield return new WaitForSeconds(waitDelay);

        button.GetComponent<CanvasGroup>().alpha = 0f;
        
    }

    public void StartText()
    {
        StartCoroutine(ShowText());
    }

    public void playSound()
    {
        source.PlayOneShot(clip);
    }
}



