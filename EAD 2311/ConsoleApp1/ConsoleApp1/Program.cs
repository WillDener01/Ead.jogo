using System;


class Program
{
    static void Main()
    {
        Console.WriteLine(" - - - > A BATALHA DE SULIEAD < - - - ");

        IPersonagem jogador1 = new Mago("Mago");
        IPersonagem jogador2 = new Guerreiro("Guerreiro");

        bool turnoDoJogador1 = true;

        while (jogador1.Vida > 0 && jogador2.Vida > 0)
        {
            Console.WriteLine("\n-------------------------------------");

            if (turnoDoJogador1)
            {
                int dano = jogador1.Atacar(jogador2);
                Console.WriteLine($"{jogador1.Nome} atacou causando {dano} de dano!");
                Console.WriteLine($"{jogador2.Nome} ficou com {jogador2.Vida} de vida.");
            }
            else
            {
                int dano = jogador2.Atacar(jogador1);
                Console.WriteLine($"{jogador2.Nome} atacou causando {dano} de dano!");
                Console.WriteLine($"{jogador1.Nome} ficou com {jogador1.Vida} de vida.");
            }

            
             if (turnoDoJogador1)
                turnoDoJogador1 = false;
           else
                turnoDoJogador1 = true;
            
            System.Threading.Thread.Sleep(800); //Sulivan esse comando acho que vc n passou, mas como eu n lembrava tive que pesquisar como que fazia ent usei esse. 
        }

        Console.WriteLine("\n=====================================");

        if (jogador1.Vida <= 0)
            Console.WriteLine($"{jogador2.Nome} venceu a batalha!");
         else
            Console.WriteLine($"{jogador1.Nome} venceu a batalha!");

        Console.WriteLine("=====================================");
    }
}



public interface IPersonagem
{
    string Nome { get; }
    int Vida { get; set; }
    int Ataque { get; }
    int Defesa { get; }

    int Atacar(IPersonagem alvo);
}

public class Mago : IPersonagem
{
    public string Nome { get; private set; }
    public int Vida { get; set; }
    public int Ataque { get; private set; }
    public int Defesa { get; private set; }

    public Mago(string nome)
    {
        Nome = nome;
        Vida = 100;
        Ataque = 25;
        Defesa = 10;
    }

    public int Atacar(IPersonagem alvo)
    {
        int dano = Ataque - alvo.Defesa;
        if (dano < 0) dano = 0;

        alvo.Vida -= dano;
        if (alvo.Vida < 0) alvo.Vida = 0;

        return dano;
    }
}

public class Guerreiro : IPersonagem
{
    public string Nome { get; private set; }
    public int Vida { get; set; }
    public int Ataque { get; private set; }
    public int Defesa { get; private set; }

    public Guerreiro(string nome)
    {
        Nome = nome;
        Vida = 120;
        Ataque = 20;
        Defesa = 15;
    }

    public int Atacar(IPersonagem alvo)
    {
        int dano = Ataque - alvo.Defesa;
        if (dano < 0) dano = 0;

        alvo.Vida -= dano;
        if (alvo.Vida < 0) alvo.Vida = 0;

        return dano;
    }
}


