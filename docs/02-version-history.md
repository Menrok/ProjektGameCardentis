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

## v0.0.5
Uporządkowano strukturę projektu.  
Dopracowano interfejs użytkownika ekranów logowania i rejestracji.
Zaimplementowano szczegółową walidację pól formularzy z wykorzystaniem adnotacji danych oraz komunikatów walidacyjnych przypisanych do poszczególnych pól.
Uspójniono prezentację błędów walidacji oraz błędów logowania pochodzących z warstwy logiki biznesowej.

## v0.0.6
Zaimplementowano mechanizm wylogowywania użytkownika oraz pełny przepływ zakończenia sesji.
Dodano zabezpieczenie dostępu do widoków aplikacji poprzez kontrolę stanu uwierzytelnienia (guard).
Wprowadzono główny layout aplikacji dla obszaru gry, obejmujący nagłówek oraz obsługę stanu zalogowanego użytkownika.
Uproszczono i uporządkowano elementy interfejsu użytkownika odziedziczone z szablonu startowego projektu.

## v0.0.7
Zaimplementowano podstawowy system walki turowej.
Dodano obsługę talii, ręki, odrzutu oraz energii gracza.
Wprowadzono starter deck oraz wizualny komponent kart.
Dodano prostego przeciwnika (AI) oraz podstawowy flow tury.

## v0.0.8
Dodano Playera do bazy danych.
Rozdzielono dane trwałe gracza od stanu walki poprzez wprowadzenie obiektów runtime.
Zaimplementowano trwały system talii gracza zapisywany w bazie danych.
Dodano serwis pobierający aktualnego gracza oraz zaktualizowano ekran profilu i walki.
Uporządkowano system walki poprzez wydzielenie fabryki przeciwników oraz logiki AI.
Podzielono aplikacje na nowe widoki.