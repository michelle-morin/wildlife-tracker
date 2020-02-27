using System;
using System.Collections.Generic;
using Wildlife.Models;

namespace Wildlife
{
  public class Program
  {
    public static void ReturnToMenu()
    {
      Console.WriteLine("Would you like to return to the main menu?");
      Console.WriteLine("[Y] or [N]");
      string searchAgain = Console.ReadLine();
      string searchAgainLower = searchAgain.ToLower();
      if (searchAgainLower == "y")
      {
        Main();
      }
      else
      {
        Console.WriteLine("OK, have a nice day!");
      }
    }

    public static void AddAnimal()
    {
      Console.ResetColor();
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("What species of animal would you like to add to the tracker?");
      string animalSpecies = Console.ReadLine();
      string animalSpeciesLower = animalSpecies.ToLower();
      Console.WriteLine("What is the name of the animal you would like to track?");
      string animalName = Console.ReadLine();
      string animalNameLower = animalName.ToLower();
      Console.WriteLine("What is " + animalNameLower + "'s age?");
      string stringAnimalAge = Console.ReadLine();
      int animalAge = int.Parse(stringAnimalAge);
      Animal newAnimal = new Animal(animalSpeciesLower, animalNameLower, animalAge);
      Animal.myAnimals.Add(newAnimal);
      displayTrackedAnimals();
      ReturnToMenu();
    }

    public static void UpdateAnimalAge()
    {
      Console.ResetColor();
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("Would you like to update the age for any of these animals? Enter the animal's name or species:");
      string updateResponse = Console.ReadLine();
      string updateResponseLower = updateResponse.ToLower();
      List<Animal> animalsMatchingUpdate = new List<Animal> {};
      foreach (Animal animal in Animal.myAnimals)
      {
        if (animal.GetAnimalType() == updateResponseLower || animal.GetAnimalName() == updateResponseLower)
        {
          animalsMatchingUpdate.Add(animal);
        }
      }
      if (animalsMatchingUpdate.Count == 0)
      {
        Console.WriteLine("There are no animals matching your search.");
        ReturnToMenu();
      }
      else if (animalsMatchingUpdate.Count == 1)
      {
        Console.WriteLine("What is the animal's updated age?");
        string stringAge = Console.ReadLine();
        int updatedAge = int.Parse(stringAge);
        animalsMatchingUpdate[0].SetAnimalAge(updatedAge);
        Console.WriteLine("We updated the age of " + animalsMatchingUpdate[0].GetAnimalName() + "!");
        ReturnToMenu();
      }
      else if (animalsMatchingUpdate.Count > 1)
      {
        Console.WriteLine("Which of these animals would you like to update? Enter the animal number.");
        for (int index = 0; index < animalsMatchingUpdate.Count; index++)
        {
          Console.WriteLine("----------------------");
          Console.WriteLine("Animal" + index);
          Console.WriteLine("Name: " + animalsMatchingUpdate[index].GetAnimalName());
          Console.WriteLine("Species: " + animalsMatchingUpdate[index].GetAnimalType());
          Console.WriteLine("Age: " + animalsMatchingUpdate[index].GetAnimalAge());
          Console.WriteLine("----------------------");

        }
        string animalToUpdate = Console.ReadLine();
        int animalNumber = int.Parse(animalToUpdate);
        Console.WriteLine("What is the animal's updated age?");
        string stringAge = Console.ReadLine();
        int updatedAge = int.Parse(stringAge);
        animalsMatchingUpdate[animalNumber].SetAnimalAge(updatedAge);
        Console.WriteLine("We updated the age of " + animalsMatchingUpdate[animalNumber].GetAnimalName() + "!");
        ReturnToMenu();
      }
    }

    public static void FindAnimal()
    {
      Console.ResetColor();
      Console.BackgroundColor = ConsoleColor.DarkGray;
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Would you like to search for a specific animal?");
      Console.WriteLine("Y or N");
      string yesOrNo = Console.ReadLine();
      if (yesOrNo.ToLower() == "y")
      {
        Console.WriteLine("Which animal are you looking for?");
        string animalResponse = Console.ReadLine();
        string animalResponseLower = animalResponse.ToLower();
        List<Animal> animalsMatchingSearch = new List<Animal>() {};
        foreach (Animal animal in Animal.myAnimals)
        {
          if (animal.GetAnimalName() == animalResponseLower || animal.GetAnimalType() == animalResponseLower)
          {
            animalsMatchingSearch.Add(animal);
          }
        }
      displaySearchResults(animalsMatchingSearch);
      }
      else
      {
        displayTrackedAnimals();
      }
      ReturnToMenu();
    }

    public static void displayTrackedAnimals()
    {
      if (Animal.myAnimals.Count > 0)
      {
        Console.WriteLine("Animals currently being tracked include:");
        foreach(Animal animal in Animal.myAnimals)
        {
          Console.WriteLine("----------------------");
          Console.WriteLine("Name: " + animal.GetAnimalName());
          Console.WriteLine("Species: " + animal.GetAnimalType());
          Console.WriteLine("Age: " + animal.GetAnimalAge());
          Console.WriteLine("----------------------");
        }
      }
      else
      {
        Console.WriteLine("There are no animals currently being tracked.");
      }
    }

    public static void displaySearchResults(List<Animal> searchResults)
    {
      if (searchResults.Count == 0)
      {
        Console.WriteLine("There are no animals matching your search!");
        displayTrackedAnimals();
      }
      else
      {
        Console.WriteLine("The following animals matched your search:");
        foreach(Animal animal in searchResults)
        {
          Console.WriteLine("----------------------");
          Console.WriteLine("Name: " + animal.GetAnimalName());
          Console.WriteLine("Species: " + animal.GetAnimalType());
          Console.WriteLine("Age: " + animal.GetAnimalAge());
          Console.WriteLine("----------------------");
        }
      }
    }

    public static void SelectOption()
    {
      Console.WriteLine("Welcome to the main menu of wildlife park tracker! Would you like to:");
      Console.WriteLine("- track an animal in the park");
      Console.WriteLine("- add an animal to the wildlife tracker,");
      Console.WriteLine("- update information for a tracked animal, or");
      Console.WriteLine("- quit the application?");
      Console.WriteLine("ENTER: TRACK, ADD, UPDATE, or QUIT");
      string userAnswer = Console.ReadLine();
      string userAnswerLower = userAnswer.ToLower();
      if (userAnswerLower == "track")
      {
        FindAnimal();
        displayTrackedAnimals();
      }
      else if (userAnswerLower == "add")
      {
        AddAnimal();
      }
      else if (userAnswerLower == "update")
      {
        UpdateAnimalAge();
      }
      else if (userAnswerLower == "quit")
      {
        Console.WriteLine("Have a nice day!");
      }
      else
      {
        ReturnToMenu();
      }
    }

    public static void Main()
    {
      Console.ResetColor();
      Console.BackgroundColor = ConsoleColor.Cyan;
      Console.ForegroundColor = ConsoleColor.Black;
      SelectOption();
    }
  }
}