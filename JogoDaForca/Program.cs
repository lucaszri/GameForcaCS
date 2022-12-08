using System.Text.RegularExpressions;

namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array de palavras
            var palavras = new[]
            {
                "leite",
                "morango",
                "carro",
                "moeda",
                "notebook",
            };

            // Palavra aleatoria do array.
            var escolherPalavra = palavras[new Random().Next(0, palavras.Length - 1)];

            // Regex valida os caracteres (entre a e z).
            var letrasValidas = new Regex("^[a-z]$");

            // Numero de vidas.
            var vidas = 5;

            // Array vazio que terá as letras que o jogador usar.
            var letras = new List<string>();
            


            // Enquanto as vidas não forem 0, array continua
            while (vidas != 0)
            {
                // Contador de caracteres restantes.
                var caracteresRestantes = 0;
              
                // Loop pra percorrer os caracteres da palavra
                foreach (var caracter in escolherPalavra)
                {
                    
                    // Fazer a letra virar string
                    var letra = caracter.ToString();

                    // Se a letra estiver na palavra escreve a letra, se não deixa um underline.
                    if (letras.Contains(letra))
                    {
                        Console.Write(letra);
                    }
                    else
                    {
                        Console.Write("_");

                        // Contar as letras restantes para ver se o jogo acabou ou não
                        caracteresRestantes++;
                    }
                }
                Console.WriteLine(string.Empty);

                // se não houver mais caracteres o jogo acabou, encerra.
                if (caracteresRestantes == 0)
                {
                    break;
                }

                Console.Write("Digite uma letra: ");
                // transformar tudo em letra minuscula para não repetir letras.
                var key = Console.ReadKey().Key.ToString().ToLower();
                Console.WriteLine(string.Empty);

                // Verificar se a letra enviada está entre a~z com o regex declarado no inicio.
                if (!letrasValidas.IsMatch(key))
                {
                    // Se a letra for inválida, o loop volta ao inicio usando o continue e mostrando o erro.
                    Console.WriteLine($"A letra {key} é inválida. Tente novamente.");
                    continue;
                }

                // Verificar se letra está no array de letras usadas
                if (letras.Contains(key))
                {
                    // Mostrar que a letra já foi usada
                    Console.WriteLine("Você já usou essa letra");
                    continue;
                }

                // Se a letra não foi usada, adicionar ao array
                letras.Add(key);

                // Se a letra estiver errada, reduz as vidas.
                if (!escolherPalavra.Contains(key))
                {
                    vidas--;

                   
                    if (vidas > 0)
                    {
                        // Aqui, usei um ternário para deixar no plural ou singular
                        // Que vai depender de quantas vidas tem sobrando
                        Console.WriteLine($"A letra {key} não está na palavra. Você tem {vidas} {(vidas == 1 ? "tentativa" : "tentativas")} sobrando.");
                    }
                }
            }

            // Se tiver sobrado vidas, mensagem de vitória!
            if (vidas > 0)
            {
                // Feito outro ternário para garantir o singular ou plural corretos na frase
                Console.WriteLine($"Você ganhou com {vidas} {(vidas == 1 ? "vida" : "vidas")} sobrando!");
            }
            else
            {
                Console.WriteLine($"Você perdeu! A palavra era {escolherPalavra}.");
            }
        }
    }
}