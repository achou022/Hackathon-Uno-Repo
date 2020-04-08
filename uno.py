from random import randint


class Card():

    def __init__(self, suit, value):
        self.suit = suit
        self.value = value
        # if value == 1:
        #     self.rank = 'Ace'
        # elif value == 11:
        #     self.rank = 'Jack'
        # elif value == 12:
        #     self.rank = 'Queen'
        # elif value == 13:
        #     self.rank = 'King'
        # else:
        #     self.rank = str(value)

    # def greater_than(self, other_card):
    #     return self.value > other_card.value

    # def __repr__(self):
    #     return(f"{self.rank} of {self.suit}")


class Deck():

    def __init__(self):
        self.suits = ['Red', 'Blue', 'Green', 'Yellow']
        self.values = [0,1, 2, 3, 4, 5, 6, 7, 8, 9]
        self.contents = []

        for suit in self.suits:
            for value in self.values:
                self.contents.append(Card(suit, value))
        self.shuffle_deck()

    def shuffle_deck(self):
        for i in range(0, len(self.contents)):
            x = randint(0, len(self.contents) - 1)
            self.contents[i], self.contents[x] = self.contents[x], self.contents[i]

    def deal_top_card(self):
        if len(self.contents) > 0:
            return self.contents.pop(0)
        else:
            print('Deck is empty!')
            return None

    def add_to_bottom(self, card):
        self.contents.append(card)

    def add_to_top(self, card):
        self.contents.insert(0, card)

class Board:
    def __init__(self, card):
        self.card=card

    def showBoard(self):
        print('-'*20,'Board:', self.card.suit, self.card.value,'-'*20)

    def updateBoard(self, card):
        self.card=card
        return self


class Hand:
    def __init__(self):
        self.hand=[]
        self.handCount=len(self.hand)
    
    def playCard(self, i): ##tested to work
        return self.hand.pop(i)

    def add2Hand(self, card):
        self.hand.append(card)
        return self
    def showHand(self):
        for i in range(len(self.hand)):
            print("Card Number",i, ':', self.hand[i].suit, self.hand[i].value)


if __name__ == "__main__":
    # A game where it picks a random card, and you have to guess the actual card.
    playing = True
    #initialize deck and board
    deck = Deck()
    deck.shuffle_deck()
    startingCard = deck.deal_top_card()
    board=Board(startingCard)
    #intialize player
    player = Hand()#initialize player's hand
    player.add2Hand(deck.deal_top_card()) #times six
    player.add2Hand(deck.deal_top_card())
    player.add2Hand(deck.deal_top_card())
    player.add2Hand(deck.deal_top_card())
    player.add2Hand(deck.deal_top_card())
    player.showHand()
    playerTurn = True
    #intialize computer
    print('computer hand','-'*10)
    computer=Hand()
    computer.add2Hand(deck.deal_top_card())#initial draw six
    computer.add2Hand(deck.deal_top_card())
    computer.add2Hand(deck.deal_top_card())
    computer.add2Hand(deck.deal_top_card())
    computer.add2Hand(deck.deal_top_card())
    computer.add2Hand(deck.deal_top_card())
    computer.showHand()
    compPlayedCard=False
    #start game prompt
    print("Let's play UNO!")
    board.showBoard()

    while playing==True:
        print('game loop')
        # while playerTurn==True:
        #     print('player loop')
        #     print('Which card will you play?')
        #     # userCard=input()
        #     # if(userCard<player.handCount):
        #     #     print('not playable card')
        #     #     userCard=input()


        print('computer loop')
        i=0
        for i in range(0,len(computer.hand),1):
            print('computer looking at card', i)
            if(computer.hand[i].suit==board.card.suit or computer.hand[i].value==board.card.value):
                print('computer found playable card:', computer.hand[i].suit, computer.hand[i].value)
                board.updateBoard(computer.playCard(i))
                board.showBoard()
                i=len(computer.hand)+1
                compPlayedCard=True
        print(compPlayedCard)
        if(compPlayedCard!=True):
            computer.add2Hand(deck.deal_top_card)
            print('computer could not play card')
            compPlayedCard=True