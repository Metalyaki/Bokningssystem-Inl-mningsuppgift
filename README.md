----------------------------------------------------------------------------------------------
Bokningssystem – Salar och Grupprum 
----------------------------------------------------------------------------------------------

Skapat av Alfons Newberg, Anders Nguyen, Pontus Rodmalm, Alexander Andersson 

Github repo:
https://github.com/Metalyaki/Bokningssystem-Inl-mningsuppgift.git

○ Hur man startar och använder programmet 

Starta programmet genom att dubbelklicka på .EXE filen. När du startar programmet första gången så kommer tre salar och tre grupprum att skapas. Därefter finns det möjlighet att skapa fler salar. Använd sedan menyvalsknapparna (0-9) för att ta dig fram i menyn. Efter vissa menyval måste du klicka på valfri tangent för att återgå till menyn.  

I programmet har du möjlighet att skapa, uppdatera och ta bort bokningar. Du har även möjlighet att se alla bokningar, se alla lokaler, söka bokningar på specifikt år och även skapa nya salar. 

I inställningar har du möjlighet att sortera bokningslistan samt ändra textfärg. 

Efter varje gång du ändrar en bokning eller skapar en ny sal, så sparas informationen och läses sedan in när du startar det igen. Om du vill återställa programmet och ta bort alla bokningar och skapade salar så hittar du 4 stycken .JSON filer i C:\Bokningssystem main\bin\Debug\net8.0. 

För att återställa programmet, radera: 

BokadeGrupprum.json 

BokadeSalar.json 

grupprum.json 

salar.json 



○ Eventuella kända begränsningar 

En begränsning vi känner till är att det går att boka samma rum på samma datum och tid. 

Se bokningar metoden listar alla bokningar, oavsett år. 

○ Val och motiveringar för implementation 

Vi har valt att strukturera våra klasser och metoder utifrån vilket behov vi har sett finnas. I efterhand så hade vi velat implementera vissa metoder i lokal-klassen. Vi har även haft användarvänlighet i fokus och fokuserat på att skapa lättläst kod. 



○ Beskrivning av filformat och struktur 

Vi har valt att separera en hel del från huvudfilen, dels hittar du alla våra klasser för Ibookable, lokal, sal och grupprum. Men även separata filer för metoder för serialisering (DataManager) och en för utskrivning av menyer (MenuHelper). 



○ Vilken student har huvudansvaret för vilka delar 

Alfons – Menyn, serialisering, listor och användarvänlighet. Skapat klasser för datahantering och menyutskrivning.  

Pontus – Metoder för att uppdatera bokningar och skapa nya salar. Skapade salklassen. 

Anders – Metoder för att skapa bokningar och ta bort bokningar. Skapade grupprumsklassen och Ibookable interfacet. 

Alexander – Metoder för att se bokningar, se lokaler och sök bokning. 

 
