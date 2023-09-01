/*A primeira linha da entrada contém três números inteiros N, M e K, respectivamente o número de caracteres da senha, 
  o número de letras borradas da senha e o comprimento de cada palavra.
* A segunda linha contem uma cadeia de caracteres de comprimento N, a senha escrita no papel, com o caractere `#' (cerquilho) representando as 
  letras borradas.
  Cada uma das M linhas seguintes contém uma palavra Si, sendo que a Si-ésima palavra contém as letras para substituir a i-ésima letra borrada 
  da senha. 
 * A última linha contém um número inteiro P, o número de ordem da senha correta na lista ordenada de possíveis senhas.*/
using System.Collections;
using System.Collections.Immutable;

Console.WriteLine("Com um pedaço de papel que Vó Zinha guardou na gaveta onde guarda também suas meias ela fez o seguinte: " +
    "inicialmente escreveu a senha do banco no papel;\r\nentão borrou algumas das letras da senha que tinha escrito de forma que " +
    "não possam ser lidas;\r\npara cada uma das letras borradas, ela escreveu no papel uma palavra com K letras;\r\npor fim, ela escreveu no " +
    "papel um número inteiro P.\r\nVó Zinha então contou para você como recuperar a senha:\r\n\r\nutilizando as listas de palavras no papel, " +
    "substitua cada letra borrada da senha por uma das letras da respectiva lista, obtendo assim possíveis senhas;\r\ncrie uma lista contendo " +
    "todas as possíveis senhas obtidas no passo anterior;\r\nordene a lista de possíveis senhas em ordem lexicograficamente crescente;\r\na" +
    " senha correta é a P-ésima possível senha na lista ordenada.\r\nPor exemplo, considere que no papel esteja escrito (# representa uma letra" +
    " borrada):\r\n\r\nx#yy#z\r\nab\r\ncd\r\n3\r\nFazendo as substituições, a lista das possíveis senhas é xayycz, xbyycz, xayydz, xbyydz .\r\n\r\nOrdenando as possíveis senha obtemos xayycz, xayydz, xbyycz, xbyydz, e portanto a senha correta é xbyycz (a terceira da lista ordenada).\r\n\r\nHoje Vó Zinha precisa pagar uma conta pela internet e não se recorda da senha do banco. Ela pediu que você pegue o pedaço de papel guardado na gaveta e a ajude a recuperar a senha.");
char[] inptParametros;
Console.WriteLine("Digite o número de caracteres da senha, o número de letras borradas da senha e o comprimento de cada palavra.\r\nSem espaços!!! \r\nPor exemplo: 123");
string inptConsole = Console.ReadLine();
inptParametros = inptConsole.ToCharArray();
while (inptParametros.Length != 3 || char.ToString(inptParametros[0]) == "0" || char.ToString(inptParametros[1]) == "0" || char.ToString(inptParametros[2]) == "0") 
{
    Console.WriteLine("Valor inválido");
    Console.WriteLine("Digite o número de caracteres da senha, o número de letras borradas da senha e o comprimento de cada palavra.\r\nSem espaços!!! \r\nPor exemplo: 123");
    inptConsole = Console.ReadLine();
    inptParametros = inptConsole.ToCharArray();
}
string NumCaracteres = inptConsole[0].ToString();
string NumLetrasBorradas = inptParametros[1].ToString();
string CompPalavra = inptParametros[2].ToString();
Console.WriteLine("Digite a senha que deve conter o mesmo numero de caracteres N digitado a cima e use # para representar os caracteres borrados"); 
string senhaString = Console.ReadLine();
Console.WriteLine(senhaString.Length);
Console.WriteLine(NumCaracteres);
while (senhaString.Length.ToString() !=  NumCaracteres)
{
    Console.WriteLine("O numeros de caracteres informados é diferente da linha a cima");
    Console.WriteLine("Digite a senha que deve conter o mesmo numero de caracteres N digitado a cima e use # para representar os caracteres borrados");
    senhaString = Console.ReadLine();
}
char[] senhaArray = senhaString.ToCharArray();
int contadorCerquilha = 0;
for (int i = 0; i < senhaArray.Length; i++)
{
    if (senhaArray[i].ToString() == "#")
        {
        contadorCerquilha ++;
    }
}
if (contadorCerquilha.ToString() != NumLetrasBorradas)
{
    Console.WriteLine("O numero de letras borradas digitado é diferente do informado");
    Console.WriteLine("Digite 1 para digitar a senha novamente ou 2 para definir o numero de caracteres borrados para o tanto que foi digitado");
    switch (Console.ReadLine())
    {
        case "1":
            senhaString = Console.ReadLine();
            while (senhaString != Convert.ToString(NumCaracteres))
            {
                Console.WriteLine("O numeros de caracteres informados é diferente da linha a cima");
                senhaString = Console.ReadLine();
            }
            break;
        case "2":
            NumLetrasBorradas = contadorCerquilha.ToString(); break;
    }
}
else { }
Console.WriteLine($"Agora digite as {NumLetrasBorradas} palavras (uma por vez) que devem conter {CompPalavra} letras cada");
int j = 0;
string[] letrasBorradas = new string[Convert.ToInt32(NumLetrasBorradas)];
while (j < Convert.ToInt32(NumLetrasBorradas))
    {
    Console.WriteLine($"{j + 1}: ");
    letrasBorradas[j] = Console.ReadLine();
    j++;
}
//Array.Sort(letrasBorradas);
int y = 0;
string[] variacoesSenha = {};
double qtdVariacoes = Math.Pow(Convert.ToInt32(CompPalavra), contadorCerquilha);
int k = 0;
string opcaoSenha = " ";
ArrayList combinacao = new ArrayList();
for (double v = 0; v < qtdVariacoes ; v++)
{
    opcaoSenha = " ";
    foreach (char ls in senhaArray)
    {
        if (ls.ToString() == "#")
        {
            opcaoSenha += letrasBorradas[k];
        }
        else
        {
            opcaoSenha += ls.ToString();
        }

    }
    k++;
    if (k >= Convert.ToInt32(NumLetrasBorradas))
    {
        k = 0;
    }
    combinacao.Add(opcaoSenha);
 }
combinacao.Sort();
    Console.WriteLine("Digite a posição em ordem crescente da senha");
    string posSenhaString = Console.ReadLine();
    int posSenhaInt;
    bool verifNum = int.TryParse(posSenhaString, out posSenhaInt);
    while (verifNum == false)
    {
        Console.WriteLine("Valor inválido!! \r\n Digite a posição em ordem crescente da senha");
        posSenhaString = Console.ReadLine();
        verifNum = int.TryParse(posSenhaString, out posSenhaInt);
    }
Console.WriteLine($"A senha é: {combinacao[posSenhaInt - 1]}");
Console.WriteLine("Deseja ver as outras combinações? \r\n S ou N");
string sn = Console.ReadLine().ToLower();
switch(sn)
{
    case "sim":
    case "s":
        Console.WriteLine("As outras combinações foram: ");
        foreach (string w in combinacao)
        {
            Console.WriteLine(w);
        }
        break;
}
