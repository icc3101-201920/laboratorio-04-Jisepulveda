﻿using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;
        private List<SpecialCard> captaincards;

        //Constructor
        public Game()
        {

        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }

        public void DecksRead ( )
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Decks.txt";

            List<Deck> decks_txt = new List<Deck>();

            int contador = 0;

            Deck deckt = new Deck();

            using (StreamReader reader = new StreamReader(path))
            {
                while (true)
                {
                    string line = reader.ReadLine() ;

                    if (line == "START")
                    {
                        Deck deckt = new Deck();
                    }
                    if (line == "END")
                    {
                        decks_txt.Add(deckt);
                    }
                    if (line == null)
                    {
                        break;
                    }
                    else
                    {
                        string[] attributes = line.Split(",");

                        int tipecard = 0;

                        foreach (string attribute in attributes)
                        {
                            tipecard++;
                        }

                        if (tipecard == 3)
                        {
                            SpecialCard specialCard = new SpecialCard(attributes[1], attributes[0], attributes[2]);
                            deckt.AddCard(specialCard);
                        }
                        if (tipecard == 5)
                        {
                            CombatCard combatcard = new CombatCard(attributes[1], attributes[0], attributes[2], Int32.Parse(attributes[3]), Boolean.Parse(attributes[4]));
                            deckt.AddCard(combatcard);
                        }
                            
                    }

                    contador++;
                    
                } 

            }

            this.decks = decks_txt;
        }
    }
}
