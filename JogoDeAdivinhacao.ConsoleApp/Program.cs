// Objetivos / Passo-a-passo
// 1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
// 2. Nosso jogo deve ferar um número secreto aleatório
// 3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem

Console.WriteLine("--------------------------");
Console.WriteLine("Jogo de Adivinhação");
Console.WriteLine("--------------------------");

Console.Write("Digite um número entre 1 e 20: ");
string? chute = Console.ReadLine();

Console.WriteLine("O valor digitado foi: " + chute);
Console.ReadLine();

