// File: GameState.cs
using System;
using System.Collections.Generic;

namespace O_Neillo_Game
{
    public class GameState
    {
        public List<GameSnapshot> SavedGameStates { get; private set; }

        public GameState()
        {
            SavedGameStates = new List<GameSnapshot>();
            Reset();
        }

        public GameSnapshot CurrentSnapshot
        {
            get
            {
                if (SavedGameStates.Count > 0)
                    return SavedGameStates[SavedGameStates.Count - 1];
                else
                    return null;
            }
        }

        public void Reset()
        {
            // Initialize starting positions on the game board
            int[,] initialBoard = new int[8, 8]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            GameSnapshot initialSnapshot = new GameSnapshot
            {
                Player1Name = "Player 1",
                Player2Name = "Player 2",
                Board = initialBoard,
                CurrentPlayer = 1
            };

            // Clear existing snapshots and add the initial one
     
            SavedGameStates.Add(initialSnapshot);

        }
    }

    public class GameSnapshot
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int[,] Board { get; set; }
        public int CurrentPlayer { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
