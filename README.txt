Ovo je drugi nacin za implementaciju tcp socketa na nizem nivou. Saljem i ovo resenje radi demonstracije, ali primarno resenje je ono gde se koristi signair.

Ova aplikacija pokrece se tako sto se u 2 terminala unese 

dotnet run --project .\Chat.csproj --urls http://localhost:5003 --port=3003


dotnet run --project .\Chat.csproj --urls http://localhost:5000 --port=3000

Ovde postoji problem kod renderovanja poruka.. Ispisace se u konzoli da je primljena poruka, ali nece se refresovati stranica.. Ovaj bag nisam uspela da uklonim, ali Vam dostavljam i ovo idejno resenje.