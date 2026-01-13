# Historia wersji

## v0.0.0
Utworzono repozytorium oraz podstawową strukturę rozwiązania.  
Przygotowano projekty odpowiadające poszczególnym warstwom architektury bez implementacji logiki biznesowej.

## v0.0.1
Uporządkowano strukturę projektu poprzez usunięcie plików startowych.  
Przygotowano docelowe foldery dla poszczególnych warstw architektury.  
Utworzono wstępną dokumentację projektu.

## v0.0.2
Dodano pierwsze klasy domenowe reprezentujące podstawowe elementy gry, takie jak karta oraz gracz.  
Dodano konfigurację zależności pomiędzy projektami.

## v0.0.3
Zaimplementowano ekran logowania i rejestracji użytkownika.
Dodano podstawowy mechanizm uwierzytelniania oraz stan zalogowania w aplikacji.

## v0.0.4
Rozszerzono system uwierzytelniania o integrację z bazą danych SQLite.
Zaimplementowano podstawową obsługę rejestracji i logowania użytkowników z wykorzystaniem Entity Framework Core.
Dodano migracje bazy danych oraz mechanizm bezpiecznego hashowania haseł.
Aktualna wersja stanowi etap przejściowy – dalsze prace obejmą pełne dopracowanie procesu uwierzytelniania oraz jego integrację z pozostałymi mechanikami gry.