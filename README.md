
# D&D Character Management Site

![GitHub](https://img.shields.io/github/license/Luna-Schaetzle/SWP_Csharp_Projekt_24)
![GitHub last commit](https://img.shields.io/github/last-commit/Luna-Schaetzle/SWP_Csharp_Projekt_24)
![GitHub contributors](https://img.shields.io/github/contributors/Luna-Schaetzle/SWP_Csharp_Projekt_24)
![GitHub issues](https://img.shields.io/github/issues/Luna-Schaetzle/SWP_Csharp_Projekt_24)
![GitHub pull requests](https://img.shields.io/github/issues-pr/Luna-Schaetzle/SWP_Csharp_Projekt_24)
![GitHub repo size](https://img.shields.io/github/repo-size/Luna-Schaetzle/SWP_Csharp_Projekt_24)
![GitHub push](https://img.shields.io/github/commit-activity/m/Luna-Schaetzle/SWP_Csharp_Projekt_24)

## Inhaltsverzeichnis

- [D\&D Character Management Site](#dd-character-management-site)
  - [Inhaltsverzeichnis](#inhaltsverzeichnis)
  - [Über das Projekt](#über-das-projekt)
    - [Geplante Features](#geplante-features)
    - [Umgesetzte Features](#umgesetzte-features)
  - [TODOs](#todos)
  - [Technologiestack](#technologiestack)
  - [Verlauf des Projektes](#verlauf-des-projektes)
    - [Voraussetzungen damit das Projekt Realisiert werden kann](#voraussetzungen-damit-das-projekt-realisiert-werden-kann)
    - [Projekt Initialisieren](#projekt-initialisieren)
  - [Beitrag leistende](#beitrag-leistende)
  - [Lizenz](#lizenz)



## Über das Projekt

Diese Website dient der Verwaltung von Dungeons & Dragons Charakterbögen und bietet zusätzliche Werkzeuge und Ressourcen für Spieler und Spielleiter. Die Anwendung erleichtert nicht nur die Erstellung und Verwaltung von Charakteren, sondern integriert auch nützliche Tools für die Spielplanung und Durchführung.

### Geplante Features

- **Charaktererstellung und -verwaltung**: Benutzer können ihre D&D Charaktere erstellen, bearbeiten und speichern.
  - **Zauberbuch**: Eine digitale Sammlung von Zaubern und Fähigkeiten, die Benutzer ihrem Charakter hinzufügen können.
  - **Inventarverwaltung**: Hilft Spielern, den Überblick über Ausrüstung und Gegenstände ihres Charakters zu behalten.
- **Link zu D&D Wikis**: Direkte Verlinkungen zu externen D&D Wiki-Seiten für detaillierte Informationen über Klassen, Rassen und Ausrüstungen.
- **Charaktererstellungsassistent**: Ein interaktives Tool, das Spielern hilft, Schritt für Schritt neue Charaktere zu erstellen.
- **Battle Koordinator**: Ein Tool zur Verwaltung und Durchführung von Kampfszenarien, inklusive Initiative Tracking und Gesundheitsmanagement.

- **Multi-User Zugang**: Unterstützung für mehrere Benutzer mit individuellen Zugängen und Sichtbarkeiten.
- **Forum**: Ein Diskussionsforum für Spieler und Spielleiter, um sich auszutauschen und Fragen zu stellen.
- **Live Chat**: Ein Chat-Tool für Benutzer, um in Echtzeit miteinander zu kommunizieren.
- **Integration einer eigenen API**: Eine eigene RESTful API, die es Benutzern ermöglicht, auf die Datenbank zuzugreifen und eigene Anwendungen zu erstellen.
- **Dark Mode**: Eine dunkle Benutzeroberfläche für Benutzer, die in dunklen Umgebungen spielen oder einfach nur dunkle Designs bevorzugen.
- **PDF Export**: Die Möglichkeit, Charakterbögen und andere Daten als PDF-Dateien zu exportieren und herunterzuladen.
- **Spell List**: Eine Liste von Zaubern und Fähigkeiten, die Benutzer durchsuchen und filtern können.
- **Verwengung einer Fremd API**: Einbindung einer externen API, um zusätzliche Daten und Ressourcen für Benutzer bereitzustellen.
- **EXP Tracker**: Ein Tool zur Verfolgung des Fortschritts und der Erfahrungspunkte von Charakteren.
- **Würfel-Roller** oder **Würfel-API**: Ein Tool zum Rollen von Würfeln und Generieren von Zufallszahlen für das Spiel.

### Umgesetzte Features

- Multi-User Zugang
- Registrierung und Login
- Benutzerkontoverwaltung
- Session-Verwaltung
- Datenbankanbindung
- Charaktererstellung und bearbeitung mittells Markdown
- Links zu D&D Wikis
- Froum mit Live Chat
- eigene API zum Würfeln (https://localhost:7095/api/dice/roll/[sides])
- Verwendung der eigenen API auf Roll Dice Seite

## TODOs

[TODOS.md](TODO.md)

## Technologiestack

- **Backend**: .NET 8, C#
- **Datenbank**: MySQL
- **Frontend**: (Hier könnten Sie die Technologien einfügen, die Sie für das Frontend verwenden, z.B. Blazor, React.js, Angular etc.)

## Verlauf des Projektes

### Voraussetzungen damit das Projekt Realisiert werden kann

Sicherstellung, dass die folgenden Tools installiert sind:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- Ein geeignetes IDE wie [Visual Studio](https://visualstudio.microsoft.com/vs/) und/oder [VS Code](https://code.visualstudio.com/)

### Projekt Initialisieren 

## Beitrag leistende

Luna Schätzle
https://github.com/Luna-Schaetzle

Florian Prandstetter
https://github.com/jamati123

## Lizenz

Dieses Projekt ist unter der MIT-Lizenz lizenziert - siehe die [LICENSE.md](LICENSE) Datei für Details.

