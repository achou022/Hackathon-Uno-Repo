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
            // initialize deck prints welcome to uno
            Deck uno = new Deck();
            // shuffling deck logs setting up your game...
            uno.Shuffle();
            // setting up game
            Console.Write("What's your name? ");
            string name = Console.ReadLine();
            Random rand = new Random();
            Player player = new Player(name);
            Player computer = new Player("Stevie Unoman");
            Board board = new Board(uno.Deal());

            // while (InitialCard.Suit=="Black")
            // {
            //     InitialCard = uno.Deal();
            //     board.AddToPlayPile(InitialCard);
            // }
            
            board.showBoard();
            // set board with one card from deck board.play(uno.Deal());
            for(int i = 0; i < 7; i++){
                player.Draw(uno);
                computer.Draw(uno);
            }
            Console.WriteLine("=====Let the Game Begin!=====");
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
                    board.showBoard();
                    player.ShowHand();
                    Console.WriteLine("What would you like to do?");
                    // string input = Console.ReadLine();

                    // if(input.ToLower() == "quit")
                    // {
                    //     Console.WriteLine("Goodbye!");
                    //     playing = false;
                    //     break;
                    // }
                    // else if(input.ToLower() == "draw")
                    // {
                    //     player.Draw(uno);
                    //     if(uno.Cards.Count==0)
                    //     {
                    //         uno.Refill(board);
                    //     }
                    // }
                    // else
                    // {
                    Object playerAction = null;
                    // if (playerAction == null)
                    // {
                        while (playerAction == null)
                        {
                            string input = Console.ReadLine();
                            if(input.ToLower() == "quit")
                            {
                                Console.WriteLine("Goodbye!");
                                playerAction = true;
                                playing = false;
                                break;
                            }
                            if(input.ToLower() == "draw")
                            {
                                playerAction = player.Draw(uno);
                                if(uno.Cards.Count==0)
                                {
                                    uno.Refill(board);
                                }
                            }
                            else
                            {
                                playerAction = player.PlayCard(input, uno, board, computer);
                            }
                        }

                    

                    if(player.hand.Count==1)
                    {
                        string callout = Console.ReadLine();
                        if(callout.ToLower() != "uno" || callout.ToLower() != "uno!")
                        {
                            Console.WriteLine("You forgot to say 'Uno'!");
                            player.Draw(uno);
                            if(uno.Cards.Count==0)
                            {
                                uno.Refill(board);
                            }
                        }
                    }
                    if(player.hand.Count==0){
                        Console.WriteLine("You Won!!!");
                        playing = false;
                        break;
                    }
                    turn = false;
                }

                if(!playing)
                {
                    break;
                }
                // computer logic
                bool NPCplayed = false;
                bool NPCMissedUno = false; 
                // Console.WriteLine("Printing Computer's Hand, that's cheating!");
                // computer.ShowHand();
                Console.WriteLine($"{computer.Name} has {computer.hand.Count} left in hand...");


                foreach (Card card in computer.hand)
                {
                    if(card.Suit==board.LastCardPlayed.Suit || card.Val==board.LastCardPlayed.Val){
                        computer.NPCPlayCard(card, uno, board, player);
                        if(card.HasAction){
                            card.Action(player, uno, board, board.ActiveSuit);
                        }
                        NPCplayed=true;
                        if(computer.hand.Count==1)
                        {
                            double unoMissChance = rand.NextDouble();
                            if (unoMissChance > .05)
                            {
                                Console.WriteLine($"{computer.Name} says 'Uno!'");
                            }
                            else
                            {
                                NPCMissedUno = true;
                            }
                        }
                        if(computer.hand.Count==0)
                        {
                            playing = false;
                            Console.WriteLine($"{computer.Name} has Won, you lost!");
                        }
                        break;
                    }
                }
                if(!NPCplayed){
                    computer.Draw(uno);
                    if(uno.Cards.Count==0)
                    {
                        uno.Refill(board);
                    }
                }
                Console.WriteLine($"{computer.Name} ended turn..");
                if(NPCMissedUno)
                {
                    Console.WriteLine($"{computer.Name} forgot to say Uno!");
                    computer.Draw(uno);
                    if(uno.Cards.Count==0)
                    {
                        uno.Refill(board);
                    }
                    NPCMissedUno = false;
                }
                turn = true;
            }
            Console.WriteLine("=====Game Over=====");
        }
        public static void printDeck(Deck deck){
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.StringVal);
            }
        }
    }
}
