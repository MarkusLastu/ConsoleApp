using System;

public class Class1
{
	public Class1()
	{

        //Använd denna sökväg för att hitta filer i denna mapp.        
        string filePath = Path.Combine(

            AppContext.BaseDirectory,
            @"..\..\..\..\ImportFiler\xxx.txt");

        // BaseDirectory är den mapp där programmet körs ifrån. I Visual Studio är det bin\Debug\net10.0
        // ..\..\..\..\ tar oss upp fyra nivåer i mappstrukturen, till roten av Solution.
        // Därifrån kan vi sedan gå ner i ImportFiler-mappen och hitta rätt txt-fil.

        using StreamReader sr = new StreamReader(filePath);
    }
}
