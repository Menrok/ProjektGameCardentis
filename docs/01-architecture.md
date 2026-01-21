# Architektura systemu

## Architektura aplikacji

Aplikacja została zaprojektowana w oparciu o architekturę warstwową, która rozdziela odpowiedzialności pomiędzy poszczególne części systemu:

- **Server** – interfejs użytkownika, hosting aplikacji oraz komunikacja w czasie rzeczywistym (SignalR)
- **Application** – logika aplikacyjna oraz obsługa przypadków użycia
- **Domain** – logika domenowa gry, reguły rozgrywki oraz encje
- **Infrastructure** – dostęp do danych oraz mechanizmy trwałości (Entity Framework Core, SQLite)

Zastosowany podział zwiększa czytelność kodu, ułatwia utrzymanie projektu oraz umożliwia jego dalszą rozbudowę.

---

## Główne mechaniki gry

### System kart

Każda karta reprezentuje jedno z działań:
- atak,
- obronę,
- umiejętność specjalną.

Karty posiadają:
- koszt użycia,
- określony efekt działania.

Gracz buduje i modyfikuje własną talię kart, która wykorzystywana jest podczas walki.

---

### System walki

Rozgrywka oparta jest na turowym systemie walki pomiędzy dwoma graczami.

W każdej rundzie gracze:
- dobierają karty do ręki,
- wybierają karty do zagrania,
- zarządzają dostępnymi zasobami (np. energia).

Po zaplanowaniu tury przez obie strony następuje wspólne ujawnienie kart oraz rozliczenie rundy w sposób deterministyczny.

Logika walki realizowana jest po stronie serwera, co zapewnia spójność i poprawność rozgrywki.

---

### System postaci

Postać gracza posiada podstawowe statystyki:
- punkty zdrowia,
- aktualny poziom energii,
- modyfikatory wynikające z kart oraz efektów.

Rozwój postaci realizowany jest poprzez:
- zdobywanie nowych kart,
- modyfikację i rozbudowę talii,
- postęp w rozgrywce.

---

### Sklep (planowany)

Sklep stanowi planowany element gry dostępny pomiędzy rozgrywkami.

Docelowo gracz będzie miał możliwość:
- kupowania kart,
- sprzedawania kart,
- ulepszania kart.

Waluta wykorzystywana w sklepie zdobywana będzie podczas rozgrywek.

---

## Aktorzy systemu

### Gracz

Gracz jest głównym aktorem systemu i odpowiada za:
- prowadzenie rozgrywki,
- udział w pojedynkach,
- zarządzanie talią kart oraz postacią,
- podejmowanie decyzji strategicznych.

---

### Administrator (systemowy)

Administrator jest aktorem technicznym systemu i odpowiada za:
- zarządzanie danymi gry (np. kartami oraz ich parametrami),
- konfigurację i balans rozgrywki.

Administrator nie bierze bezpośredniego udziału w rozgrywce.

---

## Interfejs użytkownika

Interfejs użytkownika został zaprojektowany jako aplikacja webowa typu SPA.

UI zawiera następujące widoki:
- ekran główny (menu),
- ekran rozgrywki (walka),
- widok talii kart,
- podstawowe komunikaty systemowe.

Interfejs użytkownika jest:
- prosty i intuicyjny,
- czytelny,
- przystosowany do działania w przeglądarce internetowej.

---

## Tryby gry

### Multiplayer

Podstawowym trybem gry jest tryb multiplayer 1v1, w którym dwóch graczy rywalizuje ze sobą w czasie rzeczywistym.

Rozgrywka:
- oparta jest na systemie turowym,
- synchronizowana jest przez serwer,
- wykorzystuje komunikację w czasie rzeczywistym (SignalR).

---

### Singleplayer (opcjonalny)

Opcjonalny tryb singleplayer umożliwia rozgrywkę przeciwko przeciwnikowi sterowanemu przez system.

Tryb ten może zostać zaimplementowany jako rozszerzenie projektu.
