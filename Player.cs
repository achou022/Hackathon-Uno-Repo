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
            Console.WriteLine($"{Name} draws a card...");
            Card drew = deck.Deal();
            hand.Add(drew);
            return drew;
        }

        public Card PlayCard(string strIndx, Deck deck, Board board, Player targetPlayer){
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
                Console.WriteLine($"*****{Name} played {target.Suit} {target.Val}*****");
                if(board.AddToPlayPile(target))
                {
                    hand.Remove(target);
                    if(target.HasAction)
                    {
                        if(target.ReqColorInput)
                        {
                        Console.WriteLine("pick your color");
                        string color = Console.ReadLine();
                        target.Action(targetPlayer, deck, board, color);
                        }
                        else
                        {
                        target.Action(targetPlayer, deck, board);
                        }
                        
                    }
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
        public Card NPCPlayCard(Card toPlay, Deck deck, Board board, Player targetPlayer){
            Card target = toPlay;
            Console.WriteLine($"{Name} played a card {target.Suit} {target.Val}");
            if(board.AddToPlayPile(target))
            {
                hand.Remove(target);
                if(target.HasAction)
                {
                    if(target.ReqColorInput)
                    {
                    Random rand = new Random();
                    //"Red", "Blue", "Green", "Yellow"
                    string[] AvailableColors = new string[]{"Red", "Blue", "Green", "Yellow"};
                    string color = AvailableColors[rand.Next(0,AvailableColors.Length)];
                    target.Action(targetPlayer, deck, board, color);
                    }
                    else
                    {
                    target.Action(targetPlayer, deck, board);
                    }
                    
                }
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
            Console.WriteLine($"====={Name}'s hand=====");
            int index = 0;
            foreach (Card playerCard in hand)
            {
                Console.WriteLine(index + ": " + playerCard.Suit + " " + playerCard.Val + " ------cardType:" + playerCard.FancyCardStuff);
                index ++;
            }
            Console.WriteLine($"=====Card Count {hand.Count} =====");
        }
    }
}