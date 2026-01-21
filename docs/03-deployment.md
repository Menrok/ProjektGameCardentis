# Deployment

## Model wdrożenia

Aplikacja **Cardentis** została zaprojektowana jako aplikacja webowa typu **Blazor Server**, działająca w modelu klient–serwer.

Całość logiki aplikacji oraz logiki gry realizowana jest po stronie serwera, natomiast interfejs użytkownika renderowany jest dynamicznie w przeglądarce użytkownika.  
Komunikacja pomiędzy klientem a serwerem odbywa się w czasie rzeczywistym z wykorzystaniem **SignalR**.

---

## Środowisko uruchomieniowe

Aplikacja wymaga środowiska obsługującego **ASP.NET Core**.

Wykorzystywane komponenty środowiska:
- .NET SDK (zgodny z wersją projektu),
- ASP.NET Core Runtime,
- silnik bazy danych SQLite,
- serwer obsługujący połączenia SignalR.

---

## Uruchamianie lokalne

Projekt może zostać uruchomiony lokalnie w trybie deweloperskim przy użyciu:

- Visual Studio,
- lub narzędzia `dotnet` (CLI).

Podczas uruchomienia:
- aplikacja startuje jako serwer ASP.NET Core,
- baza danych SQLite tworzona jest lokalnie,
- migracje bazy danych wykonywane są przez Entity Framework Core.

Tryb lokalny wykorzystywany jest do rozwoju, testowania oraz debugowania aplikacji.

---

## Deployment produkcyjny (planowany)

Aplikacja może zostać wdrożona na serwerze obsługującym aplikacje **ASP.NET Core**, np.:
- serwer VPS,
- środowisko chmurowe,
- dedykowany serwer aplikacyjny.

Proces wdrożenia obejmuje:
- publikację aplikacji w trybie produkcyjnym,
- konfigurację środowiska uruchomieniowego,
- uruchomienie aplikacji jako usługi serwerowej,
- zapewnienie ciągłej komunikacji SignalR z klientami.

W środowisku produkcyjnym możliwa jest zmiana silnika bazy danych na bardziej skalowalne rozwiązanie, bez ingerencji w logikę domenową aplikacji.

---

## Skalowalność i ograniczenia

Z uwagi na wykorzystanie architektury **Blazor Server**:
- aplikacja wymaga stałego połączenia klienta z serwerem,
- wydajność systemu zależy od zasobów serwera,
- liczba jednoczesnych użytkowników jest ograniczona przepustowością połączeń SignalR.

W przyszłości możliwe jest:
- wdrożenie skalowania poziomego,
- refaktoryzacja architektury,
- rozdzielenie części logiki do osobnych usług backendowych.

---

## Uwagi końcowe

Aktualny model wdrożenia został dobrany z myślą o prostocie, czytelności architektury oraz łatwości rozwoju projektu na wczesnym etapie.

Rozwiązanie to stanowi solidną bazę pod dalszą rozbudowę aplikacji oraz ewentualne zmiany architektoniczne w przyszłości.
