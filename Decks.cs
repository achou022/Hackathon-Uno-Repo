using System;
using System.Collections.Generic;
using GameBoard;

namespace Decks{
    class Card{
        public string StringVal;
        public string Suit;
        public int Val;
        public bool HasAction;
        public Card(string suit, int val){
            Suit=suit;
            Val=val;
            StringVal = suit + " " + val;
            if(val>9)
            {
                HasAction=true;
            }
        }
        //108 cards total
        //0(1 of each 4 colors) - 4
        //1-9(2 of each 4 colors) - 72
        //skip(2 of each 4 colors), take 2(2 of each 4 colors), reverse(2 of each 4 colors) - 24
        //choose color(4 total), choose and take 4 (4 total) - 8
        //val 0-9 -> 0-9
        //val 10, 11, 12, 13, 14 -> skip, take2, reverse, chooseColor, chooseTake4
        public void Action(Player target, Deck deck, string color)
        {
            if(Val==10)//skip
            {
                //target.SkipTurn()
            }
            if(Val==11)//take2
            {
                for(int i=0; i<2; i++)
                {
                    target.Draw(deck);
                }
            }
            if(Val==12)//reverse
            {
                //GameBoard.ChangeDirection()
            }
            if(Val==13)//choseColor
            {
                //GameBoard.ActiveColor = color;
            }
            if(Val==14)//choseTake4
            {
                //GameBoard.ActiveColor = color;
                for(int i=0; i<4; i++)
                {
                    target.Draw(deck);
                }
            }
        }
    }

    class Deck{
        public List<Card> Cards{get; set;}

        public Deck(){
            Cards=setDeck();
            Console.WriteLine("New deck has been built!");
        }

        public List<Card> setDeck(){
            List<string> suites = new List<string>{"Red", "Blue", "Green", "Yellow"};
            List<Card> deck = new List<Card>();
            foreach (string suite in suites)
            {
                for(int i = 0; i <= 9; i++){
                    deck.Add(new Card(suite, i));
                    if(i != 0){
                        deck.Add(new Card(suite, i));
                    }
                }
            }
            return deck;
        }

        public Card Deal(){
            Card target = Cards[0];
            Cards.Remove(Cards[0]);
            Console.WriteLine("Dealing card...");
            return target;
        }

        public void Reset(){
            Console.WriteLine("reseting the deck...");
            Cards=setDeck();
        }

        public void Shuffle(){
            List<Card> shuffled = new List<Card>();
            Random rand = new Random();
            Console.WriteLine("Shuffling.......");
            while(Cards.Count != 0){
                int selected = rand.Next(Cards.Count);
                shuffled.Add(Cards[selected]);
                Cards.RemoveAt(selected);
            }
            Cards=shuffled;
        }
    }
    class Player{
        public string Name;
        public List<Card> hand;
        public Player(string name){
            Name = name;
            hand = new List<Card>();
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
    }
}