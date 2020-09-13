﻿using OdeToFood.Core;
using System.Collections.Generic;
using System;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Scotts's Pizza",
                    Location = "Maryland",
                    Cuisine = CuisineType.Italian
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Cinnamon Club",
                    Location = "London",
                    Cuisine = CuisineType.Indian
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "La Costa",
                    Location = "California",
                    Cuisine = CuisineType.Mexican
                }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var n = string.IsNullOrEmpty(name) ? name : name.ToLower();
            return from x in restaurants
                   where string.IsNullOrEmpty(n) || x.Name.ToLower().StartsWith(n)
                   orderby x.Name
                   select x; ;
        }

    }
}
