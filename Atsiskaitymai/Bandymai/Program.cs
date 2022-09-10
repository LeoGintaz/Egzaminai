using Bandymai;
using System;
using System.Text;

namespace Hangman
{

    public class Program

    {
       

        static void Main(string[] args)
        {
            Input input = new Input();
            input.GetPosition();

        }




    }
}
/*
 Instructions
+ Naudotojas pasirenka iš temų: VARDAI, LIETUVOS MIESTAI, VALSTYBES, KITA. 
  (ne mažiau kaip 10 žodžių kiekvienoje grupėje)
+ Žodis iš pasirinktos grupės parenkamas atsitiktine tvarka.
+ Užtikrinti kad nebūtu duodamas tas pat žodis daugiau kaip 1 kartą per žaidimą
+ Užtikrinti, kad programą nenulūžtu jei vartotojas įveda ne tai ko prašoma
+ Ėjimas skaitomas tik jei spėjama dar nespėta raidė
+ Jei spėjamas visas žodis ir neatspėjama - iškarto pralaimima
+ Parodoma atspėtos raidės vieta žodyje
+ Parodomos spėtos, bet neatspėtos raidės

Apribojimai:
+ Žodžius saugoti masyvuose  arba žodyne.
+ Kodą skaidyti į metodus.
+ negalima naudoti OOP ir LINQ
 */
// "","","","","","","","","",""