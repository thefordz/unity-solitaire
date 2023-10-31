using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solitaire : MonoBehaviour
{

    public static string[] suits = new string[] {"C", "D", "H", "S"};
    public static string[] values = new string[] {"A", "1", "2", "3", "4", "5","6", "7", "8", "9", "10", "J", "Q", "K"};

    public List<string> deck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCards(){
        deck = GenerateDeck();
        Shuffle(deck);

        foreach (string card in deck)
        {
            Debug.Log(card);
        }
    }

    public static List<string> GenerateDeck(){
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s+v);
            }
        }
        return newDeck;
    }

    public void Shuffle<T>(List<T> list){
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
}
