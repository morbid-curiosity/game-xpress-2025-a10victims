using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIClick : MonoBehaviour
{
    public CanvasGroup transparency;
    public GameObject button;
    public Typewriter typewriter;
    public bool inGame = false;

    private GameObject scriptParent;
    private GameObject OptionsMenu;

    void Start()
    {
        if (transparency == null && button != null)
        {
            transparency = button.GetComponent<CanvasGroup>();
        }

        if (transform.parent != null)
        {
            scriptParent = transform.parent.gameObject;

            if (transform.parent.parent != null)
            {
                Transform optionsTransform = transform.parent.parent.Find("OptionsMenu");

                if (optionsTransform != null)
                {
                    OptionsMenu = optionsTransform.gameObject;
                }
            }
        }
    }

    public void Click()
    {
        // WHICH BUTTON IS CLICKED

        if (button.name == "OptionsButtonHovered" && button.transform.parent.name != "inGameMenu")
        {
            if (scriptParent != null && OptionsMenu != null)
            {
                scriptParent.SetActive(false);
                OptionsMenu.SetActive(true);
                button.transform.gameObject.SetActive(false);
                button.transform.parent.Find("OptionsButton").gameObject.SetActive(true);
            }
        }
        else if (button.name == "OptionsButtonHovered" && button.transform.parent.name == "inGameMenu")
        {
            if (scriptParent != null && OptionsMenu != null)
            {
                scriptParent.SetActive(false);
                OptionsMenu.SetActive(true);
                button.transform.gameObject.SetActive(false);
                button.transform.parent.Find("OptionsButton").gameObject.SetActive(true);
                inGame = true;
            }
        }
        else if (button.name == "QuitButtonHovered")
        {
            Application.Quit();
            Debug.Log("Application has successfully quit.");
        }
        else if (button.name == "PlayButtonHovered")
        {
            Debug.Log("blalba");
            inGame = true;
            typewriter.playSound();
            SceneManager.LoadScene("Level1");
            //yield return new WaitForSeconds(1f);
            typewriter.StartText();
            scriptParent.SetActive(false);
            button.transform.gameObject.SetActive(false);
            button.transform.parent.Find("PlayButton").gameObject.SetActive(true);
            button.transform.parent.parent.Find("GameHUD").gameObject.SetActive(true);
            button.transform.parent.parent.Find("BlackScreenCanvas/BlackScreen").GetComponent<CanvasGroup>().alpha = 1f;


        }
        else if (button.name == "BackButtonHovered")
        {
            if (inGame)
            {
                button.transform.gameObject.SetActive(false);
                transform.parent.parent.gameObject.SetActive(false);
            }
            else
            {
                button.transform.gameObject.SetActive(false);
                transform.parent.parent.gameObject.SetActive(false);
                transform.parent.parent.parent.Find("MainMenu").gameObject.SetActive(true);
                button.transform.parent.Find("BackButton").gameObject.SetActive(true);
            }
                   
            
        }
        else if (button.name == "disableSFXisTrue")
        {
            if(transparency.GetComponent<CanvasGroup>().alpha == 0f)
            {
                transparency.GetComponent<CanvasGroup>().alpha = 1f;
                //disableSFX komanda
            }
            else
            {
                transparency.GetComponent<CanvasGroup>().alpha = 0f;
                //enableSFX komanda
            }
        }
        else if (button.name == "disableColorblindisTrue")
        {
            if (transparency.GetComponent<CanvasGroup>().alpha == 0f)
            {
                transparency.GetComponent<CanvasGroup>().alpha = 1f;
                //disableColorblind komanda
            }
            else
            {
                transparency.GetComponent<CanvasGroup>().alpha = 0f;
                //enableColorblind komanda
            }
        }
        else if (button.name == "disableBlindmodeisTrue")
        {
            if (transparency.GetComponent<CanvasGroup>().alpha == 0f)
            {
                transparency.GetComponent<CanvasGroup>().alpha = 1f;
                //disableBlindmode komanda
            }
            else
            {
                transparency.GetComponent<CanvasGroup>().alpha = 0f;
                //enableBlindmode komanda
            }
        }
        else if (button.name == "mainMenuButtonHovered")
        {
            button.transform.parent.gameObject.SetActive(false);
            transform.parent.parent.Find("MainMenu").gameObject.SetActive(true);
        }

        // source.PlayOneShot(clip);
    }
}