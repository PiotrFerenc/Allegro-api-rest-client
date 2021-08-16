# Allegro api rest client

Połączenie:

- FluentResults
- FluentValidation
- MediatR
- Autofac

Authorization => token do Bearer

```C#
var allegroApi = new AllegroRestClient();
```

--------------------------------------------------------------------------

Pobieranie szczegółów oferty:
https://developer.allegro.pl/documentation/#operation/getOfferUsingGET

```C#
var result = await allegroApi.Query(new GetOfferByIdQuery()
{
    OfferId = "10862116958",
    Authorization = "auth-code"
});                
```

--------------------------------------------------------------------------

Dziennik zdarzeń w ofertach sprzedawcy:


https://developer.allegro.pl/documentation/#operation/getOfferEvents

```C#
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

```C#
var result = await allegroApi.Query(new GetAllOffersQuery()  
{  
    Authorization = "auth-code",  
    PublicationStatus = PublicationStatus.Active  
});
```

------------------------------------------

Pobieranie metod dostawy

https://developer.allegro.pl/documentation/#operation/getListOfDeliveryMethodsUsingGET
```C#
var result = await allegroApi.Query(new GetDeliveryMethodsQuery()
{
    Authorization = "auth-code",
});
```

Pobieranie cenników dostaw

https://developer.allegro.pl/news/2018-08-14-cenniki_dostawy/#list

```c#
var result = await allegroApi.Query(new GetSellerShippingRatesQuery()
{
    Authorization = "auth-code",
SellerId = "123456"
    });
```


PS: NIE MA NAPISANYCH TESTÓW
