using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{

    public GameObject slot1;
    private Solitaire solitaire;
    // Start is called before the first frame update
    void Start()
    {
        solitaire = FindObjectOfType<Solitaire>();
        slot1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    public void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {

                if (hit.collider.CompareTag("Deck"))
                {
                    //clicked deck
                    Deck();
                }
                else if (hit.collider.CompareTag("Card"))
                {
                    //clicked card
                    Card(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Top"))
                {
                    //clicked Top
                    Top();
                }
                else if (hit.collider.CompareTag("Bottom"))
                {
                    //clicked Bottom
                    Bottom();
                }
            }
        }
    }

    public void Deck()
    {
        //deck click actions
        Debug.Log("Click on Deck");
        solitaire.DealFromDeck();
    }
    public void Card(GameObject selected)
    {
        //card click actions
        Debug.Log("Click on Card");

        //if the card clicked on is facedown
        //if the card clicked on is not blocked
        //flip it over

        //if the card clicked on is in the deck pile with the trips
        //if it is not blocked
        //select is

        //if the card is face up
        //if there is card currently selected
        //select the card

        if (slot1 == this.gameObject)
        {
            slot1 = selected;
        }

        //if there is already a card selected (and it is not the same card)

        else if (slot1 != selected)
        {
            //if the new card is eligible to stack on the old card
            if (Stackable(selected))
            {
                //stack it
            }
            else
            {
                //select the new card
                slot1 = selected;
            }
        }

        //else if there is already a card selected and it is the same card
        //if the time iss short enough then it is a double click
        //if the card is eligible to fly up top then do it
    }
    public void Top()
    {
        //top click actions
        Debug.Log("Click on Top");
    }
    public void Bottom()
    {
        //bottom click actions
        Debug.Log("Click on Bottom");
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        //compare them to  see if they stack

        //if in the top pile must stack suited Ace to King
        if (s2.top)
        {
            if (s1.suit == s2.suit || (s1.value == 1 && s2.suit == null))
            {
                if (s1.value == s2.value + 1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else //if in the bottom pile must stack alternate colors King to Ace
        {
            if (s1.value == s2.value - 1)
            {
                bool card1Red = true;
                bool card2Red = true;

                if (s1.suit == "C" || s1.suit == "S")
                {
                    card1Red = false;
                }

                if (s2.suit == "C" || s2.suit == "S")
                {
                    card2Red = false;
                }
                if (card1Red == card2Red)
                {
                    Debug.Log("Not Stackable");
                    return false;
                }
                else
                {
                    Debug.Log("Stackable");
                    return true;
                }
            }
        }
        return false;

        
    }
}
