## Projektbeskrivning
##ResturanGuiden

Detta är ett konsolprogram i C# där man samlar och hanterar matställen.

Användaren navigerar i en meny med piltangenterna och kan:

- visa alla restauranger i en tabell (Id, namn, kök, område, adress, betyg)
- lägga till, redigera och ta bort restauranger
- söka på namn, adress eller område
- se statistik: antal restauranger per kök och en topplista med de högst betygsatta

Varje restaurang har namn, kök (till exempel svenskt, asiatiskt eller mellanöstern), område, adress, betyg (1–5),
prisnivå och om det finns vegetariska alternativ.

All data sparas i en JSON-fil (`restaurants.json`) som läses in när programmet startar och sparas när det avslutas.
Händelser som att lägga till, ändra och ta bort sparas i en logg (`log.json`).

### Starta i Visual Studio

1. Klona repot och öppna projektfilen `Grupp5.csproj`.
2. Tryck **F5** (eller **Ctrl + F5** för att köra utan felsökning).

### Använda programmet

1. Välj ett alternativ i menyn med **↑/↓** och bekräfta med **Enter**.
2. Följ frågorna på skärmen. Betyget ska vara ett tal mellan 1 och 5.
3. Välj **Avsluta** för att stänga ner programmet.
