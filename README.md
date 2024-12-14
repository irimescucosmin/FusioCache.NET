# FusionCache Demo Project

This repository was created as a companion to the Italian article "[Cosa rende FusionCache così irresistibile in ASP.NET Core](https://cosminirimescu.com/cosa-rende-fusioncache-cosi-irresistibile-in-asp-net-core)". It demonstrates how to implement and use **FusionCache** in an ASP.NET Core project for caching API data.

## Overview

FusionCache is a powerful and flexible caching library that allows developers to easily implement in-memory caching for their web applications. In this demo project, we walk through setting up and using FusionCache to:

- **Sync Cache**: Retrieve data from an external API and store it in the cache.
- **Use Cache**: Fetch data directly from the cache, avoiding repeated calls to the external API.
- **No Cache**: Fetch fresh data directly from the API without using the cache.

## Project Structure

The project includes:

- A simple **ASP.NET Core Web API** with three endpoints:
  1. **SyncCache**: Synchronize and store data in the cache.
  2. **CacheData**: Retrieve data from the cache.
  3. **NoCacheData**: Fetch data directly from the external API without using the cache.
  
- **HttpClient Configuration**: The project uses `HttpClient` to retrieve mock data from an external API (`https://jsonplaceholder.typicode.com`).

- **FusionCache Configuration**: Demonstrates how to set up and use FusionCache for caching API responses.