## AhmedHanen - Application Web ASP.NET
Ce projet est une application web ASP.NET développée dans le cadre d'un projet académique en collaboration avec Ahmed.

## Configuration
Assurez-vous d'avoir une base de données SQL Server disponible. Vous pouvez configurer la chaîne de connexion dans le fichier appsettings.json :
```json
{
  "ConnectionStrings": {
    "conn": "Data Source=DESKTOP-B0IN09C\\MSSQLSERVERDB;Initial Catalog=data;Integrated Security=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
## Structure du projet
ahmedHanen.csproj: Fichier de projet principal contenant la configuration du projet.

## Installation et exécution:
-Clonez ce dépôt sur votre machine locale.
-Ouvrez le projet dans Visual Studio.
-Assurez-vous que la connexion à la base de données est correctement configurée dans appsettings.json.
-Compilez et exécutez le projet dans Visual Studio.

## Fonctionnalités:
-Gestion des utilisateurs et des rôles
-Gestion des produits et des commandes
-Tableau de bord administratif

## Technologies utilisées:
*ASP.NET Core
*Entity Framework Core
*SQL Server
*Bootstrap
