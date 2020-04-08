using System;
using System.Collections.Generic;
using Decks;

namespace GameBoard
{
    class Board 
    {
        public List<Card> CardsPlayed;
        public Card LastCardPlayed;
        public Board(Card card){
            CardsPlayed = new List<Card>(){card};
            LastCardPlayed = card;
            Console.WriteLine("Board has been initialized!");
        }
        public bool AddToPlayPile(Card card)
        {
            // Validate the play
            if(card.Suit == LastCardPlayed.Suit || card.Val == LastCardPlayed.Val)
            {
                LastCardPlayed = card;
                CardsPlayed.Add(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void showBoard(){
            Console.WriteLine(LastCardPlayed.StringVal);
        }
    }
}