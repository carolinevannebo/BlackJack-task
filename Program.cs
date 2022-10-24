// See https://aka.ms/new-console-template for more information

namespace DeckOfCards
{
    class Program
    {
        public static void Main(string[] args)
        {
            int playerCardValue = 0;
            int dealerCardValue = 0;

            Random random = new Random();

            playerCardValue += random.Next(1, 12); //Random number from 1-11
            playerCardValue += random.Next(1, 12); //Random number from 1-11

            if (playerCardValue > 21) //If you get 20 you win, and you start with A or 8
            {
                playerCardValue -= 10;
            }

            dealerCardValue += random.Next(1, 12);
            dealerCardValue += random.Next(1, 12);

            if (dealerCardValue > 21)
            {
                dealerCardValue -= 10;
            }

            //Players turn
            while (true)
            {
                if (playerCardValue == 21)
                {
                    Console.WriteLine("You are at 21!!");
                    break;
                }

                Console.WriteLine("My Card Value: " + playerCardValue.ToString() + " Hit? y/n");
                string? answer = Console.ReadLine();

                if (answer == "y")
                {
                    playerCardValue += random.Next(1, 12); //Random card value between 1-11

                    if (playerCardValue > 21)
                    {
                        Console.WriteLine("You Busted!");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (answer == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect response, try again");
                    continue;
                }
            }

            //Dealers turn

            Console.WriteLine("Players card value is " + playerCardValue.ToString());

            if (playerCardValue <= 21)
            {
                //Player has not busted
                while (dealerCardValue < 21 && dealerCardValue < playerCardValue)
                {
                    dealerCardValue += random.Next(1, 12);
                }

                //check for winner
                if (playerCardValue == dealerCardValue)
                {
                    Console.WriteLine("Player and dealer have tied");
                }
                else if (playerCardValue < dealerCardValue && dealerCardValue <= 21)
                {
                    Console.WriteLine("Dealer has won");
                }
                else if (dealerCardValue > 21)
                {
                    Console.WriteLine("Dealer has busted, player has won!");
                }
                else if (dealerCardValue == 21)
                {
                    Console.WriteLine("Dealer has won!");
                }
            }
            else
            {
                Console.WriteLine("Dealer has won, player has busted");
            }

            Console.WriteLine("Dealers Value: " + dealerCardValue.ToString());
            Console.ReadLine();
        }
    }
}