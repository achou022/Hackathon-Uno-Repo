using System;
using System.IO;
using Decks;

namespace hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck uno = new Deck();
            uno.Shuffle();
            printDeck(uno);
            // setting up game
            Console.Write("What's your name player...? ");
            string name = Console.ReadLine();
            Player player = new Player(name);
            Player computer = new Player("Computer");
            // set board with one card from deck board.play(uno.Deal());
            for(int i = 0; i < 7; i++){
                player.Draw(uno);
                computer.Draw(uno);
            }
            // game loop
            bool playing = true;
            bool turn = true;
            while(playing){
                // game logic
                // playing = false;
                while(turn){
                    Console.Write("What card would you like to play? ");
                    string cardIndx = Console.ReadLine();
                    // player action
                    if(player.hand.Count==1){
                        string win = Console.ReadLine();
                        if(win != "Uno"){
                            player.Draw(uno);
                        }
                        playing = false;
                    }
                    if(player.hand.Count==0){
                        Console.WriteLine("You Won!!!");
                        playing = false;
                    }
                    turn = false;
                }
                // computer logic
                // bool played = false;
                // foreach (Card card in computer.hand)
                // {
                //     if(card.Suit==board.card.Suit || card.Val==board.card.Val){
                //         computer.play(card);
                //         bool played=true;
                //         if(computer.hand.Count==0){
                //             playing = false;
                //             Console.WriteLine("Computer has Won, you lost!");
                //         }
                //     }
                // }
                // if(!played){
                //     computer.Draw(uno);
                // }
                turn = true;
            }
            Console.WriteLine("game over...");
        }
        public static void printDeck(Deck deck){
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.StringVal);
            }
        }
    }
}
