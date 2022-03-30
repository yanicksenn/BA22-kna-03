# BA22 Knaa 03

Die Arbeit wird durchgeführt von:
- Rhiana Weber (weberrhi@students.zhaw.ch)
- Yanick Senn (sennyan2@students.zhaw.ch)

Die Arbeit wird betreut durch:
- Reto Knaack (knaa@zhaw.ch)

# Use-Cases & funktionale Anforderungen

## Grundlegende Anforderungen
- Req: Die Applikation gestartet
- Req: Der Spieler hat das Headset aufgesetzt
- Req: Der Spieler hält die Controller

## Hauptmenü

### UC: Spiel starten
- Der Spieler kann das Spiel aus dem Hauptmenü aus starten.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Hauptmenü ist aktiv
- FA: Spiel-Szene laden
  - Acc: Das Hauptmenü verschwindet
  - Acc: Die Spiel-Szene ist geladen
1. Der Spieler startet das Spiel

### UC: Tutorial starten
- Der Spieler kann das Tutorial aus dem Hauptmenü aus starten.
- Priorität: Niedrig
- Akteur: Spieler
- Req: Das Hauptmenü ist aktiv
- FA: Tutorial-Szene laden
  - Acc: Das Hauptmenü verschwindet
  - Acc: Die Tutorial-Szene ist geladen
1. Der Spieler startet das Tutorial

### UC: Sandbox starten
- Der Spieler kann die Sandbox aus dem Hauptmenü aus starten.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Hauptmenü ist aktiv
- FA: Sandbox-Szene laden
  - Acc: Das Hauptmenü verschwindet
  - Acc: Die Sandbox-Szene ist geladen
1. Der Spieler startet die Sandbox

## Spiel

### UC: Headset bewegen
- Der Spieler kann das Headset bewegen und die Perspektive wird relativ dazu ausgerichtet.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Perspektive relativ zum Headset ausrichten
  - Acc: Die Perspektive wird relativ zum Headset ausgerichtet
1. Der Spieler bewegt das Headset

### UC: Controller bewegen
- Der Spieler kann die Controller bewegen und die Händ werden relativ dazu ausgerichtet.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Hände relativ zu Controllern bewegen
- FA: Hände durch Controller schliesssen
  - Req: Die Hand ist geöffnet
  - Acc: Die Hand ist geschlossen
- FA: Hände durch Controller öffnen
  - Req: Die Hand ist geschlossen
  - Acc: Die Hand ist geöffnet
1. Der Spieler bewegt die Controller
2. Der Spieler schliesst die Hand
3. Der Spieler öffnet die Hand

### UC: Im Raum bewegen
- Der Spieler kann an eine willkürliche Stelle im Raum zeigen und sich dahin teleportieren.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Eine freie Stelle im Raum
- FA: Spieler an beliebige Stelle im Raum teleporieren
  - Acc: Der Spieler befindet sich nicht mehr an der ursprünglichen Stelle
  - Acc: Der Spieler befinndet sich an der neuen Stelle
1. Der Spieler zeigt mit der Hand an eine willkürliche Stelle im Raum
2. Der Spieler drückt den Index-Trigger am Controller

### UC: Gatter halten
- Der Spieler kann ein Gatter mit den Händen aufnehmen, halten und loslassen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Gatter nehmen
  - Req: Die Hand ist geöffnet
  - Req: Die Hand berührt das Gatter
  - Acc: Das Gatter befindet sich in der Hand
  - Acc: Das Gatter bewegt sich relativ zur Hand
- FA: Gatter loslassen
  - Req: Die Hand ist geschlossen
  - Req: Die Hand hält das Gatter
  - Acc: Das Gatter befindet sich nicht mehr in der Hand
  - Acc: Das Gatter bewegt sich nicht mehr relativ zur Hand
1. Der Spieler berührt mit der Hand ein Gatter
2. Der Spieler drückt den Hand-Trigger am Controller
3. Der Spieler bewegt die Hand
4. Der Spieler lässt den Hand-Trigger am Controller los

### UC: Gatter platzieren
- Der Spieler kann ein Gatter oberhalb eines freien Sockets loslassen. Das Gatter wird auf dem Socket platziert.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Die Hand ist geschlossen
- Req: Die Hand hält das Gatter
- Req: Die Hand befindet sich über einem freien Socket
- FA: Gatter auf freiem Socket platzieren
  - Acc: Das Gatter ist auf dem Socket platziert
  - Acc: Der Socket ist besetzt
1. Der Spieler nimmt ein Gatter in die Hand
2. Der Spieler bewegt die Hand über den freien Socket
3. Der Spieler öffnet die Hand

### UC: Gatter entfernen
- Der Spieler kann ein, auf einem Socket platzieres Gatter in die Hand nehmen und entfernen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Die Hand ist geöffnet
- Req: Die Hand befindet sich über einem besetzten Socket
- FA: Gatter von Socket entfernen
  - Acc: Das Gatter befindet sich in der Hand
  - Acc: Der Socket ist frei
1. Der Spieler bewegt die Hand über den besetzten Socket
2. Der Spieler schliesst die Hand

### UC: Kabel halten
- Der Spieler kann ein Kabel mit den Händen aufnehmen, halten und loslassen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Kabel nehmen
  - Req: Die Hand ist geöffnet
  - Acc: Das Kabel befindet sich in der Hand
  - Acc: Das Kabel bewegt sich relativ zur Hand
- FA: Kabel loslassen
  - Req: Die Hand ist geschlossen
  - Req: Die Hand hält das Kabel
  - Acc: Das Kabel befindet sich nicht mehr in der Hand
  - Acc: Das Kabel bewegt sich nicht mehr relativ zur Hand
1. Der Spieler berührt mit der Hand das Kabel
2. Der Spieler schliesst die Hand
3. Der Spieler bewegt die Hand
4. Der Spieler öffnet die Hand

### UC: Kabel platzieren
- Der Spieler kann ein Kabel zwischen einem Element-Eingang und Element-Ausgängen platzieren. Der Strom wird vom Ausgang zum Eingang weitergeleitet.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Kabel zwischen zwei Elementen platzieren
  - Req: Ein Element-Ausgang existiert
  - Req: Ein freier Element-Eingang existiert
  - Acc: Das Kabel verbindet ein Element-Ausgang und ein Element-Eingang
- FA: Strom zwischen Elementen weiterleiten
  - Req: Ein Kabel ist zwischen einem Element-Eingang und einem Element-Ausgang platziert
  - Acc: Das Strom am Element-Eingang ist gleich wie am Element-Ausgang.
1. Der Spieler berührt mit der Hand den Element-Ausgang
2. Der Spieler schliesst die Hand
3. Der Spieler bewegt die Hand zu dem Element-Eingang
4. Der Spieler berührt mit der Hand den Element-Eingang
5. Der Spieler öffnet die Hand

### UC: Kabel entfernen
- Der Spieler kann ein platziertes Kabel wegziehen und dadurch entfernen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Platziertes Kabel entfernen
  - Req: Ein Kabel ist platziert
  - Req: Die Hand hält das Kabel
  - Req: Das Kabel wurde über eine bestimmte Distanz weggezogen
  - Acc: Das Kabel ist entfernt
  - Acc: Der Strom wird nicht mehr weitergeleitet
1. Der Spieler berührt mit der Hand das Kabel
2. Der Spieler schliesst die Hand
3. Der Spieler bewegt die Hand weg von dem Board

### UC: Strom einschalten
- Der Spieler kann den Strom auf einem Strom-Switch einschalten. Alle damit verbundenen Gatter erhalten Strom auf dem Eingang.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Strom-Switch einschalten
  - Req: Der Strom-Switch ist ausgeschaltet
  - Acc: Der Strom-Switch ist eingeschaltet
- FA: Strom auf verbundene Elemente weitergeben
  - Req: Ein Kabel zwischen dem Strom-Switch und einem Element-Eingang ist platziert
  - Acc: Am Element-Eingang befindet sich Strom
1. Der Spieler berührt mit der Hand den Strom-Switch

### UC: Strom ausschalten
- Der Spieler kann den Strom auf einem Strom-Switch ausschalten. Alle damit verbundenen Gatter erhalten kein Strom auf dem Eingang.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Strom-Switch ausschalten
  - Req: Der Strom-Switch ist eingeschaltet
  - Acc: Der Strom-Switch ist ausgeschaltet
- FA: Kein Strom auf verbundene Elemente weitergeben
  - Req: Ein Kabel zwischen Strom-Switch und einem Element-Eingang ist platziert
  - Acc: Am Element-Eingang befindet sich kein Strom
1. Der Spieler berührt mit der Hand den Strom-Switch

### UC: Stromfluss einblenden
- Der Spieler kann den Stromfluss auf den Gattern und den Kabeln einblenden.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Stromfluss-Switch einschalten
  - Req: Der Stromfluss-Switch ist ausgeschaltet
  - Acc: Der Stromfluss-Switch ist eingeschaltet
- FA: Kabel mit Strom grün einfärben
  - Req: Der Stromfluss-Switch ist eingeschaltet
  - Req: Es existieren Kabel auf dem Board welche Strom weiterleiten
  - Acc: Die Kabel mit Strom werden grün eingefärbt
- FA: Kabel ohne Strom rot einfärben
  - Req: Der Stromfluss-Switch ist eingeschaltet
  - Req: Es existieren Kabel auf dem Board welche kein Strom weiterleiten
  - Acc: Die Kabel ohne Strom werden rot eingefärbt
- FA: Gatter mit Strom grün einfärben
  - Req: Der Stromfluss-Switch ist eingeschaltet
  - Req: Es existieren Gatter auf dem Board welche Strom empfangen
  - Acc: Die Gatter mit Strom werden grün eingefärbt
- FA: Gatter ohne Strom rot einfärben
  - Req: Der Stromfluss-Switch ist eingeschaltet
  - Req: Es existieren Gatter auf dem Board welche kein Strom empfangen
  - Acc: Die Gatter ohne Strom werden rot eingefärbt
1. Der Spieler berührt mit der Hand den Stromfluss-Switch

### UC: Stromfluss ausblenden
- Der Spieler kann den Stromfluss auf den Gattern und den Kabeln ausblenden.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Stromfluss-Switch ausschalten
  - Req: Der Stromfluss-Switch ist eingeschaltet
  - Acc: Der Stromfluss-Switch ist ausgeschaltet
- FA: Einfärbung von Kabel enfernen
  - Req: Der Stromfluss-Switch ist ausgeschaltet
  - Req: Es existieren eingefärbte Kabel auf dem Board
  - Acc: Die Einfärbungn der Kabel ist entfernt
- FA: Einfärbung von Gatter enfernen
  - Req: Der Stromfluss-Switch ist ausgeschaltet
  - Req: Es existieren eingefärbte Gatter auf dem Board
  - Acc: Die Einfärbungn der Gatter ist entfernt
1. Der Spieler berührt mit der Hand den Stromfluss-Switch

### UC: Kreide halten
- Der Spieler kann eine Kreide mit den Händen aufnehmen, halten und loslassen.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Es existiert eine Kreide im Raum
- FA: Kreide nehmen
  - Req: Die Hand ist geöffnet
  - Acc: Die Kreide befindet sich in der Hand
  - Acc: Die Kreide bewegt sich relativ zur Hand
- FA: Kreide loslassen
  - Req: Die Hand ist geschlossen
  - Req: Die Hand hält die Kreide
  - Acc: Das Gatter befindet sich nicht mehr in der Hand
  - Acc: Das Gatter bewegt sich nicht mehr relativ zur Hand
1. Der Spieler berührt mit der Hand die Kreide
2. Der Spieler schliesst die Hand
3. Der Spieler bewegt die Hand
4. Der Spieler öffnet die Hand

### UC: Striche mit Kreide platzieren
- Der Spieler kann mit einer Kreide Striche auf einer Wandtafel platzieren.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Es existiert eine Wandtafel im Raum
- Req: Die Hand hält die Kreide
- Req: Die Kreide berührt die Wandtafel
- FA: Kreide platziert Striche zwischen Berührungspunkten mit Wandtafel
  - Acc: Die Striche sind zwischen den Berührungspunkten platziert
  - Acc: Die Striche bleiben auf der Wandtafel bestehen
1. Der Spieler nimmt die Kreide in die Hand
2. Der Spieler bewegt die Hand zu der Wandtafel
3. Der Spieler bewegt die Hand über die Wandtafel

### UC: Schwamm halten
- Der Spieler kann einen Schwamm mit den Händen aufnehmen, halten und loslassen.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Es existiert ein Schwamm im Raum
- FA: Schwamm nehmen
  - Req: Die Hand ist geöffnet
  - Acc: Der Schwamm befindet sich in der Hand
  - Acc: Der Schwamm bewegt sich relativ zur Hand
- FA: Schwamm loslassen
  - Req: Die Hand ist geschlossen
  - Req: Die Hand hält den Schwamm
  - Acc: Der Schwamm befindet sich nicht mehr in der Hand
  - Acc: Der Schwamm bewegt sich nicht mehr relativ zur Hand
1. Der Spieler berührt mit der Hand die Schwamm
2. Der Spieler schliesst die Hand
3. Der Spieler bewegt die Hand
4. Der Spieler öffnet die Hand

### UC: Striche mit Schwamm entfernen
- Der Spieler kann mit einem Schwamm Striche auf einer Wandtafel entfernen.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Es existiert eine Wandtafel im Raum
- Req: Die Hand hält den Schwamm
- Req: Der Schwamm berührt die Wandtafel
- Req: Der Schwamm berührt Striche
- FA: Schwamm entfernt Striche zwischen Berührungspunkten mit Wandtafel
  - Acc: Die Striche zwischen den Berührungspunkten sind entfernt
1. Der Spieler nimmt den Schwamm in die Hand
2. Der Spieler bewegt die Hand zu der Wandtafel
3. Der Spieler bewegt die Hand über die Striche auf der Wandtafel

### UC: Board leeren
- Der Spieler kann alle auf dem Board platzieren Gatter und Kabel entfernen.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Es existieren Gatter und/oder Kabel auf dem Board
- FA: Gatter und Kabel von Board entfernen 
  - Req: Der Board-Leeren Knopf ist gedrückt
  - Acc: Alle Gatter sind von dem Board entfernt
  - Acc: Alle Kabel sind von dem Board entfernt
1. Der Spieler berührt mit der Hand den Board-Leeren Knopf
s
### UC: Pseudo-Gatter erstellen
- Der Spieler kann die aktuelle Konfiguration auf dem Board in ein Pseudo-Gatter komprimieren.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Es existieren Gatter und/oder Kabel auf dem Board
- Req: Der Komprimieren-Knopf ist gedrückt
- FA: Aktuelle Konfiguration auf Pseudo-Gatter übertragen
  - Acc: Das Pseudo-Gatter ist gleichwertig zu der aktuellen Konfiguration
- FA: Aktuelle Konfiguration auf Gatter-Dispenser ablegen
  - Acc: Das Pseudo-Gatter ist unter dem aktuellen Label im Dispenser abgelegt
1. Der Spieler berührt mit der Hand den Komprimieren-Knopf

### UC: Label für Pseudo-Gatter bestimmen
- Der Spieler kann das Label für das Pseudo-Gatter bestimmen.
- Priorität: Mittel
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Vorherigen Buchstaben auswählen
  - Req: Der Up-Knopf ist gedrückt
  - Acc: Der vorherige Buchstabe ist ausgewählt
- FA: Nächsten Buchstaben auswählen
  - Req: Der Down-Knopf ist gedrückt
  - Acc: Der nächste Buchstabe ist ausgewählt
1. Der Spieler berührt mit der Hand den Up-Knopf bis der gewünschte Buchstabe erscheint
2. Der Spieler berührt mit der Hand den Down-Knopf bis der gewünschte Buchstabe erscheint

### UC: Gatter-Dispenser betätigen
- Der Spieler kann komprimierte Gatter aus dem Gatter-Dispenser beziehen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Der Dispense-Knopf ist gedrückt
- FA: Aktuell ausgewähltes Gatter erstellen
  - Acc: Das aktuell ausgewählte Gatter ist erschienen
1. Der Spieler berührt mit der Hand den Dispense-Knopf

### UC: Aufgabe lösen
- Der Spieler kann die aktuelle Konfiguration auf dem Board mit der aktuellen Aufgabe überprüfen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Aktuelle Konfiguration mit Aufgabe vergleichen
  - Req: Der Lösen-Knopf ist gedrückt
  - Acc: Die Aufgabe wird überprüft
- FA: Richtig gelöste Aufgabe einblenden
  - Req: Der Lösen-Knopf ist gedrückt
  - Req: Die aktuelle Konfiguration auf dem Board erzeugt den richtigen Output
  - Acc: Der Spieler weiss das die Aufgabe richtig gelöst ist  
  - Acc: Die nächste Aufgabe ist auf der Wandtafel
- FA: Falsch gelöste Aufgabe einblenden
  - Req: Der Lösen-Knopf ist gedrückt
  - Req: Die aktuelle Konfiguration auf dem Board erzeugt den falschen Output
  - Acc: Der Spieler weiss das die Aufgabe falsch gelöst ist
- FA: Raum abschliessen
  - Req: Der Lösen-Knopf ist gedrückt
  - Req: Alle Aufgaben sind gelöst
  - Acc: Der Spieler weiss das alle Aufgaben gelöst sind
  - Acc: Das Spiel wist abgeschlossen
1. Der Spieler berührt mit der Hand den Lösen-Knopf

### UC: Gatter im Gatter-Dispenser auswählen
- Der Spieler kann komprimierte Gatter auf dem Gatter-Dispenser auswählen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- FA: Vorheriges Gatter auswählen
  - Req: Der Up-Knopf ist gedrückt
  - Acc: Das vorherige Gatter ist ausgewählt
- FA: Nächstes Gatter auswählen
  - Req: Der Down-Knopf ist gedrückt
  - Acc: Das nächste Gatter ist ausgewählt
- FA: Aktuelles Gatter-Label anzeigen
  - Req: Der Up-Knopf oder Down-Knopf ist gedrückt
  - Acc: Das Label des aktuell ausgewählten Gatters ist auf dem Dispenser ersichlich
1. Der Spieler berührt mit der Hand den Up-Knopf bis das Label des gewünschten Gatters erscheint
2. Der Spieler berührt mit der Hand den Down-Knopf bis das Label des gewünschten Gatters erscheint

### UC: Aufgabe ablesen
- Der Spieler kann die aktuelle Aufgabe auf einer Wandtafel ablesen.
- Priorität: Wichtig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Der Raum ist noch nicht abgeschlossen
- FA: Aktuelle Aufgabe auf Wandtafel anzeigen
  - Acc: Die aktuelle Aufgabe ist auf der Wandtafel ersichtlich
1. Der Spieler richtet das Headset zur Wandtafel aus

### UC: Raum zurücksetzen
- Der Spieler kann im Notfall die Szene zurücksetzen.
- Priorität: Niedrig
- Akteur: Spieler
- Req: Das Spiel ist aktiv
- Req: Der Reset-Knopf ist gedrückt
- FA: Spiel-Szene neu laden
  - Acc: Die Spiel-Szene ist neu geladen
1. Der Spieler berührt mit der Hand den Reset-Knopf

