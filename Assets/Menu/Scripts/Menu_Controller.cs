using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

namespace GGJ
{
    public class Menu_Controller : MonoBehaviour
    {
        [Header("General Options")]
        [SerializeField] GameObject menuScreen;
        [SerializeField] GameObject optionsMenu;
        [SerializeField] float timeOptions;

        [Header("Menu Elements")]
        [SerializeField] SpriteRenderer Play;
        [SerializeField] SpriteRenderer Options;
        [SerializeField] SpriteRenderer Quit;

        [Header("Sprites png")] 
        [SerializeField] Sprite Play_Off;
        [SerializeField] Sprite Play_On;
        [SerializeField] Sprite Options_Off;
        [SerializeField] Sprite Options_On;
        [SerializeField] Sprite Quit_Off;
        [SerializeField] Sprite Quit_On;


        int screen;
        int optionMenu, optionMenuBe;
        bool submit;
        float vertical, horizontal;
        float verticalTime, horizontalTime;
        // Start is called before the first frame update
        void Awake()
        {
            screen = 0;
            verticalTime = horizontalTime = 0;
            optionMenu = optionMenuBe = 1;
            AdjustOptions();
        }

        // Update is called once per frame
        void Update()
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonUp("Submit")) submit = false;
            if (vertical == 0) verticalTime = 0;
            if (screen == 0) mainMenu();

        }

        void AdjustOptions() 
        {

        }
         void mainMenu()
        {
            if( vertical != 0)
            {
                if(verticalTime == 0 || verticalTime > timeOptions)
                {
                    if (vertical == 1 && optionMenu > 1) menuSelection(optionMenu - 1);
                    if (vertical == -1 && optionMenu < 3) menuSelection(optionMenu + 1);
                    if (verticalTime > timeOptions) verticalTime = 0;
                }
                verticalTime += Time.deltaTime;
            }
        }
        void menuSelection(int op)
        {
            optionMenu = op;
            if (op == 1) Play.sprite = Play_On;
            if (op == 2) Options.sprite = Options_On;
            if (op == 3) Quit.sprite = Quit_On;
            if (optionMenuBe == 1) Play.sprite = Play_Off;
            if (optionMenuBe == 2) Options.sprite = Options_Off;
            if (optionMenuBe == 3) Quit.sprite = Quit_Off;
            optionMenuBe = op;
        }
    }
}
