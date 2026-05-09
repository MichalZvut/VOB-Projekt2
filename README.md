# Weather App

- Program komunikuje s online službou wttr.in pomocí HTTP požadavků a získává aktuální data o počasí ve formátu JSON. Následně tato data zpracovává a zobrazuje uživateli v přehledné podobě.

## Uživatel může:

- zobrazit aktuální počasí pro zadané město
- porovnat počasí mezi dvěma městy
- vypočítat průměrnou teplotu
- zobrazit minimální a maximální teplotu

## Použité principy

- V projektu byly použity principy objektově orientovaného programování:

- rozdělení do více tříd a složek
- oddělení logiky aplikace od práce s daty
- použití rozhraní (interface)
- zapouzdření odpovědností jednotlivých tříd

## Asynchronní zpracování

- Komunikace s API probíhá asynchronně pomocí `async/await` a `HttpClient`.

## Struktura projektu

- Models – datové modely
- Interfaces – rozhraní providerů
- Providers – komunikace s externím API
- Services – aplikační logika
- Program.cs – hlavní menu aplikace
