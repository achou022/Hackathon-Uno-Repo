using System;
using System.Collections.Generic;
using GameBoard;

namespace Decks{

    class Deck{
        public List<Card> Cards{get; set;}

        public Deck(){
            Cards=setDeck();
            Console.WriteLine("=================");
            Console.WriteLine("=Welcome to Uno!=");
            Console.WriteLine("=================");
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
                //--------Special Cards----------------
                for (int i=10; i<13; i++)
                {
                    deck.Add(new Card(suite, i));
                    deck.Add(new Card(suite, i));
                }
                for (int i=13; i<15; i++)
                {
                    deck.Add(new Card("Black", i));
                }
            }
            return deck;
        }

        public Card Deal(){
            Card target = Cards[0];
            Cards.Remove(Cards[0]);
            // Console.WriteLine("Dealing card...");
            return target;
        }

        public void Reset(){
            Console.WriteLine("reseting the deck...");
            Cards=setDeck();
        }
        public void Refill(Board board){
            Console.WriteLine("Deck is empty! Refilling from the discard pile.");
            Cards = board.CardsPlayed;
            Card lastCard = board.LastCardPlayed;
            List<Card> newDiscardPile = new List<Card>();
            newDiscardPile.Add(lastCard);
            board.CardsPlayed = newDiscardPile;
            Shuffle();
        }

        public void Shuffle(){
            List<Card> shuffled = new List<Card>();
            Random rand = new Random();
            Console.WriteLine("Setting up your game...");
            while(Cards.Count != 0){
                int selected = rand.Next(Cards.Count);
                shuffled.Add(Cards[selected]);
                Cards.RemoveAt(selected);
            }
            Cards=shuffled;
        }
    }
}