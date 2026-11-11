# Stage 1: build the application
# we gebruiken de officiële .NET SDK (Software Development Kit) als base image (bevat alles wat nodig is om C#-code te compileren en te publiceren)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#/src maakt de werkmap binnen de buildomgeving en daar ga je dus nu naartoe
WORKDIR /src
#kopieer plant_recommender_engine.csproj naar /src (want ./ beteken 'huidige werkmap') en voer dotnet restore uit vanuit /src (haalt externe dependencies of libraries binnen die in de .csprojn staan)(NuGet is package mananger van C#, eigenlijk zoals pip bij Python)
COPY plant_recommender_engine.csproj ./
RUN dotnet restore
#copy .. kopieer de rest van je project naar de image (eerst . betekent neem alles uit de huidige build context en de 2e . betekent kopieer alles naar de huidige workdir in de image)(hier dus naar /src)(alleen wat in .dockerignore staat word niet mee gekopieerd)
COPY . .
#bouwt en publiceert de applicatie in release mode naar /app/publish. adhv RUN start Docker een shellcommando en voert hetgeen erachter staat uit. 
#dotnet publish doet source code -> compileren -> benodigde dependencies verzamelen -> alle bestanden klaarzetten die nodig zijn om de app te draaien -> outputmap maken (met de uitvoerbare versie van de applicatie)
RUN dotnet publish -c Release -o /app/publish
#in outputmap staat bijvoorbeeld .dll file. = Dynamic Link Library. dat is het gecompileerde hoofdprogramme dat later door de .NET runtime uitgevoerd word. 
#-c release is een buildconfiguratie. Het publiceert de app als productieversie (tov ontwikkelingversie)
#de -o staat voor publish, dwz zet alle gepubliceerde bestanden in de map /app/publish


# TWEEDE FASE: applicatie runnen
#hier gebruiken we een lichtere image met alleen de ASP.NET Core runtime (bevat wat nodig is om een reeds gecompileerde ASP.NET Core-app uit te voeren (maar niet alle ontwikkeltools))
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
#gebruik /app als de actieve werkmap in de uiteindelijke image
WORKDIR /app
#kopieëren van gepubliceerde resultaat van eerste buildfase
COPY --from=build /app/publish .
#hiermee zorgen we dat container bedoelt is om verkeer op te vangen op poort 8080
EXPOSE 8080
#ENV geeft omgevingsvariabele mee aan je applicatie. De naam van die variabele is ASPNETCORE_URLS. Deze bepaalt op welk adres en op welke poort die moet luisteren (http staat voor
#gebruik http, 8080 staat voor luister op poort 8080 en + staat voor luister op alle beschikbare netwerkinterfaces)
ENV ASPNETCORE_URLS=http://+:8080
#dit geeft aan de runtime de opdracht om plant_recommender ... .ddl uit te voeren
ENTRYPOINT ["dotnet", "plant_recommender_engine.dll"]