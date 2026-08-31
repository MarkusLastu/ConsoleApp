using Grupparbeten_Project;

Console.WriteLine("Hello, World!");


int programVal = 1;


if (programVal == 0)
{
    Console.WriteLine("Välj program");
    Console.WriteLine("1 - Gandalf");
    programVal = int.Parse(Console.ReadLine());

}


switch (programVal)
{

    case 1: V2_dag1.Ovn1_Main(); break;
}