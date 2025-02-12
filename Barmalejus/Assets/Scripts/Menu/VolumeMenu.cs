using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VolumeMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject firstSelected;


    private MovePlayer movePlayer;
    private Looking look;

    void Start()
    {
        movePlayer = FindObjectOfType<MovePlayer>();
        look = FindObjectOfType<Looking>();
        menu.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleVolumeMenu();
        }
    }
    private void ToggleVolumeMenu()
    {
        // toggle menu OFF
        if(menu.gameObject.activeInHierarchy)
        {
            menu.gameObject.SetActive(false);
            movePlayer.EnableMovement();
            look.EnableLook();
            
        }
        // toggle menu ON
        else
        {
            menu.gameObject.SetActive(true);
            movePlayer.DisableMovement();
            look.DisableLook();
            EventSystem.current.SetSelectedGameObject(firstSelected);
        }
    }
}
