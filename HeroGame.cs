 using System;

namespace HeroGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Random numberRandom = new Random();
            int enemy = numberRandom.Next(1, 4);
            bool winCondition = true;


            Console.WriteLine("Elija uno de los siguientes heroes!");
            Console.WriteLine("Guerrero: 10 puntos de ataque y 50 puntos de vida");
            Console.WriteLine("Mago: 15 puntos de ataque y 30 puntos de vida");
            Console.WriteLine("Picaro: 20 puntos de daño y 20 puntos de vida");
            string heroe = Console.ReadLine();

            SelectCharacter(heroe.ToLower());
            Console.WriteLine("Pulsa ENTER para continuar");
            Console.ReadLine();
            Hero Player = GeneratePlayer(heroe);
            Hero Enemy = GenerateRandomEnemy(enemy);
            while (winCondition)
            {
                Console.Clear();
                
                Console.WriteLine(Player.health + " ");
                Console.SetCursorPosition(5,0);
                Console.WriteLine(Enemy.health + " ");
                Console.WriteLine("Turno del jugador, aprete ENTER para continuar");
                Player.Attack(Player, Enemy);
                Console.ReadKey();
                if (Enemy.health < 0)
                {
                    Console.SetCursorPosition(5, 0);
                    Console.WriteLine(Enemy.health + " ");
                    Console.SetCursorPosition(0,3);
                    Console.WriteLine("El jugador gano!");
                    winCondition = false;
                    break;
                }
                Console.SetCursorPosition(5, 0);
                Console.WriteLine(Enemy.health + " ");
                Console.WriteLine("Turno del enemigo, aprete ENTER para continuar");
                Console.ReadKey();
                Enemy.Attack(Enemy,Player);
                if (Player.health < 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(Player.health + " ");
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("El jugador perdio!");
                    winCondition = false;
                    break;
                }              
            }
        }      

        static public void SelectCharacter(string _hero)
        {
            if (_hero == "guerrero")
            {
                Console.WriteLine("Haz elegido Guerrero");
            }
            else if (_hero == "mago")
            {
                Console.WriteLine("Haz elegido Mago");
            }
            else if (_hero == "picaro")
            {
                Console.WriteLine("Haz elegido Picaro");
            }
            else
            {
                Console.Write("Escriba una clase valida: ");
                _hero = Console.ReadLine();
                SelectCharacter(_hero.ToLower());
                
            }
        }

        static public Hero GeneratePlayer(string _hero)
        {
            Random dg = new Random();
            int ad = dg.Next();

            if (_hero == "guerrero")
            {
                return new Warrior();
            }
            else if (_hero == "mago")
            {
                return new Wizard();
            }
            else
            {
                return new Rogue();
            }


        }

        static Hero GenerateRandomEnemy(int enemy)
        {
            Random dg = new Random();
            int ad = dg.Next();
            

            if (enemy == 1)
            {
                 return new Warrior();
            }
            else if (enemy == 2)
            {
                return new Wizard();
            }
            else
            {
                return new Rogue();
            }
        }

       

        
    }

    class Hero
    {
        public int attackDamage;
        public int health;
        public Random dg = new Random();
        
        public Hero(int _attackDamage,int _health)
        {
            attackDamage = _attackDamage;
            health = _health;
        }

        public void Attack(Hero characterAttacking, Hero characterTakingDamage)
        {
            Random dg = new Random();
            if (dg.Next(1,5) == 1)
            {
                Console.SetCursorPosition(0,2);
                Console.WriteLine("El ataque fue debil!   ");
                characterTakingDamage.health = characterTakingDamage.health - (characterAttacking.attackDamage - dg.Next(1, 5));

            }
            else if (dg.Next(1, 5) == 5)
            {
                Console.SetCursorPosition(0, 2);
                characterTakingDamage.health = characterTakingDamage.health - (characterAttacking.attackDamage + dg.Next(1, 5));
                Console.WriteLine("El ataque fue critico!    ");
            }
            else{
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                      ");
                characterTakingDamage.health = characterTakingDamage.health - characterAttacking.attackDamage;
            }
           
        }      
    }

    class Warrior : Hero
    {
       public Warrior() : base(15,50)
        {

        }         
    }

    class Rogue : Hero
    {
        public Rogue() : base(25, 20)
        {

        }
    }

    class Wizard : Hero
    {
        public Wizard() : base(20, 30)
        {

        }
    }

   
}
