using System;
using System.Collections.Generic;

namespace Wildlife.Models
{
  public class Animal
  {
    private string _typeOfAnimal;
    private string _name;
    private int _age;

    public Animal(string typeOfAnimal, string name, int age)
    {
      _typeOfAnimal = typeOfAnimal;
      _name = name;
      _age = age;
    }

    public static List<Animal> myAnimals = new List<Animal>() {};

    public string GetAnimalType()
    {
      return _typeOfAnimal;
    }

    public string GetAnimalName()
    {
      return _name;
    }

    public int GetAnimalAge()
    {
      return _age;
    }

    public void SetAnimalAge(int updatedAnimalAge)
    {
      _age = updatedAnimalAge;
    }
  }
}