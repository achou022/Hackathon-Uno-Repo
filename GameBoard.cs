using System;
using System.Collections.Generic;
using Decks;

namespace GameBoard
{
    class Board 
    {
        public List<Card> CardsPlayed = new List<Card>();
        public Card LastCardPlayed;
        public string ActiveSuit;
        public bool AddToPlayPile(Card card)
        {
            // Validate the play
            if(card.Suit == ActiveSuit || card.Val == LastCardPlayed.Val || card.Val>=13)
            {
                LastCardPlayed = card;
                ActiveSuit = card.Suit;
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