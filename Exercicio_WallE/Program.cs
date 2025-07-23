using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

class WallE
{
    static void Main()
    {
        string input; //Input do utilizador

        int x = 0; int y = 0; //posição inicial do Wall-E
        var pVisitada = new HashSet<(int, int)>(); //posições visitadas pelo Wall-E
        pVisitada.Add((x, y)); //Guarda a posição visitada no HashSet, caso seja nova.

        bool primeiroInput = true; //verificação de que é a primeira vez que o utilizador dá input
        int lixoInput; //Guarda as bolas de lixo que o Wall-E apanhou durante a ronda.

        while (true)
        {
            Console.WriteLine("Para onde gostarias que o Wall-E fosse? (N, S, E, O)");
            input = Console.ReadLine().ToUpper().Replace(" ", "");

            bool posicaoValida = input.All(p => p == 'N' || p == 'S' || p == 'E' || p == 'O');

            if (input.Length > 50)
            {
                Console.WriteLine("O máximo de movimentos disponiveis por ronda são, 50 movimentos.");
                continue;
            }

            if (!posicaoValida)
            {
                Console.WriteLine("O Wall-E só pode aceder ás seguintes posições: N, S, E, O.");
                continue;
            }

            lixoInput = primeiroInput ? 1 : 0;
            primeiroInput = false;

            foreach (char p in input)
            {
                if (p == 'N') y++;
                else if (p == 'S') y--;
                else if (p == 'E') x++;
                else if (p == 'O') x--;

                if (pVisitada.Add((x, y)))
                {
                    lixoInput++;
                }
            }
            Console.WriteLine("Nesta ronda o Wall-E apanhou mais " + lixoInput + " bolas de lixo.");
            Console.WriteLine("O Wall-E até agora acumulou no total: " + pVisitada.Count + " bolas de lixo.");
        }
    }
}
