using System;
using System.Collections.Generic;
using GameBoard;

namespace Decks{

class Player{
        public string Name;
        public List<Card> hand;
        public bool IsSkipped;
        public Player(string name){
            Name = name;
            hand = new List<Card>();
            IsSkipped=false;
            Console.WriteLine($"{Name} has been initialized!");
        }

        public Card Draw(Deck deck){
            Console.WriteLine("Player drawing card...");
            Card drew = deck.Deal();
            hand.Add(drew);
            return drew;
        }

        public Card PlayCard(string strIndx, Board board){
            int indx = 0;
            // convert strIndx to int and pass to indx
            Console.WriteLine($"Player played a card...");
            if(indx>hand.Count || indx<0){
                Console.WriteLine("Please pick a card within your hand size.");
                return null;
            }
            Card target = hand[indx];
            if(board.AddToPlayPile(target))
            {
                hand.Remove(target);
                return target;
            }
            else
            {
                return null;
            }
        }

        public void ShowHand()
        {
            Console.WriteLine("Your hand contains the following: ");
            int index = 0;
            foreach (Card playerCard in hand)
            {
                Console.WriteLine(index + ": " + playerCard.Suit + " " + playerCard.Val);
                index ++;
            }
            // Console.WriteLine("Which card would you like to play?");
        }
    }
}