Projektet kræver .NET 8 SDK og en SQL Server

**OPSÆTNING AF DATABASE**

For at forbinde til og oprette database:
- Ret ConnectionStrings i appsettings.json.
- Kør projektet igen, så seed-funktionen opretter data automatisk

**SEED FUNKTION**

Seed funktion opretter følgende:
- 4 lægehuse med ydernumrene: 100001, 100002, 100003, 100004
- 4 apoteker som kan foretage receptudleveringer
- 3 recepter med tilknyttet ordinationer på disse cpr-numrene:
    - 2 recepter på 2010035647
    - 1 recept på 2205015643
