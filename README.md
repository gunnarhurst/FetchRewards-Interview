# PointsApi

## Overview:
This is a REST API web service that accepts HTTP requests and returns responses based on conditions outlined here: 
## Background:
* Users have points in their account from various payers.
* The Payer will post transactions to either add or deduct points from the user's account.
  * A single Payer's total points cannot be less than zero.
* A User's points can be spent
  * The user's total points cannot be less than zero.
  * The points will be spent according to timestamp on each transaction regardless of the payer.

## How to run:
*research dotnet build and dotnet run
clone the project down
go to folder and run commands

## Endpoints:
### GET localhost:####/balance
### POST localhost:####/spend
      Body:
      {
       "points": 0
      }
### POST localhost:####/add
      Body:
      {
      "payer": "string",
      "points": 0,
      "timestamp": "2022-06-16T02:40:36.427Z"
      }

  
