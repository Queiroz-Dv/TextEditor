using System.IO;

Menu();


static void Menu()
{
  const short ABRIR = 1;
  const short CRIAR = 2;
  const short SAIR = 0;
  Console.Clear();
  Console.WriteLine("Bem vindo ao Leitor de Arquivos");
  Console.ReadKey();

  Console.WriteLine("------------------------------");
  Console.WriteLine("Escolha uma das opções abaixo");
  Console.WriteLine("1 - Abrir Arquivo");
  Console.WriteLine("2 - Criar Novo Arquivo");
  Console.WriteLine("0 - Sair");
  short opt = short.Parse(Console.ReadLine());

  switch (opt)
  {
    case ABRIR:
      Abrir();
      break;
    case CRIAR:
      Editar();
      break;
    case SAIR:
      Environment.Exit(0);
      break;
    default:
      Menu();
      break;
  }
}


static void Abrir()
{
  Console.Clear();
  Console.WriteLine("Qual o caminho do arquivo?");
  string path = Console.ReadLine();

  using (var file = new StreamReader(path))
  {
    string text = file.ReadToEnd();
    Console.WriteLine(text);
  }
  
  Console.WriteLine("");
  Console.ReadLine();
  Menu();
}

static void Editar()
{
  Console.Clear();
  Console.WriteLine("Digite seu texto abaixo(ESC para sair)");
  Console.WriteLine("------------------------");
  string text = "";
  do
  {
    text += Console.ReadLine();
    text += Environment.NewLine;
  }
  // Enquanto o usuário não apertar ESC não vai sair do Loop
  while (Console.ReadKey().Key != ConsoleKey.Escape);

  Salvar(text);
}

static void Salvar(string text)
{
  Console.Clear();
  Console.WriteLine("" + "Qual caminho para salvar o arquivo?");
  var path = Console.ReadLine();

  using (var file = new StreamWriter(path))
  {
    file.Write(text);
  }

  Console.WriteLine($"Arquivo{path} salvo com sucesso!");
  Console.ReadLine();
  Menu();
}