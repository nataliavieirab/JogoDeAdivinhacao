// Objetivos / Passo-a-passo
// 1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
// 2. Nosso jogo deve ferar um número secreto aleatório
// 3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem

using System;
using System.Security.Cryptography; //Biblioteca padrão de criptografia

Console.WriteLine("--------------------------");
Console.WriteLine("Jogo de Adivinhação");
Console.WriteLine("--------------------------");

int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);

Console.Write("Digite um número entre 1 e 20: ");
string? chute = Console.ReadLine();

Console.WriteLine("O valor digitado foi: " + chute);
Console.WriteLine("O valor aleatório era: " + numeroAleatorio);

Console.ReadLine();