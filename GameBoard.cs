using System;
using System.Collections.Generic;
using Decks;

namespace GameBoard
{
    class Board 
    {
        public List<Card> CardsPlayed = new List<Card>();
        public Card LastCardPlayed;
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
    }
}