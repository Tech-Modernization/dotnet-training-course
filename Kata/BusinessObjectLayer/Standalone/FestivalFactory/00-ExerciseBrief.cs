using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.FestivalFactory
{
    /*
    Music Festival exercise

    exercise objectives:

    - practice abstract thinking
    - practice interface segregation
    - practice factory pattern
    - practice generic types
    - practice anonymous methods

    This exercise introduces:
    Generic type constraints
    .NET’s Date and Time manipulation features 

    Intro

    a music promoter needs to process applications from musical acts to 
    fill a festival itinerary.  
    each venue caters to a specific musical taste.  

    some of the venues have more than one performance space, 
    and all have different capacities and times between which 
    they can put acts on.

    functional objectives:

    - process applications to perform from acts
    - create a list of performance slots for each venue, based on a number of criteria
    - allocate slots to successful acts at the appropriate venue

    Part 1

    objective: create an interface of all the methods that'll be required

    create the interface IFestivalBooker and define all these methods within it

    define a method AddVenue returning a generic type T 

    (note: this is as simple as it seems.  In the same way as you could have “T arg”, so you can have “T method<T>()”)

    Add  the name of the venue as a formal (i.e. normal) parameter

     also define a method AddPerformanceSpace returning PerformanceSpace

     parameters:
      - capacity of the space
      - max performers that can be on stage
      - rate at which space can be emptied of audience expressed as punters per minute
      - the name of the performance space

    define a method CreateSchedule returning List<PerformanceSlot>
    parameters
      - the PerformanceSpace to schedule
      - the date and time the first performance can begin
      - the venue's closing time

    define a method AddAct returning a generic type T
    parameters
      - the name of the act
      - number of performers
      - year established
      - gigs per year
      - how many songs they can play

    define an overload for AddAct with a single parameter, 
    that is an anonymous method with no return value 
    (i.e. an Action) 

    define a method Apply returning FestivalApplication
    parameters

    an ActBase profile of the interested act
    name of the desired venue
    name of the desired performance space
    preferred time slot
    indication of whether happy to go on stand-by if unsuccessful

    Define a method GetVenueByAct returning VenueBase and accepting ActBase as a parameter
    Define a method GetSpaceByAct returning PerformanceSpace and accepting ActBase as a parameter
    Define a method AllocateSlot returning ActBase and accepting ActBase and PerformanceSpace as parameters
    Define a method GetReputation returning int and accepting ActBase as a parameter
    Define a method Notify accepting FestivalApplication and NotificationType as parameters
    Define a method Accept that takes a FestivalApplication as a parameter
    Define a method Decline that takes a FestivalApplication as a parameter
    Define a method Announce that return an int and accepts a NotificationType as a parameter
    Define a method PrintItinerary that takes a list of VenueBase as a parameter returns void.

    Part 2 

    Objectives:
    Creating factory patterns
    Nesting factories
    Extending factories

    Create a factory pattern of VenueBase and ActBase as the respective abstract creator and product.
    Create a class called PerformanceSpace with a Capacity, Name, PunterExitRatePerMinute and MaxPerformersOnStage
    Create a class called PerformanceSlot with ActBase Act and DateTime StartTime.
    Add a List of PerformanceSpace to VenueBase
    Add a List of PerformanceSlot to PerformanceSpace
    Create a class FestivalApplication containing an ActBase, the name of their preferred venue, performance space and (rough) slot time.
    
    Use ActBase as the abstract creator for a sub-factory 
    pattern with a new abstract product SongBase.
    In ActBase call the list of SongBase "Repertoire".
    Add a TimeSpan to SongBase called AverageDuration
    Inherit from VenueBase, ActBase and SongBase for the 4 genres named as the concretions.
    E.g. JazzVenue, JazzAct, JazzSong, ProgRockVenue, ProgRockAct, ProgRockSong
    Set AverageDuration as follows
    3 mins for Indie songs
    5 mins for Folk songs
    9 mins for Jazz songs
    14 mins for ProgRock songs

    Part 3

    Objectives: 
    Interface segregation
    Extending factory pattern

    Segregate IFestivalBooker.  I.e. distribute the method signatures you’ve created among these interfaces
    IVenueManager
    IActProfiler
    IRepertoireBuilder
    IFestivalBuilder
    IApplicationManager

    Part 4

    Objectives:
    Implementing the interfaces across the factories.

    Add these methods to IFestivalBuilder
    Build returning void with no parameters
    OpenToApplications returning bool with no parameters

    Create a factory pattern using FestivalBase and VenueBase as the creator and product.
    
    Have FestivalBase implement IFestivalBuilder 
    Have FestivalBase implement IApplicationManager
    Have VenueBase implement IVenueManager
    
    Have ActBase implement IActProfiler
    Have ActBase implement IRepertoireBuilder

    Add a List of FestivalApplication to FestivalBase
    Inherit from FestivalBase to create ClasstonburyFestival
    Have the Venue factory method create PerformanceSpaces as follows
    JazzVenue
    capacity: 50, maxperformers: 3, punters/p/m: 6
    
    IndieVenue
    Cap: 500, maxperf: 6, punters: 50
    Cap: 100, maxpef: 2, punters 5
    
    FolkVenue
    Cap: 100, maxperf 4, punters: 10
    
    ProgRockVenue
    capacity : 1200, maxperf 8, punters 50


    Part 5

    Functional Objective:
    Implement IFestivalBuilder

    Part 6

    Conceptual objective
    Introduce generic type constraints

    Functional Objective:
    Implement IVenueManager

    Part 7

    Conceptual objective:
    Practice anonymous methods 

    Functional objectives:
    Implement IActProfiler
    Implement IRepertoireBuilder

    Part 8

    Functional Objective:
    Implement IApplicationManager

    */
}
