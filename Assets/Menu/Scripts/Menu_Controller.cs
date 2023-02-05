using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GGJ
{
    public class Menu_Controller : MonoBehaviour
    {
        [Header("General Options")]
        [SerializeField] GameObject mainScreen;
        [SerializeField] GameObject optionsMenu;
        [SerializeField] float timeOptions;

        [Header("Menu Elements")]
        [SerializeField] Image Play;
        [SerializeField] Image Options;
        [SerializeField] Image Quit;

        [Header("Sprites png")] 
        [SerializeField] Sprite Play_Off;
        [SerializeField] Sprite Play_On;
        [SerializeField] Sprite Options_Off;
        [SerializeField] Sprite Options_On;
        [SerializeField] Sprite Quit_Off;
        [SerializeField] Sprite Quit_On;

        [Header("Sounds")]
        [SerializeField] AudioSource snd_Options;
        [SerializeField] AudioSource snd_Selection;

        [Header("Scripts")]
        [SerializeField] GameObject settingsScreenScripts;


        bool screen = true;
        int optionMenu, optionMenuBe;
        bool submit;
        float vertical;
        float verticalTime;
        // Start is called before the first frame update
        void Awake()
        {
            screen = true;
            verticalTime  = 0;
            optionMenu = optionMenuBe = 1;
        }

        // Update is called once per frame
        void Update()
        {
            vertical = Input.GetAxisRaw("Vertical");
            if (Input.GetButtonUp("Submit")) submit = false;
            if (vertical == 0) verticalTime = 0;
            

        }

         

        
        void loadOptionsMenu()
        {
            
        }
        void menuSelection(int op)
        {
            
        }
       
    }

}
