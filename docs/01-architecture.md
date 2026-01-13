# Architektura systemu

## Architektura aplikacji

Aplikacja zosta³a zaprojektowana w oparciu o architekturê warstwow¹, która rozdziela odpowiedzialnoœci pomiêdzy poszczególne czêœci systemu:

- **Server** – interfejs u¿ytkownika, hosting aplikacji oraz komunikacja SignalR
- **Application** – logika aplikacyjna oraz przypadki u¿ycia
- **Domain** – logika domenowa gry, regu³y oraz encje
- **Infrastructure** – dostêp do danych oraz mechanizmy trwa³oœci (EF Core, SQLite)

Zastosowany podzia³ zwiêksza czytelnoœæ kodu, u³atwia utrzymanie projektu oraz pozwala na jego dalsz¹ rozbudowê.

---

## G³ówne mechaniki gry

### System kart

Ka¿da karta reprezentuje jedno z dzia³añ:
- atak,
- obronê,
- umiejêtnoœæ specjaln¹,
- efekt pasywny.

Karty posiadaj¹:
- koszt u¿ycia,
- rzadkoœæ,
- okreœlony efekt dzia³ania.

Gracz buduje i modyfikuje w³asn¹ taliê kart, która wykorzystywana jest podczas walki.

---

### System walki

Rozgrywka oparta jest na turowym systemie walki pomiêdzy dwoma graczami (multiplayer 1v1).

W ka¿dej turze gracz:
- dobiera karty do rêki,
- zagrywa karty z rêki,
- zarz¹dza dostêpnymi zasobami (np. energia lub mana).

Logika walki realizowana jest po stronie serwera, co zapewnia spójnoœæ i poprawnoœæ rozgrywki.

---

### System postaci

Postaæ gracza posiada podstawowe statystyki:
- zdrowie,
- atak,
- obronê,
- dodatkowe modyfikatory wynikaj¹ce z kart lub efektów.

Rozwój postaci odbywa siê poprzez:
- zdobywanie nowych kart,
- ulepszanie posiadanych kart,
- postêp w rozgrywce.

---

### Sklep

Sklep dostêpny jest pomiêdzy rozgrywkami.

Gracz ma mo¿liwoœæ:
- kupowania kart,
- sprzedawania kart,
- ulepszania kart.

Waluta wykorzystywana w sklepie zdobywana jest podczas rozgrywek.

---

## Aktorzy systemu

### Gracz

Gracz jest g³ównym aktorem systemu i odpowiada za:
- rozpoczêcie i prowadzenie rozgrywki,
- udzia³ w pojedynkach multiplayer 1v1,
- zarz¹dzanie tali¹ kart oraz postaci¹,
- podejmowanie decyzji strategicznych podczas gry.

---

### Administrator (systemowy)

Administrator jest aktorem technicznym systemu i odpowiada za:
- zarz¹dzanie danymi gry, w tym kartami oraz ich parametrami,
- konfiguracjê i balans rozgrywki.

Administrator nie bierze bezpoœredniego udzia³u w rozgrywce.

---

## Interfejs u¿ytkownika

Interfejs u¿ytkownika zosta³ zaprojektowany jako aplikacja webowa typu SPA.

UI zawiera nastêpuj¹ce widoki:
- ekran g³ówny (menu),
- ekran rozgrywki (walka),
- widok talii kart,
- ekran sklepu,
- podstawowe komunikaty systemowe.

Interfejs u¿ytkownika jest:
- prosty i intuicyjny,
- czytelny,
- w pe³ni przystosowany do dzia³ania w przegl¹darce internetowej.

---

## Tryby gry

### Multiplayer

Podstawowym trybem gry jest multiplayer 1v1, w którym dwóch graczy rywalizuje ze sob¹ w czasie rzeczywistym.

Rozgrywka:
- oparta jest na systemie turowym,
- odbywa siê pomiêdzy dwoma graczami po³¹czonymi z serwerem,
- synchronizowana jest w czasie rzeczywistym.

---

### Singleplayer (opcjonalny)

Opcjonalny tryb singleplayer umo¿liwia rozgrywkê przeciwko przeciwnikowi sterowanemu przez system.

Tryb ten mo¿e zostaæ zaimplementowany jako rozszerzenie projektu.
