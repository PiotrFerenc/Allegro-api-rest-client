W trakcie 
- 'zakończ i wystaw' 
- kopiowanie ofert na inne konto 
- budowanie ofert 
- aktualizacja oferty o produkty 

﻿# Allegro api rest client

Połączenie:

- FluentValidation
- MediatR
- Autofac

###### Authorization 


```c#

var clientId = "Client ID z zarejestrowanej aplikacji: https://apps.developer.allegro.pl/";
var clientSecret = "Client Secret z zarejestrowanej aplikacji: https://apps.developer.allegro.pl/";
var base64Key = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

var allegroApi = new AllegroRestClient();

var data = await allegroApi.Query(new GetVerificationUriCompleteCommand()
{
    AuthKey = base64Key,
    ClientId = clientId
});

//open browser with data.url

var result = await allegroApi.Query(new CheckAccountConfirmationCommand()
{
    Authorization = base64Key,
    DeviceCodeId = data.deviceCode
});

var authorization = result.deviceAuthToken.access_token;
```


--------------------------------------------------------------------------

###### **Pobieranie szczegółów oferty:**

https://developer.allegro.pl/documentation/#operation/getOfferUsingGET

```C#
var result = await allegroApi.Query(new GetOfferByIdQuery()
{
    OfferId = "10862116958",
    Authorization = authorization
});                
```

--------------------------------------------------------------------------

###### Dziennik zdarzeń w ofertach sprzedawcy:

https://developer.allegro.pl/documentation/#operation/getOfferEvents

```C#
var result = await allegroApi.Query(new GetOfferEventsQuery()
{
    Type = GetOfferEventsQuery.OfferEventType.OFFER_ACTIVATED,
    Authorization = authorization,
    Limit = 1000,
    From = "ID-EVENTU"
});
```

--------------------------------------------------------------------------

**Jak pobrać moje oferty w REST API**

https://developer.allegro.pl/documentation/#operation/searchOffersUsingGET

```C#
var result = await allegroApi.Query(new GetAllOffersQuery()  
{  
    Authorization = authorization,  
    PublicationStatus = PublicationStatus.Active  
});
```

------------------------------------------

**Pobieranie metod dostawy**

https://developer.allegro.pl/documentation/#operation/getListOfDeliveryMethodsUsingGET
```C#
var result = await allegroApi.Query(new GetDeliveryMethodsQuery()
{
    Authorization = authorization,
});
```

**Pobieranie cenników dostaw**

https://developer.allegro.pl/news/2018-08-14-cenniki_dostawy/#list

```c#
var result = await allegroApi.Query(new GetSellerShippingRatesQuery()
{
    Authorization = authorization,
    SellerId = "123456"
 });
```

**Warunki reklamacji**

```c#
var result = await allegroApi.Query(new GetImpliedWarrantiesQuery()
{
    Authorization = authorization,
    SellerId = "123456"
});
```

**Warunki zwrotów**

```c#
var result = await allegroApi.Query(new GetReturnPoliciesQuery()
{
    Authorization = authorization,
    SellerId = "123456"
});
```

**Informacje o gwarancji**

```c#
var result = await allegroApi.Query(new GetWarrantiesQuery()
{
    Authorization = authorization,
    SellerId = "123456"
});
```
**Wystawianie ofert**
```c#
var auth = "auth-code";
                
var offer = await allegroApi.Query(new OfferByIdQuery()
{
    Authorization = authorization,
    OfferId = "1234567890"
});

Console.WriteLine(offer.Name);
                
var result = await allegroApi.Query(new CreateDraftOfferCommand()
{
    Authorization = authorization,
    Offer = new NewOffer(offer)
});

Console.WriteLine(result); //<-- draft id
```

**Aktualizacja oferty**
```c#
var auth = "auth-code";

var offer = await allegroApi.Query(new OfferByIdQuery()
{
    Authorization = authorization,
    OfferId = "1234567890"
});

var result = await allegroApi.Query(new UpdateOfferCommand()
{
    Authorization = authorization,
    Offer = offer
});
```

**Publikowanie ofert**

```c#
var result = await allegroApi.Query(new PublishOffersCommand()
{
    Authorization = authorization,
    Offers = new List<OfferId>()
    {
        new OfferId("11124109817")
    }
});
```

**Publikowanie produktów**

*Produkty pobierane są wegług nazwy. Dodatkowo wybierony jest najpodobniejszy za pomocą algorytmu Levenshtein distance. *

```c#
var products = await allegroApi.Query(new GetProductsByNameQuery()
{
    Authorization = authorization,
    Name = "Łożysko stożkowe ZVL 32315A"
});

Console.WriteLine("Łożysko stożkowe ZVL 32315A" );
Console.WriteLine(products.bestProductByName.Name);
```



PS: NIE MA NAPISANYCH TESTÓW
