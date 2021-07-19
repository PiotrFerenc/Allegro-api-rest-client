# Allegro api rest client

Połączenie:

- FluentResults
- FluentValidation
- MediatR
- Autofac

Authorization => token do Bearer

             var allegroApi = new AllegroRestClient();

--------------------------------------------------------------------------

Pobieranie szczegółów oferty:
https://developer.allegro.pl/documentation/#operation/getOfferUsingGET

```csharp
var result = await allegroApi.Query(new GetOfferByIdQuery()
{
    OfferId = "10862116958",
    Authorization = "auth-code"
});                
```

--------------------------------------------------------------------------

Dziennik zdarzeń w ofertach sprzedawcy:


https://developer.allegro.pl/documentation/#operation/getOfferEvents

```csharp
var result = await allegroApi.Query(new GetOfferEventsQuery()
{
    Type = GetOfferEventsQuery.OfferEventType.OFFER_ACTIVATED,
    Authorization = "auth-code",
    Limit = 1000,
    From = "ID-EVENTU"
});
```

--------------------------------------------------------------------------

Jak pobrać moje oferty w REST API

https://developer.allegro.pl/documentation/#operation/searchOffersUsingGET

```csharp
var result = await allegroApi.Query(new GetAllOffersQuery()  
{  
    Authorization = "auth-code",  
    PublicationStatus = PublicationStatus.Active  
});
```

------------------------------------------







PS: NIE MA NAPISANYCH TESTÓW
