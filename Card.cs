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
}