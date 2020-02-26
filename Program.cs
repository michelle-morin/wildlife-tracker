using System;
using System.Collections.Generic;
using Wildlife.Models;

namespace Wildlife
{
  public class Program
  {
    public static void AddAnimal()
    {
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
      Console.WriteLine("We're now tracking " + animalName + "! Here are all the animals being tracked:");
      foreach(Animal animal in Animal.myAnimals)
      {
        Console.WriteLine("----------------------");
        Console.WriteLine("Name " + animal.GetAnimalName());
        Console.WriteLine("Species " + animal.GetAnimalType());
        Console.WriteLine("Age: " + animal.GetAnimalAge());
      }
      Console.WriteLine("Would you like to return to the main menu?");
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

    public static void UpdateAnimalAge()
    {
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
        Console.WriteLine("There are no animals matching your search! Would you like to return to the main menu? (Y/N)");
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
      else if (animalsMatchingUpdate.Count == 1)
      {
        Console.WriteLine("What is the animal's updated age?");
        string stringAge = Console.ReadLine();
        int updatedAge = int.Parse(stringAge);
        animalsMatchingUpdate[0].SetAnimalAge(updatedAge);
        Console.WriteLine("We updated the age of " + animalsMatchingUpdate[0].GetAnimalName() + "! Would you like to return to the main menu? (Y/N");
        string yesOrNo = Console.ReadLine();
        string yesOrNoLower = yesOrNo.ToLower();
        if (yesOrNoLower == "y")
        {
          Main();
        }
        else
        {
          Console.WriteLine("OK, have a nice day!");
        }
      }
      else if (animalsMatchingUpdate.Count > 1)
      {
        Console.WriteLine("Which of these animals would you like to update? Enter the animal number.");
        for (int index = 0; index < animalsMatchingUpdate.Count; index++)
        {
          Console.WriteLine("----------------------");
          Console.WriteLine("Animal" + index);
          Console.WriteLine("Name " + animalsMatchingUpdate[index].GetAnimalName());
          Console.WriteLine("Species " + animalsMatchingUpdate[index].GetAnimalType());
          Console.WriteLine("Age: " + animalsMatchingUpdate[index].GetAnimalAge());
        }
        string animalToUpdate = Console.ReadLine();
        int animalNumber = int.Parse(animalToUpdate);
        Console.WriteLine("What is the animal's updated age?");
        string stringAge = Console.ReadLine();
        int updatedAge = int.Parse(stringAge);
        animalsMatchingUpdate[animalNumber].SetAnimalAge(updatedAge);
        Console.WriteLine("We updated the age of " + animalsMatchingUpdate[animalNumber].GetAnimalName() + "! Would you like to return to the main menu? (Y/N");
        string yesOrNo = Console.ReadLine();
        string yesOrNoLower = yesOrNo.ToLower();
        if (yesOrNoLower == "y")
        {
          Main();
        }
        else
        {
          Console.WriteLine("OK, have a nice day!");
        }
      }
    }

    public static void FindAnimal()
    {
      Console.WriteLine("Which animal are you looking for?");
      string animalResponse = Console.ReadLine();
      string animalResponseLower = animalResponse.ToLower();
      List<Animal> animalsMatchingSearch = new List<Animal>() {};
      foreach (Animal animal in Animal.myAnimals)
      {
        if (animal.GetAnimalName() == animalResponseLower)
        {
          animalsMatchingSearch.Add(animal);
        }
      }
      if (animalsMatchingSearch.Count == 0)
      {
        Console.WriteLine("There are no animals matching your search! Would you like to return to the main menu? (Y/N)");
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
      else
      {
        Console.WriteLine("The following animals matched your search:");
        foreach(Animal animal in animalsMatchingSearch)
        {
          Console.WriteLine("----------------------");
          Console.WriteLine("Name: " + animal.GetAnimalName());
          Console.WriteLine("Species: " + animal.GetAnimalType());
          Console.WriteLine("Age: " + animal.GetAnimalAge());
        }
        Main();
      }
    }

    public static void Main()
    {
      Console.WriteLine("Welcome to the main menu of wildlife park tracker! Would you like to track an animal in the park? (Y/N)");
      string userAnswer = Console.ReadLine();
      string userAnswerLower = userAnswer.ToLower();
      if (userAnswerLower == "y")
      {
        FindAnimal();
      }
      else
      {
        Console.WriteLine("Would you like to add an animal to the wildlife tracker instead, or update information for an existing animal in the tracker? (add/update)");
        string answerInput = Console.ReadLine();
        string answerInputLower = answerInput.ToLower();
        if (answerInputLower == "add")
        {
          AddAnimal();
        }
        else if (answerInputLower == "update")
        {
          UpdateAnimalAge();
        }
        else
        {
          Console.WriteLine("Would you like to return to the main menu or exit the application? (menu/exit)");
          string quitOrMenu = Console.ReadLine();
          string quitOrMenuLower = quitOrMenu.ToLower();
          if (quitOrMenuLower == "exit")
          {
            Console.WriteLine("OK, have a nice day!");
          }
          else if (quitOrMenuLower == "menu")
          {
            Main();
          }
          else
          {
            Console.WriteLine("Please select exit or menu.");
            // add logic
          }
        }
      }
    }
  }
}