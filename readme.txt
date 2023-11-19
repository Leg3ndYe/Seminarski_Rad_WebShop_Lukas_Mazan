# Seminarski rad Lukas Mazan
Edukacija ASP.NET MVC dev, 20.03.2023. - 15.11.2023.

Readme file koji objašnjava što aplikacija radi i kako je implementirati.

Korisnički podaci:          
Login u WebShopu                                               
E-mail admina: admin@admin.com                              
Password admina: HashPass123! 

Implementacija:

1. Otvorite "Seminarski_Rad_WebShop_Lukas_Mazan.sln"

2. U "Solution Exploreru" otvorite "appsettings.json" i kod "DefaultConnection":"Server=(ovdje upišite ime svojeg SQL servera)"
-Potrebno je točno upisati ime servera- ako ne znate ime servera, otvorite "Server System Management Studio", spojite se na bazu i na vrhu "Object Explorera" pisat će ime vašeg servera.

3. Potrebno je napraviti migraciju na bazu podataka kako bi se kreirale tablice. Migracija se radi tako da kliknete na "Packet Manager Console" u Visual Studiu. Upišete "add-migration (ime migracije)" svaka migracija mora imati ime. Nakon toga je potrebno upisati "update-database" i migracija će biti odrađena.

4. Kliknite na "Build" > "Build Solution"

5. Pokrenite projekt "Start without debugging"


Opis rada aplikacije:

1. Home:
Home prikazuje "9" nasumično odabranih proizvoda a ne 10 kako je zadano jer mi OCD ne dopušta tako. To se može lagano promijeniti u HomeControlleru pod Index samo se zamijene brojke 9 sa brojem 10.

2. Privacy:
Default prikaz

3. Products:
Prikazuje sve produkte koji su dodani u bazu podataka pomoću migracije ili ručno kao admin.
Produkti se mogu filtrirati. Filtriranju se po broju produkata koji se prikazuju, po imenu i po kategoriji. Da bi se produkti filtrirali potrebno je pritisnuti "Search", a da bi se filter resetirao "Reset".
Klikom na pojedini produkt vide se detalji produkta i slike koje pripadaju tom produktu.
Svaki produkt može se dodati u košaricu sve dok tih produkta ima na stanju.

4. Cart:
Ako postoji neki produkt u cartu taj produkt je prikazan sa svojim detaljim. Može se mijenjati količina produkta koji se naručuju. Produkti se mogu izbacivati iz Carta ili se isti mogu naručiti klikom na "Order Products".

Klikom na "Order Products" korisnik se preusmjerava na stranicu gdje ispunjava podatke o narudžbi. Klikom na Place order ta narudžba se završava.

-potrebno je biti prijavljen kao admin-
5. Admin dropdown:
Klikom na Categories, mogu se dodavati i uređivati kategorije.
Klikom na Products, mogu se dodavati i uređivati produkti.
Za svaki produkt se mogu dodati slike.
Svaki produkt ima status aktivan ili neaktivan, što određuje hoće li se taj produkt pokazati korisnicima ili ne.
Klikom na Orders, mogu se uređivati narudžbe.

6. User Management:
Mogu se dodavati novi korisnici i uređivati ili brisati postojeći.
Svakom korisniku se može dodati avatar, titual ("role") i neki nickname.



