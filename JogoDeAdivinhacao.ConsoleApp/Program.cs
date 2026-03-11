using System.Security.Cryptography;
class Program
{
  static void Main(string[] args)
  {
    while (true)
    {
      string? dificuldadeEscolhida = ExibirMenuEscolha();

      int[] configuracoes = ConfigurarPartida(dificuldadeEscolhida);

      int numeroMaximo = configuracoes[0];
      int tentativasMaximas = configuracoes[1];

      ExecutarPartida(numeroMaximo, tentativasMaximas);

      if (!JogadorDesejaContinuar())
        break;
    }
  }
  static string? ExibirMenuEscolha()
  {
    Console.Clear();

    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine("Jogo de Adivinhação");
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine("Escolha o nível de dificuldade");
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - Médio (5 tentativas)");
    Console.WriteLine("3 - Dificil (3 tentativas)");
    Console.WriteLine("-----------------------------------------------------");

    Console.Write("Digite sua escolha: ");
    string? dificuldade = Console.ReadLine();

    return dificuldade;
  }
  static int[] ConfigurarPartida(string? dificuldadeEscolhida)
  {
    int numeroMaximo = 0;
    int tentativasMaximas = 0;

    switch (dificuldadeEscolhida)
    {
      case "1":
        numeroMaximo = 20;
        tentativasMaximas = 10;
        break;

      case "2":
        numeroMaximo = 50;
        tentativasMaximas = 5;
        break;

      case "3":
        numeroMaximo = 100;
        tentativasMaximas = 3;
        break;

      default:
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Por favor, selecione uma dificuldade válida.");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
        break;
    }

    int[] configuracoes = new int[2];

    configuracoes[0] = numeroMaximo;
    configuracoes[1] = tentativasMaximas;

    return configuracoes;
  }
  static void ExecutarPartida(int numeroMaximo, int tentativasMaximas)
  {
    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);
    int[] numerosDigitados = new int[tentativasMaximas];
    int contadorNumerosDigitados = 0;
    int pontuacao = 1000;

    for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
    {
      Console.Clear();
      Console.WriteLine("-----------------------------------------------------");
      Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}");
      Console.WriteLine("-----------------------------------------------------");

      Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
      int numeroDigitado = Convert.ToInt32(Console.ReadLine());

      bool numeroEstaRepetido = false;

      for (int indiceChecado = 0; indiceChecado < numerosDigitados.Length; indiceChecado++)
      {
        if (numerosDigitados[indiceChecado] == numeroDigitado)
        {
          numeroEstaRepetido = true;
          break;
        }
      }

      if (numeroEstaRepetido == true)
      {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Você já digitou esse número, tente novamente.");
        Console.WriteLine("-----------------------------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();

        tentativa--;

        continue;
      }

      if (contadorNumerosDigitados < numerosDigitados.Length)
      {
        numerosDigitados[contadorNumerosDigitados] = numeroDigitado;

        contadorNumerosDigitados++;
      }

      if (numeroDigitado == numeroAleatorio)
      {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Parabéns, você acertou!!");
        Console.WriteLine("-----------------------------------------------------");

        break;
      }
      else if (numeroDigitado > numeroAleatorio)
      {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("O número digitado foi maior do que o número secreto!");
        Console.WriteLine("-----------------------------------------------------");
      }
      else
      {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("O número digitado foi menor do que o número secreto!");
        Console.WriteLine("-----------------------------------------------------");
      }

      int diferencaNumerica = Math.Abs(numeroAleatorio - numeroDigitado);

      if (diferencaNumerica >= 10)
      {
        pontuacao -= 100;
      }
      else if (diferencaNumerica >= 5)
      {
        pontuacao -= 50;
      }
      else
      {
        pontuacao -= 20;
      }

      Console.WriteLine("Sua pontuação é: " + pontuacao);
      Console.WriteLine("-----------------------------------------------------");

      if (tentativa == tentativasMaximas)
      {
        Console.WriteLine($"Você usou todas as tentativas! O número secreto era {numeroAleatorio}.");
        Console.WriteLine("-----------------------------------------------------");
        break;
      }
      else
      {
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
      }
    }
  }
  static bool JogadorDesejaContinuar()
  {
    Console.Write("Deseja continuar? [S/N] --> ");
    string? opcaoContinuar = Console.ReadLine();

    if (opcaoContinuar?.ToUpper() != "S")
      return false;

    return true;
  }
}