using System;

namespace Creational.Pattern.Factory
{ 
    /// <summary>
    /// Çalışan Code
    /// https://code.sololearn.com/cBBFajCYPDDv
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Creater creater = new Creater();
            var xbox = creater.FactoryMethod(Games.Xbox);
            xbox.Platform();
        }
    }

    class Creater
    {
        public Game FactoryMethod(Games gameType)
        {
            Game game = null;
            switch (gameType)
            {
                case Games.Atari:
                    game = new Atari();
                    break;
                case Games.PlayStation:
                    game = new PlayStation();
                    break;
                case Games.Xbox:
                    game = new Xbox();
                    break;
            }

            return game;
        }
    }

    abstract class Game
    {
        public abstract void Platform();
    }

    class Atari : Game
    {
        public override void Platform()
        {
            Console.WriteLine("Bu oyun ATARİ platformunda çalışmaktadır.");
        }
    }

    class PlayStation : Game
    {
        public override void Platform()
        {
            Console.WriteLine("Bu oyun PS4 platformunda çalışmaktadır.");
        }
    }

    class Xbox : Game
    {
        public override void Platform()
        {
            Console.WriteLine("Bu oyun XBOX platformunda çalışmaktadır.");
        }
    }

    enum Games
    {
        Atari,
        PlayStation,
        Xbox
    }
}