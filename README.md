# Hobby Team Manager

## Table of Contents
- [Hobby Team Manager](#hobby-team-manager)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Idea](#idea)
  - [Description](#description)
  - [Technologies](#technologies)
  - [Project Status](#project-status)
      - [Whats next ...](#whats-next-)
  - [Setup](#setup)
  - [How to ...](#how-to-)

## Introduction
Hobby Team Manager (HTM) is a sample project to demonstrate a .NET Core app using Razor Pages and a MySql database running on a RaspBerry Pi.

## Idea
I'm playing soccer (Fußball) in two hobby teams - Mondays and Fridays. The Fridays team is super organized with it's own private web page [Emerholzkicker](https://www.emerholzkicker.de/). Per the availabilty on each Fridays (visible on the web page) a talented guy decides for two teams. Very often there are discussions before, during and after the matches whether the teams could not have been set up in a different way. During those discussions several times the idea came up to have a computer decide on the teams. This web app is the first step to that goal ... ;-)

## Description
During development the idea evolved to not only cover one single team, but to be able to manage several teams. With that the app needs to be a bit more flexible, because the "design" (i.e. background color) is no longer fixed.

For a team we want to be able to manage the following within the app:
* Name of the team
* Start month in a specified year with a 12 month season
* Weekday on which the team plays (soccer or whatsoever)
* (Color of team 1 and team 2)
* Availability management by either
  * automatically unavailable with active application in the web app (or other means?) for a matchday before a deadline (specified weekday)
  * automatically available with active resignation in the web app (or other means?) for a matchday before a deadline (specified weekday)
* An admin can ...
  * ... CRUD seasons (with all matchdays inclusive starting point of availability management)
  * ... CRUD players (members, guests (, ex-players))
  * set up teams (until "the computer" does it ...) for a matchday
* A user can edit his account and view all the stuff (no "create" / "edit" / "delete" pages)
* the app sends a reminder email at a specified span before the matchday to all players to either apply to or resign from a matchday.
* after a match the result can be entered on that matchday
* the app sends a happy birthday email on birthdays of players
* in matchday preparation the app computes two teams of equal strength using the strength/score of available players and sends an email to all players at a specified time span ahead of the match. At the moment the strength/score of a player is not yet computed - is represented as a `float` which might change in the future - has to change: it's always 0.0 at the moment :-) There are some ideas on how to "calculate" a score per player ...

## Technologies
The HTM web app is developed using Microsoft Visual Studio Community 2022 (64-bit)
* Frameworks
  * Microsoft.AspNetCore.App
  * Microsoft.NETCore.App
* Packages
  * Microsoft.EntityFrameworkCore (6.0.3)
  * Microsoft.EntityFrameworkCore.Design (6.0.3)
  * Microsoft.EntityFrameworkCore.Tools (6.0.3)
  * Microsoft.VisualStudio.Web.CodeGeneration.Design (6.0.2)
  * Pomelo.EntityFrameworkCore.MySql (6.0.1)
  * SixLabors.ImageSharp (2.1.0)

Code-first approach and using EntityTypeConfigurations rather than DataAnnotations in model classes (avoid "magic strings").
```C#
public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        ...

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        ...
    }
}
```
There is one exception: the name of visual properties
```C#
    [Display(Name = "Vorname")]
    public string FirstName { get; set; } = "";
```

## Project Status
After having created CRUD pages for seasons with matchdays, players and was about to look after the availability of players on matchdays and the teams, I decided to have an a little more "holistic approach" and also introduce a site to allow more than one hobby team to be managed by the app.
#### Whats next ...
* implement Site model with "flexible" layout
  * DONE: background and text colors
  * DONE: menubar on the top
  * DONE: sidebar on the left - BUT STILL LOOKS UGLY!
* DONE: add unit testing using NUnit and Moq starting with the Site model
* bring already existing models under the site model (relationships) (incl. adding unit testing to those models!)
  1. Season model
  2. Matchday model
  3. Player model
    * implement "Import" for players and probably (historic) seasons via json files
  4. ...
* Implement authentication ("Registration", "Login") and some authorization without using the super allmighty "Identity".
* Now having mail addresses we can start implementing the reminder and birthday emails
* fix layout with sidebar on the left
* ...
* ...
* make the Raspberry Pi running the web app available in the web behind some safety means
* describe Raspberry Pi setup herein (update section "Setup")
* update section "How to ..."

## Setup
Here goes the setup of the Raspberry Pi with nginx ...

## How to ...
... create one Site and set up a season with players using screenshots ...
