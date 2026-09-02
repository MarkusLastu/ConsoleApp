using System;

public class Class1
{
    public Class1()
    {


        // Denna kod ska läggas till i .csproj-filen för projektet.
        // Den används till att kopiera txt-filen till utdata- och publiceringskatalogen.

        /*

            < ItemGroup >
                < None Include = "..\ImportFiler\dessert.txt" >
                < CopyToOutputDirectory > PreserveNewest </ CopyToOutputDirectory >
                < CopyToPublishDirectory > PreserveNewest </ CopyToPublishDirectory >            
                </ None >
            </ ItemGroup >

        */


        //Använd denna sökväg för att hitta filer i denna mapp.        
        string filePath = Path.Combine(
            AppContext.BaseDirectory,
                "ImportFiler",
                "xxx.txt");

        using StreamReader sr = new StreamReader(filePath);


        // BaseDirectory är den mapp där programmet körs ifrån.
        // I Visual Studio är det bin\Debug\net10.0        
        // Därifrån kan vi sedan gå ner i ImportFiler-mappen och hitta rätt txt-fil.


    }
}
