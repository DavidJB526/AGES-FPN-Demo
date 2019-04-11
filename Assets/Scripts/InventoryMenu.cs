using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
            {
                throw new System.Exception("There is currently no InventoryMenu instance." +
                    " Make sure an InventoryMenu script is applied to a GameObject.");
            }
            return instance;
        }
        private set { instance = value; }
    }

    private AudioSource audioSource;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private bool IsVisible => canvasGroup.alpha > 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("There is already an instance of InventoryMenu.");
        }

        audioSource = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();   
    }

    private void Start()
    {
        HideMenu();
        StartCoroutine(WaitForAudioClip());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (IsVisible)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource.Play();
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        rigidbodyFirstPersonController.enabled = true;
        audioSource.Play();
    }

    public void ExitButton()
    {
        HideMenu();
    }

    private IEnumerator WaitForAudioClip()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.volume = originalVolume;
    }
}
