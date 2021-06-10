﻿using CIK.Assignment10.Bingo.Game;
using CIK.Assignment10.Bingo.Game.Services;
using System;

namespace CIK.Assignment10.Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new RandomNumberGenerator();
            var cardWidth = 5;
            var cardLength = 5;
            var game = new BingoGame(cardLength, cardWidth, rng, new BingoBankService(rng, cardLength * cardWidth), new BingoCardService(rng));
            game.NewGame();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Pulling new number from bank...");
                game.NextRound();

                foreach (var row in game.bingoCard)
                {
                    foreach (var cell in row)
                    {
                        Console.Write(cell.isChecked ? "X".PadLeft(3) : cell.Value.PadLeft(3));
                    }
                    Console.WriteLine();
                }

            } while (!game.IsBingo());
        }
    }
}
