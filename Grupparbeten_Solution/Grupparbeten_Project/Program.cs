using V2 = Grupparbeten_Project.Vecka2;




Console.WriteLine("Hello, World!");


int programVal = 0; // Hårdkoda vilket program du vill köra. 0 = 


if (programVal == 0)
{
    Console.WriteLine("Välj program");
    Console.WriteLine("1 - Wizards kastar mana");
    Console.WriteLine("2 - Magiskt bibliotek");
    Console.WriteLine("3 - Simulera ett litet zoo");
    programVal = int.Parse(Console.ReadLine());

}


switch (programVal)
{

    case 1: V2.Dag1.Ovn1_Main(); break;
    case 2: V2.Dag1.Ovn2_Main(); break;
    case 3: V2.Dag2.Ovn1_Main(); break;

}