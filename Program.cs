using System;
using System.IO;
using System.Collections.Generic;
using Decks;
using GameBoard;

namespace hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck uno = new Deck();
            uno.Shuffle();
            // printDeck(uno);
            // setting up game
            Console.Write("What's your name player...? ");
            // string name = Console.ReadLine();
            Player player = new Player("Stevie Unoman");
            Player computer = new Player("Computer");
            Board board = new Board(uno.Deal());
            board.showBoard();
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
                    if(player.IsSkipped)
                    {
                        player.SkipPlayer();
                        turn=false;
                    }
                    Console.WriteLine("The last card played was: ");
                    board.showBoard();
                    player.ShowHand();
                    Console.WriteLine("What would you like to do?");
                    string input = Console.ReadLine();

                    if(input.ToLower() == "quit")
                    {
                        Console.WriteLine("Goodbye!");
                        playing = false;
                    }
                    else if(input.ToLower() == "draw")
                    {
                        player.Draw(uno);
                    }
                    else
                    {
                        var playerAction = player.PlayCard(input, uno, board, computer);
                        if (playerAction == null)
                        {
                            while (playerAction == null)
                            {
                                input = Console.ReadLine();
                                playerAction = player.PlayCard(input, uno, board, computer);
                            }
                        }
                    }
                    if(player.hand.Count==1)
                    {
                        string callout = Console.ReadLine();
                        if(callout.ToLower() != "uno" || callout.ToLower() != "uno!")
                        {
                            Console.WriteLine("You forgot to say 'Uno'!");
                            player.Draw(uno);
                        }
                    }
                    if(player.hand.Count==0){
                        Console.WriteLine("You Won!!!");
                        playing = false;
                        break;
                    }
                    turn = false;
                }
                // computer logic
                bool NPCplayed = false;
                Console.WriteLine("Printing Computer's Hand, that's cheating!");
                computer.ShowHand();

                


                foreach (Card card in computer.hand)
                {
                    if(card.Suit==board.LastCardPlayed.Suit || card.Val==board.LastCardPlayed.Val){
                        computer.NPCPlayCard(card, uno, board, player);
                        NPCplayed=true;
                        if(computer.hand.Count==0){
                            playing = false;
                            Console.WriteLine("Computer has Won, you lost!");
                        }
                        break;
                    }
                }
                if(!NPCplayed){
                    computer.Draw(uno);
                }
                Console.WriteLine("Computer ended turn..");
                turn = true;
            }
            Console.WriteLine("Game Over");
        }
        public static void printDeck(Deck deck){
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.StringVal);
            }
        }
    }
}
