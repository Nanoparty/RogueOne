using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private int state = 1;
    public Button right;
    public Button left;
    public Button play;
    public Text gold;
    public Text cost;
    int character = 0;
    public Sprite[] characters;
    private Sprite curChar;
    public Image displayChar;
    public int[] costs = new int[] { 500, 600, 700, 800 };

    public GameObject menu1;
    public GameObject menu2;


    int Gold = 1000;
    int Cost = 100;

    // Start is called before the first frame update
    void Start()
    {
        gold.text = "Gold: " + Gold;
        cost.text = "Cost: " + costs[character];
        
        curChar = characters[character];
        displayChar.sprite = characters[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 1)
        {
            menu2.SetActive(false);
            if (Input.touchCount > 0 || Input.GetKeyDown("space"))
            {
                state = 2;
                menu1.SetActive(false);
                menu2.SetActive(true);

            }
        }
    }

    public void rightArrow() {
        if(character < characters.Length-1 && state == 2)
        {
            Debug.Log("Right");
            character++;
            displayChar.sprite = characters[character];
            cost.text = "Cost: " + costs[character];
        }
    }

    public void leftArrow()
    {
        if(character > 0 && state == 2)
        {
            Debug.Log("Left");
            character--;
            displayChar.sprite = characters[character];
            cost.text = "Cost: " + costs[character];
        }
    }

    public void playGame()
    {
        if (costs[character] <= Gold)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            
        }
    }
}
