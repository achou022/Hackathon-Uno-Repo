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
            int indx;
   
            // convert strIndx to int and pass to indx
            bool inputIsNumber = Int32.TryParse(strIndx, out indx);
            if (inputIsNumber)
            {
                if(indx>hand.Count || indx<0)
                {
                    Console.WriteLine("Please pick a card within your hand size.");
                    return null;
                }
                Card target = hand[indx];
                Console.WriteLine($"{Name} played a card {target.Suit} {target.Val}");
                if(board.AddToPlayPile(target))
                {
                    hand.Remove(target);
                    return target;
                }
                else
                {
                    Console.WriteLine("That isn't a valid play, please pick another card.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("That isn't a card index, please pick from one of the numbers listed next to your cards!");
                return null;
            } 
        }
        public Card NPCPlayCard(Card toPlay, Board board){
            Card target = toPlay;
            Console.WriteLine($"{Name} played a card {target.Suit} {target.Val}");
            if(board.AddToPlayPile(target))
            {
                hand.Remove(target);
                return target;
            }
            else
            {
                Console.WriteLine("That isn't a valid play, please pick another card.");
                return null;
            }
        }

        public void SkipPlayer()
        {
            Console.WriteLine($"{Name} has been skipped!");
            IsSkipped = false;
        }

        public void ShowHand()
        {
            Console.WriteLine($"{Name}'s hand contains the following: ");
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