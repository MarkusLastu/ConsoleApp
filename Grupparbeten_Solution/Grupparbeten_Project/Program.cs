using Grupparbeten_Project;

Console.WriteLine("Hello, World!");


int programVal = 1; // Hårdkoda vilket program du vill köra. 0 = 


if (programVal == 0)
{
    Console.WriteLine("Välj program");
    Console.WriteLine("1 - Wizards kastar mana");
    Console.WriteLine("2 - Magiskt bibliotek");
    programVal = int.Parse(Console.ReadLine());

}


switch (programVal)
{

    case 1: V2_dag1.Ovn1_Main(); break;
    case 2: V2_dag1.Ovn2_Main(); break;
}